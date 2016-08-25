using UnityEngine;
using System.Collections;

public class Roller : Enemy {
    Transform player;

    public override void Init(float maxHP, float dam, float spd)
    {
        base.Init(maxHP, dam, spd);
        player = GameObject.Find("Player").transform;
    }

    //temp
    void Start () {
        //temp values for testing
        Init(100, 10, 2);
	}
	
	void FixedUpdate () {
        //Movement
        if (player.position.x > transform.position.x)
            moveDirection = 1;
        else
            moveDirection = -1;
        myBody2D.velocity = new Vector2(moveDirection * speed, myBody2D.velocity.y);
        if ((moveDirection > 0 && !facingRight) || (moveDirection < 0 && facingRight))
            Flip();
	}
}
