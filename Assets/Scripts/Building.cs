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
    protected int[] upgradeCosts = new int[4];
    protected int[] upgradeIcons = new int[4];
    protected int[] minTechLevels = new int[3];

    //Status
    protected float maxHealth;
    protected float health;
    private bool hasRoof;
    private int height = 0;
    private GameObject activeObject;


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
            sellOpt(this);
    }

    public void SetCosts(int left, int top, int right, int bottom)
    {
        upgradeCosts = new int[4]{left, top, right, bottom};
    }

    public int[] GetCosts() { return upgradeCosts; }

    public void SetIcons(int left, int top, int right, int bottom)
    {
        upgradeIcons = new int[4] { left, top, right, bottom};
    }

    public int[] GetIcons() { return upgradeIcons; }

    public void SetTechLevels(int left, int top, int right)
    {
        minTechLevels = new int[3] { left, top, right};
    }

    public int[] GetTechLevels() { return minTechLevels; }

    public int Refund() { return upgradeCosts[3]; }

    public GameObject GetActiveObj() { return activeObject; }
    
    public void SetActiveObj(GameObject obj)
    {
        activeObject = obj;
    }

    public int GetHeight()
    {
        return height;
    }

    public void SetHeight(int h)
    {
        height = h;
    }

    public bool HasRoof()
    {
        return hasRoof;
    }

    public void SetRoof(bool b)
    {
        hasRoof = b;
    }

}
