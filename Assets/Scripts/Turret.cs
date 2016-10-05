using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    public GameObject ammoFab;
    protected GameObject target;
    protected Animator anim;
    protected Bar bar;
    protected float maxRange;
    protected float damage;
    protected float inaccuracy;
    protected float fireDelay;
    protected float bulletSpeed;
    protected float lastShot;
    protected bool idling;

    public void Init(string type)
    {
        if (type.Equals("basic"))
        {
            maxRange = Constants.TurretBasicRange;
            fireDelay = Constants.TurretBasicRate;
            bulletSpeed = Constants.TurretBasicBulletSpd;
            inaccuracy = Constants.TurretBasicInacc;
            damage = Constants.TurretBasicDmg;
        }
        else if (type.Equals("rapid"))
        {
            maxRange = Constants.TurretRapidRange;
            fireDelay = Constants.TurretRapidRate;
            bulletSpeed = Constants.TurretRapidBulletSpd;
            inaccuracy = Constants.TurretRapidInacc;
            damage = Constants.TurretRapidDmg;
        }
        else if (type.Equals("laser"))
        {
            maxRange = Constants.TurretLaserRange;
            fireDelay = Constants.TurretLaserRate;
            bulletSpeed = Constants.TurretLaserBulletSpd;
            inaccuracy = Constants.TurretLaserInacc;
            damage = Constants.TurretLaserDmg;
        }
        else if (type.Equals("mortar"))
        {
            maxRange = Constants.TurretMortarRange;
            fireDelay = Constants.TurretMortarRate;
            bulletSpeed = Constants.TurretMortarBulletSpd;
            inaccuracy = Constants.TurretMortarInacc;
            damage = Constants.TurretMortarDmg;
        }
        lastShot = Time.time;
        anim = gameObject.GetComponent<Animator>();
        if (transform.FindChild("Bar") != null)
            bar = transform.FindChild("Bar").GetComponent<Bar>();

    }

    protected void FixedUpdate()
    {
        Fire(Aim(FindUrgentEnemy()));
        if (bar != null)
        {
            bar.UpdateBar(Mathf.Min((Time.time - lastShot) / fireDelay, 1));
        }
    }

    protected bool Aim(GameObject enemy)
    {
        if (enemy != null)
        {
            Vector2 enemyPos = enemy.transform.position;
            transform.localRotation = Quaternion.Euler(0, 0, -Vector2.Angle(Vector2.right, enemyPos - new Vector2(transform.position.x, transform.position.y)));
            return true;
        }
        return false;
    }
    
    protected bool Fire(bool hasTarget)
    {
        if(Time.time - lastShot >= fireDelay && hasTarget)
        {
            GameObject projectile = (GameObject)GameObject.Instantiate(ammoFab, transform.FindChild("BulletPos").position, transform.localRotation);
            projectile.GetComponent<Projectile>().Init(transform.eulerAngles.z + Random.Range(0, inaccuracy) - (inaccuracy / 2), damage, bulletSpeed);
            lastShot = Time.time;
            if(anim != null)
            {
                anim.SetBool("idle", false);
                idling = false;
                anim.Play("fire");
            }
            return true;
        }
        if (anim != null && !hasTarget && !idling)
        {
            idling = true;
            anim.SetBool("idle", true);
        }
        return false;
    }
	

    protected GameObject FindUrgentEnemy()
    {
        GameObject bestTarget = null;
        float distanceFromLeft = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in enemies)
        {
            if(Mathf.Abs(Vector2.Distance(this.transform.position, e.transform.position)) <= maxRange && e.transform.position.x < distanceFromLeft)
            {
                bestTarget = e;
                distanceFromLeft = bestTarget.transform.position.x;
            }
        }
        return bestTarget;
    }
}
