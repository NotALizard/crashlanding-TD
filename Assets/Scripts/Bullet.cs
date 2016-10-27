using UnityEngine;
using System.Collections;

public class Bullet : Projectile {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ProjectileDestroy") || collider.CompareTag("Ground"))
            Destroy(this.gameObject);
        else if (collider.CompareTag("Enemy"))
            Attack(collider.GetComponent<Enemy>());
        else if (!cloned && collider.CompareTag("Refract"))
        {
            makeClones();
        }
    }

    private void Attack(Enemy enemy)
    {
        enemy.Hurt(damage);
        Destroy(this.gameObject);
    }

}
