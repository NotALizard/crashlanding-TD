using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {


    //Variables
    public GameObject ammoFab;
    protected GameObject target;
    protected float maxRange;
    protected float damage;
    protected float inaccuracy;
    protected float fireDelay;
    protected float bulletSpeed;
    protected float lastShot;

    protected void Awake()
    {
        Init(0, 0, 0, 0, 0);
    }

    public void Init(float delay, float inacc, float dam, float range, float spd)
    {
        /*maxRange = range;
        fireDelay = delay;
        bulletSpeed = spd;
        fireDelay = delay;
        inaccuracy = inacc;
        damage = dam;*/
        maxRange = Constants.TurretBasicRange;
        fireDelay = Constants.TurretBasicRate;
        bulletSpeed = Constants.TurretBasicBulletSpd;
        inaccuracy = Constants.TurretBasicInacc;
        damage = Constants.TurretBasicDmg;
        lastShot = Time.time;
    }

    protected void FixedUpdate()
    {
        Fire(Aim(FindUrgentEnemy()));
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
            projectile.GetComponent<Projectile>().Init(transform.eulerAngles.z, 10, bulletSpeed);
            lastShot = Time.time;
            return true;
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
