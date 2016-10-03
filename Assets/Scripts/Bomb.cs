using UnityEngine;
using System.Collections.Generic;

public class Bomb : Projectile
{
    Splash splash;

    void Start()
    {
        splash = transform.FindChild("Splash").GetComponent<Splash>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ProjectileDestroy"))
            Destroy(this.gameObject);
        else if (collider.CompareTag("Ground"))
            Attack();
    }

    private void Attack()
    {
        List<Collider2D> targets = splash.GetTargets();
        Debug.Log(targets.Count);
        foreach (Collider2D t in targets)
        {
            float dist = Vector2.Distance(transform.position, t.transform.position);
            //Damage is between 50% and 100%, falloff ends at 50% at 2 meters and ramps up to 100% at the center
            float dam = Mathf.Max(damage / 2, Mathf.Min(damage, damage / dist));
            t.gameObject.GetComponent<Enemy>().Hurt(dam);
        }
        Destroy(this.gameObject);
    }




}
