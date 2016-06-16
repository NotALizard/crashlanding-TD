using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
    protected float maxHealth;
    protected float health;

    public void Hurt(float dam)
    {
        health = health - dam;
        if (health <= 0)
            Kill();
    }

    private void Kill()
    {
        //soon
    }
}
