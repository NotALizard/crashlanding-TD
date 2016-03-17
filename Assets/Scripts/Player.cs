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

    //Components
    Rigidbody2D myBody2D;
    Animator anim;
    public Transform footBL;
    public Transform footTR;

    //Other
    bool canJump = true;
    bool facingRight = true;
    int moveDirection;
    public LayerMask ground;

	void Start () {
        myBody2D = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        footBL = transform.FindChild("footBL");
        footTR = transform.FindChild("footTR");
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
            if (facingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                facingRight = false;
            }
        }
        else if(right && !left)
        {
            moveDirection = 1;
            if (!facingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                facingRight = true;
            }
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
        if(crouch && canJump)
        {
            anim.SetBool("isCrouch", true);
        }
        else if (anim.GetBool("isCrouch"))
        {
            anim.SetBool("isCrouch", false);
        }

    }
}
