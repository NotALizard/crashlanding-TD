using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {
    protected float damage;
    protected Rigidbody2D myRigidbody;
    protected bool cloned;

    public void Init(float angle, float projectileDamage, float speed)
    {
        damage = projectileDamage;
        UpdateVelocity(angle, speed);
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
        return Vector2.Angle(Vector2.right, myRigidbody.velocity);
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
