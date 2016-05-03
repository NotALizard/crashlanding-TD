using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    float speed = 20;
    float angle;
    public int damage;
    Rigidbody2D myRigidbody;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ProjectileDestroy"))
            Destroy(this.gameObject);
    }

	public void UpdateVelocity () {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = new Vector2(speed * Mathf.Cos(Mathf.Deg2Rad * angle), speed * Mathf.Sin(Mathf.Deg2Rad * angle));
	}

    public void SetDamage(int dam)
    {
        damage = dam;
    }

    public void SetAngle(float ang)
    {
        angle = ang;
    }

    public int GetDamage()
    {
        return damage;
    }
}
