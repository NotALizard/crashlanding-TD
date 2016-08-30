using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {
    protected int damage;

    public abstract void Init(float angle, int projectileDamage, float speed);

    public int GetDamage()
    {
        return damage;
    }

}
