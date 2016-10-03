using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

    //CONSTANTS - BUILDING COSTS
    public const int ScaffoldCost = 20;
    public const int BasicTurretCost = 100;
    public const int BasicWallCost = 100;
    public const int BasicGenCost = 100;
    public const int RapidTurretCost = 150;
    public const int MortarTurretCost = 175;
    public const int LaserTurretCost = 200;
    public const int HeavyWallCost = 150;
    public const int ReflectWallCost = 175;
    public const int RefractWallCost = 200;
    public const int NecroGenCost = 150;
    public const int RepairGenCost = 175;
    public const int BuffGenCost = 200;
    public const float RefundRatio = 0.6f;
    //BUILDING HEALTH
    const int BasicWallHealth = 300;
    const int BasicTurretHealth = 100;
    const int BasicGenHealth = 75;
    const int RapidTurretHealth = 150;
    const int MortarTurretHealth = 150;
    const int LaserTurretHealth = 150;
    const int HeavyWallHealth = 750;
    const int ReflectWallHealth = 450;
    const int RefractWallHealth = 300;
    const int NecroGenHealth = 200;
    const int RepairGenHealth = 100;
    const int BuffGenHealth = 150;
    //SPRITE ID
    public const int SellSprite = -1;
    public const int GhostSprite = 0;
    public const int ScaffoldSprite = 1;
    public const int BasicTurretSprite = 3;
    public const int RapidTurretSprite = 4;
    public const int MortarTurretSprite = 5;
    public const int LaserTurretSprite = 6;
    public const int BasicWallSprite = 7;
    public const int HeavyWallSprite = 8;
    public const int ReflectWallSprite = 9;
    public const int RefractWallSprite = 10;
    public const int BasicGenSprite = 11;
    public const int NecroGenSprite = 12;
    public const int RepairGenSprite = 13;
    public const int BuffGenSprite = 14;


    public static int Ghost(Building b)
    {
        b.Init(Mathf.Infinity, GhostSprite);
        b.SetCosts(0, ScaffoldCost, 0, 0);
        b.SetIcons(GhostSprite, ScaffoldSprite, GhostSprite, GhostSprite);
        b.SetTechLevels(0, 0, 0);
        b.leftOpt = null;
        b.topOpt = Scaffold;
        b.rightOpt = null;
        b.sellOpt = null;
        b.gameObject.tag = "Scaffold";
        return (0);
    }

    public static int Scaffold(Building b)
    {
        b.Init(Mathf.Infinity, ScaffoldSprite);
        b.SetCosts(BasicTurretCost, BasicGenCost, BasicWallCost, 0);
        b.SetIcons(BasicTurretSprite, BasicGenSprite, BasicWallSprite, GhostSprite);
        b.SetTechLevels(0, 0, 0);
        b.leftOpt = BasicTurret;
        b.topOpt = BasicGen;
        b.rightOpt = BasicWall;
        b.sellOpt = null;
        b.gameObject.tag = "Scaffold";
        return (ScaffoldCost);
    }

    public static int BasicTurret(Building b)
    {
        b.Init(BasicTurretHealth, BasicTurretSprite);
        b.SetCosts(RapidTurretCost, MortarTurretCost, LaserTurretCost, (int)(RefundRatio * BasicTurretCost));
        b.SetIcons(RapidTurretSprite, MortarTurretSprite, LaserTurretSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = RapidTurret;
        b.topOpt = MortarTurret;
        b.rightOpt = LaserTurret;
        b.sellOpt = Scaffold;
        b.gameObject.tag = "Building";
        SetActiveObj(b, (GameObject)Object.Instantiate(Constants.TurretBasicFab, b.transform.position, Quaternion.identity));
        return (BasicTurretCost);
    }

    public static int BasicGen(Building b)
    {
        b.Init(BasicGenHealth, BasicGenSprite);
        b.SetCosts(NecroGenCost, RepairGenCost, BuffGenCost, (int)(BasicGenCost * RefundRatio));
        b.SetIcons(NecroGenSprite, RepairGenSprite, BuffGenSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = NecroGen;
        b.topOpt = RepairGen;
        b.rightOpt = BuffGen;
        b.sellOpt = Scaffold;
        b.gameObject.tag = "Building";
        return (BasicGenCost);

    }

    public static int BasicWall(Building b)
    {
        b.Init(BasicWallHealth, BasicWallSprite);
        b.SetCosts(HeavyWallCost, ReflectWallCost, RefractWallCost, (int)(BasicWallCost * RefundRatio));
        b.SetIcons(HeavyWallSprite, ReflectWallSprite, RefractWallSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = HeavyWall;
        b.topOpt = ReflectWall;
        b.rightOpt = RefractWall;
        b.sellOpt = Scaffold;
        b.gameObject.tag = "Building";
        return (BasicWallCost);

    }

    public static int RapidTurret(Building b)
    {
        b.Init(RapidTurretHealth, RapidTurretSprite);
        b.SetCosts(0, 0, 0, (int)(RapidTurretCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicTurret;
        b.gameObject.tag = "Building";
        return (RapidTurretCost);
    }

    public static int MortarTurret(Building b)
    {
        b.Init(MortarTurretHealth, MortarTurretSprite);
        b.SetCosts(0, 0, 0, (int)(MortarTurretCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicTurret;
        b.gameObject.tag = "Building";
        return (MortarTurretCost);
    }

    public static int LaserTurret(Building b)
    {
        b.Init(LaserTurretHealth, LaserTurretSprite);
        b.SetCosts(0, 0, 0, (int)(LaserTurretCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicTurret;
        b.gameObject.tag = "Building";
        return (LaserTurretCost);
    }

    public static int NecroGen(Building b)
    {
        b.Init(BasicTurretHealth, NecroGenSprite);
        b.SetCosts(0, 0, 0, (int)(NecroGenCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicGen;
        b.gameObject.tag = "Building";
        return (NecroGenCost);
    }

    public static int RepairGen(Building b)
    {
        b.Init(BasicTurretHealth, RepairGenSprite);
        b.SetCosts(0, 0, 0, (int)(RepairGenCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicGen;
        b.gameObject.tag = "Building";
        return (RepairGenCost);
    }

    public static int BuffGen(Building b)
    {
        b.Init(BasicTurretHealth, BuffGenSprite);
        b.SetCosts(0, 0, 0, (int)(BuffGenCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicGen;
        b.gameObject.tag = "Building";
        return (BuffGenCost);
    }

    public static int HeavyWall(Building b)
    {
        b.Init(BasicTurretHealth, HeavyWallSprite);
        b.SetCosts(0, 0, 0, (int)(HeavyWallCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicWall;
        b.gameObject.tag = "Building";
        return (HeavyWallCost);
    }

    public static int ReflectWall(Building b)
    {
        b.Init(BasicTurretHealth, ReflectWallSprite);
        b.SetCosts(0, 0, 0, (int)(ReflectWallCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicWall;
        b.gameObject.tag = "Building";
        return (ReflectWallCost);
    }

    public static int RefractWall(Building b)
    {
        b.Init(BasicTurretHealth, RefractWallSprite);
        b.SetCosts(0, 0, 0, (int)(RefractWallCost * RefundRatio));
        b.SetIcons(GhostSprite, GhostSprite, GhostSprite, SellSprite);
        b.SetTechLevels(1, 2, 3);
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicWall;
        b.gameObject.tag = "Building";
        return (RefractWallCost);
    }

    private static void SetActiveObj(Building b, GameObject gobj)
    {
        if (b.GetActiveObj() != null)
        {
            Destroy(b.GetActiveObj());
        }
        b.SetActiveObj(gobj);
        gobj.transform.parent = b.transform;
    }



}
