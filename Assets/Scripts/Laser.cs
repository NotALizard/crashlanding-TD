using UnityEngine;
using System.Collections;

public class Laser : Projectile {
    private int uses = Constants.LaserUses;

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
        enemy.Stun(Constants.LaserStunPower, Constants.LaserStunDuration);
        enemy.Hurt(damage);
        if(--uses < 1)
            Destroy(this.gameObject);
    }
}
