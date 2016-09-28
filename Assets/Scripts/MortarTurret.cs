using UnityEngine;
using System.Collections;

public class MortarTurret : Turret {

    new void FixedUpdate()
    {
        Fire(Aim(FindUrgentEnemy()));
    }

    new bool Aim(GameObject enemy)
    {
        if (enemy != null)
        {
            Vector2 enemyPos = enemy.transform.position;
            Debug.Log(Mathf.Rad2Deg * Mathf.Atan(1 - (4 * (enemyPos.x - this.transform.position.x)) / (2 * bulletSpeed * bulletSpeed)));
            Debug.Log(enemyPos.x - this.transform.position.x);
            transform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan(1 - (30 * (enemyPos.x - this.transform.position.x))/(2 * Mathf.Pow(bulletSpeed, 2)))); // theta = arctan( 1 - ax/2(v^2))
            return true;
        }
        return false;
    }
}
