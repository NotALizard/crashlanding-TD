using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //Input aliases
    bool left;
    bool right;
    bool jump;
    bool crouch;

    //Constants
    public float jumpHeight = 4;
    float runSpeed = 5;

    //Components
    Rigidbody2D myBody2D;
    public Transform footBL;
    public Transform footTR;

    //Other
    bool canJump = true;
    bool facingRight = true;
    int moveDirection;
    public LayerMask ground;

	void Start () {
        myBody2D = this.GetComponent<Rigidbody2D>();
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

        myBody2D.velocity = new Vector3(moveDirection * runSpeed, myBody2D.velocity.y);

        //Jumping
        if (Physics2D.OverlapArea(footTR.position, footBL.position, ground) && myBody2D.velocity.y < 0.01)
        {
            canJump = true;
        }

        if (canJump && jump)
        {
            myBody2D.velocity = new Vector3(myBody2D.velocity.x, jumpHeight);
            canJump = false;
        }

    }
}
