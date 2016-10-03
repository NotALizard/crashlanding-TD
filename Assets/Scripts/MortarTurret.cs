using UnityEngine;
using System.Collections;

public class MortarTurret : Turret {

    private float gravScale = 4 * (9.81f);

    new void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        Init("mortar");
    }

    new void FixedUpdate()
    {
        if (Fire(Aim(FindUrgentEnemy())))
        {

        }
    }

    new bool Aim(GameObject enemy)
    {
        if (enemy != null)
        {
            Vector2 enemyPos = enemy.transform.position;
            Rigidbody2D enemyBody = enemy.gameObject.GetComponent<Rigidbody2D>();
            //First Calculation
            float xDist = enemyPos.x - this.transform.position.x;
            float yDist = enemyPos.y - this.transform.position.y;
            float rad = Mathf.Atan(((bulletSpeed * bulletSpeed) + Mathf.Sqrt(Mathf.Pow(bulletSpeed, 4) - gravScale * ((gravScale * xDist * xDist) + (2 * yDist * bulletSpeed * bulletSpeed)))) / (gravScale * Mathf.Abs(xDist)));
            //Second Calculation - Makes it easier to hit moving objects, placeholder until I can nail down the proper kinematics
            float time = Mathf.Abs(xDist / (bulletSpeed * Mathf.Cos(rad)));
            xDist = xDist + (time * enemyBody.velocity.x);
            //Uses the angle from the first calc to approximate the time spent in air and adjusts for target velocity
            rad = Mathf.Atan(((bulletSpeed * bulletSpeed) + Mathf.Sqrt(Mathf.Pow(bulletSpeed, 4) - gravScale * ((gravScale * xDist * xDist) + (2 * yDist * bulletSpeed * bulletSpeed)))) / (gravScale * Mathf.Abs(xDist)));
            Debug.Log(xDist);
            if (xDist >= 0)
                transform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * rad);
            else
                transform.localRotation = Quaternion.Euler(0, 0, 180 - Mathf.Rad2Deg * rad);
            return true;
        }
        return false;
    }
}
