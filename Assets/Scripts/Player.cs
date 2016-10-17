using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //Input aliases
    bool left;
    bool right;
    bool jump;
    bool crouch;
    bool fire;
    bool build;

    //Constants
    public float jumpHeight = 4;
    float runSpeed = 5;
    float fireDelay = 1;
    int shots = 3;
    int damage = 4;
    float spread = 10;

    //Components
    Rigidbody2D myBody2D;
    Animator anim;
    public Transform footBL;
    public Transform footTR;
    Transform leftArm;
    Transform rightArm;
    Gun gun;
    Detector buildingDetector;
    ShopUI shop;
    public Transform mainCamera;
    private Transform cameraPos;

    //Other
    bool canJump = true;
    bool isCrouching = false;
    bool facingRight = true;
    int moveDirection;
    public LayerMask ground;
    public LayerMask playerLayer;
    public LayerMask platform;
    float fireTime = 0;

    //Upgrade Selection
    public GameObject BuildFab;
    public Transform BuildGrid;
    Building selectedBuilding;
    float startBuildTime;
    float doneBuildTime = 1;
    bool buildingLeft;
    bool buildingTop;
    bool buildingRight;
    bool selling;
    bool shopIsActive;
    bool hasSelecton;

    //Status
    float health;
    float maxHealth;
    public int money = 10000;
    private int techLevel = 5;



	void Start () {
        myBody2D = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        footBL = transform.FindChild("FootBL");
        footTR = transform.FindChild("FootTR");
        leftArm = transform.FindChild("LeftArm");
        rightArm = transform.FindChild("RightArm");
        gun = leftArm.FindChild("Gun").GetComponent<Gun>();
        buildingDetector = transform.FindChild("Detector").GetComponent<Detector>();
        shop = transform.FindChild("Shop").GetComponent<ShopUI>();
        cameraPos = transform.FindChild("CameraPos");
	}

    void FixedUpdate()
    {
        //Update Inputs
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        jump = Input.GetKey(KeyCode.W);
        crouch = Input.GetKey(KeyCode.S);
        fire = Input.GetKey(KeyCode.Mouse0);
        build = Input.GetKey(KeyCode.Space);



        //Actions that can be done while not building
        if (!build)
        {
            //If the shop is still on, hide it
            if (shopIsActive)
            {
                selectedBuilding.transform.FindChild("Selector").GetComponent<SpriteRenderer>().enabled = false;
                shop.Sleep();
                shopIsActive = false;
                hasSelecton = false;
            }

            //Walking
            if (left && !right)
            {
                moveDirection = -1;
            }
            else if (right && !left)
            {
                moveDirection = 1;
            }
            else if (!right && !left)
            {
                moveDirection = 0;
            }
            if (crouch)
            {
                moveDirection = 0;
            }
            myBody2D.velocity = new Vector2(moveDirection * runSpeed, myBody2D.velocity.y);

            //Jumping
            if ((Physics2D.OverlapArea(footTR.position, footBL.position, ground) || Physics2D.OverlapArea(footTR.position, footBL.position, platform)) && myBody2D.velocity.y < 0.01)
            {
                if (anim.GetBool("jump"))
                {
                    anim.SetBool("jump", false);
                }
                canJump = true;
            }

            if (canJump && jump && !build)
            {
                anim.SetBool("jump", true);
                Physics2D.IgnoreLayerCollision(playerLayer, platform, true);
                myBody2D.velocity = new Vector3(myBody2D.velocity.x, jumpHeight);
                canJump = false;
            }

            //Crouching
            if (crouch && canJump && !isCrouching && !build)
            {
                anim.SetBool("isCrouch", true);
                isCrouching = true;
                leftArm.localPosition = new Vector3(leftArm.localPosition.x, leftArm.localPosition.y - 0.04f, leftArm.localPosition.z);
                rightArm.localPosition = new Vector3(rightArm.localPosition.x, rightArm.localPosition.y - 0.04f, rightArm.localPosition.z);

            }
            else if ((!crouch || build) && isCrouching)
            {
                anim.SetBool("isCrouch", false);
                isCrouching = false;
                leftArm.localPosition = new Vector3(leftArm.localPosition.x, leftArm.localPosition.y + 0.04f, leftArm.localPosition.z);
                rightArm.localPosition = new Vector3(rightArm.localPosition.x, rightArm.localPosition.y + 0.04f, rightArm.localPosition.z);
            }
        }


        //Actions related to building and upgrading
        else
        {
            //Prevent movement so that the player can make their selection
            myBody2D.velocity = new Vector2(0, myBody2D.velocity.y);
            if (!hasSelecton)
            {
                selectedBuilding = buildingDetector.GetSelection();
                hasSelecton = true;
            }

            //Make sure they have a building selected
            if (selectedBuilding != null)
            {
                //Bring up the shop UI
                if (!shopIsActive)
                {
                    selectedBuilding.transform.FindChild("Selector").GetComponent<SpriteRenderer>().enabled = true;
                    shop.DisplayShop(selectedBuilding.GetCosts(), selectedBuilding.GetIcons(), selectedBuilding.GetTechLevels());
                    shopIsActive = true;
                }

                //Choosing left option
                if (left && !(right || jump || crouch) && selectedBuilding.leftOpt != null)
                {
                    if (!buildingLeft)
                    {
                        startBuildTime = Time.time;
                        buildingLeft = true;
                    }
                    else if (Time.time - startBuildTime >= doneBuildTime)
                    {
                        money -= selectedBuilding.leftOpt(selectedBuilding);
                        buildingLeft = false;
                        shop.DisplayShop(selectedBuilding.GetCosts(), selectedBuilding.GetIcons(), selectedBuilding.GetTechLevels());
                    }
                }
                else if (buildingLeft)
                {
                    buildingLeft = false;
                    shop.SetProgress(0, false, false, false, false);
                }
                //Top option
                if(jump && !(left || right || crouch) && selectedBuilding.topOpt != null)
                {
                    if (!buildingTop)
                    {
                        startBuildTime = Time.time;
                        buildingTop = true;
                    }
                    else if (Time.time - startBuildTime >= doneBuildTime)
                    {
                        money -= selectedBuilding.topOpt(selectedBuilding);
                        buildingTop = false;
                        shop.DisplayShop(selectedBuilding.GetCosts(), selectedBuilding.GetIcons(), selectedBuilding.GetTechLevels());
                    }
                }
                else if (buildingTop)
                {
                    buildingTop = false;
                    shop.SetProgress(0, false, false, false, false);
                }
                //Right option
                if (right && !(left || jump || crouch) && selectedBuilding.rightOpt != null)
                {
                    if (!buildingRight)
                    {
                        startBuildTime = Time.time;
                        buildingRight = true;
                    }
                    else if (Time.time - startBuildTime >= doneBuildTime)
                    {
                        money -= selectedBuilding.rightOpt(selectedBuilding);
                        buildingRight = false;
                        shop.DisplayShop(selectedBuilding.GetCosts(), selectedBuilding.GetIcons(), selectedBuilding.GetTechLevels());
                    }
                }
                else if (buildingRight)
                {
                    buildingRight = false;
                    shop.SetProgress(0, false, false, false, false);
                }
                //Sell option
                if (crouch && !(left || right || jump) && selectedBuilding.sellOpt != null)
                {
                    if (!selling)
                    {
                        startBuildTime = Time.time;
                        selling = true;
                    }
                    else if (Time.time - startBuildTime >= doneBuildTime)
                    {
                        money += selectedBuilding.Refund();
                        selectedBuilding.sellOpt(selectedBuilding);
                        selling = false;
                        shop.DisplayShop(selectedBuilding.GetCosts(), selectedBuilding.GetIcons(), selectedBuilding.GetTechLevels());
                    }
                }
                else if (selling)
                {
                    selling = false;
                    shop.SetProgress(0, false, false, false, false);
                }
                shop.SetProgress((Time.time - startBuildTime) / doneBuildTime, buildingLeft, buildingTop, buildingRight, selling);
            }
            //If the player is on the ground and not in front of a building tile, create one
            else if (transform.position.y < -1.15 && canJump)
            {
                GameObject g = (GameObject)Object.Instantiate(BuildFab, new Vector2(Mathf.Floor(transform.position.x / 3.2f) * 3.2f + BuildGrid.position.x, BuildGrid.position.y), Quaternion.identity);
                buildingDetector.SetSelection(g.GetComponent<Building>());
                selectedBuilding = buildingDetector.GetSelection();
                hasSelecton = true;
            }
        }

        //Actions not affected by building
        anim.SetFloat("speed", Mathf.Abs(myBody2D.velocity.x));

        //Determine whether the player is moving backwards and update the animator
        if (moveDirection < 0 && facingRight)
        {
            anim.SetBool("movingBack", true);
        }
        else if (moveDirection > 0 && !facingRight)
        {
            anim.SetBool("movingBack", true);
        }
        else
        {
            anim.SetBool("movingBack", false);
        }

        //Shooting
        if (fire && Time.time - fireTime > fireDelay)
        {
            fireTime = Time.time;
            gun.Fire(shots, spread, damage);
            
        }

        //Platforms
        if(!canJump && myBody2D.velocity.y < 0)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, platform, false);
        }

        //Camera Follow
        mainCamera.position = new Vector3(cameraPos.position.x, cameraPos.position.y, mainCamera.position.z);

    }

    //Flip the player along the y axis (horizontally)
    public void Flip()
    {
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
            transform.FindChild("Shop").localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
            transform.FindChild("Shop").localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void IncreaseTechLevel()
    {
        techLevel += 1;
    }

    public int GetTechLevel() { return techLevel; }


}
