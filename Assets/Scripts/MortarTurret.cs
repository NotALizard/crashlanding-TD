using UnityEngine;
using System.Collections;

public class MortarTurret : Turret {

    private float gravScale = 4 * (9.81f);

    new void Awake()
    {
        Init(0, 0, 0, 0, 0);
    }

    new void Init(float delay, float inacc, float dam, float range, float spd)
    {
        /*maxRange = range;
        fireDelay = delay;
        bulletSpeed = spd;
        fireDelay = delay;
        inaccuracy = inacc;
        damage = dam;*/
        maxRange = Constants.TurretMortarRange;
        fireDelay = Constants.TurretMortarRate;
        bulletSpeed = Constants.TurretMortarBulletSpd;
        inaccuracy = Constants.TurretMortarInacc;
        damage = Constants.TurretMortarDmg;
        lastShot = Time.time;
    }

    new void FixedUpdate()
    {
        Fire(Aim(FindUrgentEnemy()));
    }

    new bool Aim(GameObject enemy)
    {
        if (enemy != null)
        {
            Vector2 enemyPos = enemy.transform.position;
            float xDist = enemyPos.x - this.transform.position.x;
            float yDist = enemyPos.y - this.transform.position.y;
            float form = ((bulletSpeed * bulletSpeed) + Mathf.Sqrt(Mathf.Pow(bulletSpeed, 4) - gravScale * ((gravScale * Mathf.Abs(xDist * xDist)) + (2 * yDist * bulletSpeed * bulletSpeed)))) / (gravScale * Mathf.Abs(xDist));
            Debug.Log(Mathf.Rad2Deg * Mathf.Atan(form));
            transform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan(form));
            return true;
        }
        return false;
    }
}
