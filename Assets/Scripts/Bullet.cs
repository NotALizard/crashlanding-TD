using UnityEngine;
using System.Collections;

public class Bullet : Projectile {
    Rigidbody2D myRigidbody;

    public override void Init(float angle, int projectileDamage, float speed)
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ProjectileDestroy"))
            Destroy(this.gameObject);
        else if (collider.CompareTag("Enemy"))
            Attack(collider.GetComponent<Enemy>());
    }

    private void Attack(Enemy enemy)
    {
        enemy.Hurt(damage);
        Destroy(this.gameObject);
    }

    

    
}
