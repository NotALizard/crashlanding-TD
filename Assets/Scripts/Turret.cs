using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
    protected float maxRange = 25;
    protected GameObject target;

    protected void Aim(Vector2 enemyPos)
    {
        //todo
    }
	

    GameObject FindUrgentEnemy()
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
