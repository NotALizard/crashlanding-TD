using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //Input aliases
    bool left;
    bool right;
    bool jump;
    bool crouch;
    bool fire;

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

    //Other
    bool canJump = true;
    bool isCrouching = false;
    bool facingRight = true;
    int moveDirection;
    public LayerMask ground;
    float fireTime = 0;


	void Start () {
        myBody2D = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        footBL = transform.FindChild("FootBL");
        footTR = transform.FindChild("FootTR");
        leftArm = transform.FindChild("LeftArm");
        rightArm = transform.FindChild("RightArm");
        gun = leftArm.FindChild("Gun").GetComponent<Gun>();
	}
	
	void Update () {
	
	}

    void FixedUpdate()
    {
        //Update Inputs
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        jump = Input.GetKey(KeyCode.W);
        crouch = Input.GetKey(KeyCode.S);
        fire = Input.GetKey(KeyCode.Mouse0);



        //Walking
        if (left && !right)
        {
            moveDirection = -1;
        }
        else if(right && !left)
        {
            moveDirection = 1;
        }
        else if(!right && !left)
        {
            moveDirection = 0;
        }
        if (crouch)
        {
            moveDirection = 0;
        }

        myBody2D.velocity = new Vector3(moveDirection * runSpeed, myBody2D.velocity.y);
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

        //Jumping
        if (Physics2D.OverlapArea(footTR.position, footBL.position, ground) && myBody2D.velocity.y < 0.01)
        {
            if (anim.GetBool("jump"))
            {
                anim.SetBool("jump", false);
            }
            canJump = true;
        }

        if (canJump && jump)
        {
            anim.SetBool("jump", true);
            myBody2D.velocity = new Vector3(myBody2D.velocity.x, jumpHeight);
            canJump = false;
        }

        //Crouching
        if(crouch && canJump && !isCrouching)
        {
            anim.SetBool("isCrouch", true);
            isCrouching = true;
            leftArm.localPosition = new Vector3(leftArm.localPosition.x, leftArm.localPosition.y - 0.04f, leftArm.localPosition.z);
            rightArm.localPosition = new Vector3(rightArm.localPosition.x, rightArm.localPosition.y - 0.04f, rightArm.localPosition.z);

        }
        else if (!crouch && isCrouching)
        {
            anim.SetBool("isCrouch", false);
            isCrouching = false;
            leftArm.localPosition = new Vector3(leftArm.localPosition.x, leftArm.localPosition.y + 0.04f, leftArm.localPosition.z);
            rightArm.localPosition = new Vector3(rightArm.localPosition.x, rightArm.localPosition.y + 0.04f, rightArm.localPosition.z);
        }

        //Shooting
        if (fire && Time.time - fireTime > fireDelay)
        {
            fireTime = Time.time;
            gun.Fire(shots, spread, damage);
            
        }

    }

    //Flip the player along the y axis (horizontally)
    public void Flip()
    {
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Debug.Log("flipped");
            facingRight = false;
        }
        else if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("flipped");
            facingRight = true;
        }
    }


}
