using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    //Components
    Animator anim;

    //Upgrades
    public delegate int BuildDel(Building b);
    public BuildDel leftOpt;
    public BuildDel topOpt;
    public BuildDel rightOpt;
    public BuildDel sellOpt;

    //Status
    protected float maxHealth;
    protected float health;
    private int[] upgradeCosts = new int[4];

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Builder.Ghost(this);
    }


    public void Init(float maxHP, int sprite)
    {
        maxHealth = maxHP;
        health = maxHealth;
        anim.SetInteger("id", sprite);
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
