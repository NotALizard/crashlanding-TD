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

    //Other
    bool canJump = true;
    bool facingRight = true;

	void Start () {
        myBody2D = this.GetComponent<Rigidbody2D>();
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
        if(left && !right)
        {
            myBody2D.velocity = new Vector3(-1 * runSpeed, myBody2D.velocity.y);
            if (facingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                facingRight = false;
            }
        }
        else if(right && !left)
        {
            myBody2D.velocity = new Vector3(runSpeed, myBody2D.velocity.y);
            if (!facingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                facingRight = true;
            }
        }

        //Jumping
        if(canJump && jump)
        {
            myBody2D.velocity = new Vector3(myBody2D.velocity.x, jumpHeight);
            jump = false;
        }

    }
}
