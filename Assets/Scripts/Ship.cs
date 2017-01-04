using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

    //Components
    Animator anim;

    //Upgrades
    public delegate int BuildDel(Building b);
    public BuildDel leftOpt;
    public BuildDel topOpt;
    public BuildDel rightOpt;
    public BuildDel sellOpt;
    private int[] upgradeCosts = new int[4];
    private int[] upgradeIcons = new int[4];
    private int[] minTechLevels = new int[3];

    //Status
    private float maxHealth;
    private float health;


    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        transform.FindChild("GunA").GetComponent<Turret>().Init("basic");
        transform.FindChild("GunB").GetComponent<Turret>().Init("basic");
    }

    public void Hurt(float dam)
    {
        health = health - dam;
        //if (health <= 0)
    }

    public void SetCosts(int left, int top, int right, int bottom)
    {
        upgradeCosts = new int[4] { left, top, right, bottom };
    }

    public int[] GetCosts() { return upgradeCosts; }

    public void SetIcons(int left, int top, int right, int bottom)
    {
        upgradeIcons = new int[4] { left, top, right, bottom };
    }

    public int[] GetIcons() { return upgradeIcons; }

    public void SetTechLevels(int left, int top, int right)
    {
        minTechLevels = new int[3] { left, top, right };
    }

    public int[] GetTechLevels() { return minTechLevels; }

}
