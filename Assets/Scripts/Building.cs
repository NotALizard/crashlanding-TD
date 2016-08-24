using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
    protected float maxHealth;
    protected float health;

    //Upgrades
    public delegate int BuildDel(Building b);
    public BuildDel leftOpt;
    public BuildDel topOpt;
    public BuildDel rightOpt;
    public BuildDel sellOpt;



    private int[] upgradeCosts = new int[4];

    public void Init(float maxHP, string sprite)
    {

    }

    public void Hurt(float dam)
    {
        health = health - dam;
        if (health <= 0)
            Kill();
    }

    private void Kill()
    {
        sellOpt(this);
    }

    public void SetCosts(int left, int top, int right, int sell)
    {
        upgradeCosts = new int[4]{left, top, right, sell};
    }

    public int[] GetCosts() { return upgradeCosts; }

    

}
