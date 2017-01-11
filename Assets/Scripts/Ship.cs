using UnityEngine;
using System.Collections;

public class Ship : Building {

    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        transform.FindChild("GunA").GetComponent<Turret>().Init("basic");
        transform.FindChild("GunB").GetComponent<Turret>().Init("basic");
    }

    new public void Hurt(float dam)
    {
        health = health - dam;
        //if (health <= 0)
    }

}
