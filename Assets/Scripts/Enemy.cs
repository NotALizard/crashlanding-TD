using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    protected float maxHealth;
    //protected float health;
    public float health;
    protected float stunFactor = 1;
    protected float stunTime;
    protected float stunDuration;
    protected float damage;
    protected float speed;
    protected bool facingRight;
    protected int moveDirection;
    protected Rigidbody2D myBody2D;

    public virtual void Init(float maxHP, float dam, float spd)
    {
        maxHealth = maxHP;
        damage = dam;
        speed = spd;
        health = maxHealth;
        myBody2D = GetComponent<Rigidbody2D>();
    }

    public void Stun(float fac, float dur)
    {
        stunFactor = fac;
        stunDuration = dur;
        stunTime = Time.time;
    }

    protected bool CheckStun()
    {
        return (Time.time - stunTime >= stunDuration);
    }

    public void Hurt(float dam)
    {
        health = health - dam;
        if (health <= 0)
            Kill();
    }

    private void Kill()
    {
        Destroy(this.gameObject);
    }

    protected void Flip()
    {
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }
        else if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
    }
}
