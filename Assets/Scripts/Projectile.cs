using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {
    protected float damage;
    protected Rigidbody2D myRigidbody;
    protected bool cloned;

    public void Init(float angle, float projectileDamage, float speed, bool clone)
    {
        damage = projectileDamage;
        UpdateVelocity(angle, speed);
        cloned = clone;
    }

    public void UpdateVelocity(float angle, float speed)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = new Vector2(speed * Mathf.Cos(Mathf.Deg2Rad * angle), speed * Mathf.Sin(Mathf.Deg2Rad * angle));
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetSpeed()
    {
        return myRigidbody.velocity.magnitude;
    }

    public float GetAngle()
    {
        float angle = Vector2.Angle(Vector2.right, myRigidbody.velocity);
        if(myRigidbody.velocity.y < 0)
        {
            angle = 360 - angle;
        }
        return angle;
    }

    protected void makeClones()
    {
        cloned = true;
        GameObject c1 = (GameObject)Object.Instantiate(this.gameObject);
        Debug.Log(GetAngle());
        c1.GetComponent<Projectile>().Init(GetAngle() + 5, GetDamage(), GetSpeed(), true);
        GameObject c2 = (GameObject)Object.Instantiate(this.gameObject);
        c2.GetComponent<Projectile>().Init(GetAngle() - 5, GetDamage(), GetSpeed(), true);
    }

    public bool IsCloned()
    {
        return cloned;
    }

    public void SetCloned(bool c)
    {
        cloned = c;
    }

}
