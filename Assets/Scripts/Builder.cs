using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

    //CONSTANTS - BUILDING COSTS
    const int ScaffoldCost = 20;
    const int BasicTurretCost = 100;
    const int BasicWallCost = 100;
    const int BasicGenCost = 100;
    const int RapidTurretCost = 150;
    const int MortarTurretCost = 175;
    const int LaserTurretCost = 200;
    const int HeavyWallCost = 150;
    const int ReflectWallCost = 175;
    const int RefractWallCost = 200;
    const int NecroGenCost = 150;
    const int RepairGenCost = 175;
    const int BuffGenCost = 200;
    const float RefundRatio = 3 / 5;
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
    const int GhostSprite = 0;
    const int ScaffoldSprite = 1;
    const int BasicTurretSprite = 3;
    const int RapidTurretSprite = 4;
    const int MortarTurretSprite = 5;
    const int LaserTurretSprite = 6;
    const int BasicWallSprite = 7;
    const int HeavyWallSprite = 8;
    const int ReflectWallSprite = 9;
    const int RefractWallSprite = 10;
    const int BasicGenSprite = 11;
    const int NecroGenSprite = 12;
    const int RepairGenSprite = 13;
    const int BuffGenSprite = 14;


    public static int Ghost(Building b)
    {
        b.Init(Mathf.Infinity, GhostSprite);
        b.SetCosts(0, ScaffoldCost, 0, 0);
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
        b.SetCosts(RapidTurretCost, MortarTurretCost, LaserTurretCost, (int)(BasicTurretCost * RefundRatio));
        b.leftOpt = RapidTurret;
        b.topOpt = MortarTurret;
        b.rightOpt = LaserTurret;
        b.sellOpt = Scaffold;
        b.gameObject.tag = "Building";
        return (BasicTurretCost);
    }

    public static int BasicGen(Building b)
    {
        b.Init(BasicGenHealth, BasicGenSprite);
        b.SetCosts(NecroGenCost, RepairGenCost, BuffGenCost, (int)(BasicGenCost * RefundRatio));
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
        b.leftOpt = null;
        b.topOpt = null;
        b.rightOpt = null;
        b.sellOpt = BasicWall;
        b.gameObject.tag = "Building";
        return (RefractWallCost);
    }



}
