using UnityEngine;
using System.Collections.Generic;

public class Splash : MonoBehaviour {

    List<Collider2D> targets = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (!targets.Contains(collider))
            {
                targets.Add(collider);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (targets.Contains(collider))
            {
                targets.Remove(collider);
            }
        }
    }

    public List<Collider2D> GetTargets()
    {
        return targets;
    }
}
