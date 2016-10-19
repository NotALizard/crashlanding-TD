using UnityEngine;
using System.Collections;

public class Bullet : Projectile {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ProjectileDestroy") || collider.CompareTag("Ground"))
            Destroy(this.gameObject);
        else if (collider.CompareTag("Enemy"))
            Attack(collider.GetComponent<Enemy>());
        else if (collider.CompareTag("Refract"))
        {
            GameObject c1 = (GameObject)Object.Instantiate(this.gameObject);
            c1.GetComponent<Projectile>().Init(GetAngle() + 5, GetDamage(), GetSpeed());
            GameObject c2 = (GameObject)Object.Instantiate(this.gameObject);
            c2.GetComponent<Projectile>().Init(GetAngle() - 5, GetDamage(), GetSpeed());
        }
    }

    private void Attack(Enemy enemy)
    {
        enemy.Hurt(damage);
        Destroy(this.gameObject);
    }

}
