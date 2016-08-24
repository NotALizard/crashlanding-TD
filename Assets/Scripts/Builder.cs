using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

    //#### CONSTANTS - BUILDING COSTS ####
    const int ScaffoldCost = 20;
    const int BasicWallCost = 100;
    const int BasicTurretCost = 100;
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
    //#####################################




    public static int Scaffold(Building b)
    {
        b.Init(Mathf.Infinity, "scaffold");
        b.leftOpt = BasicGun;
        b.topOpt = BasicGen;
        b.rightOpt = BasicWall;
        b.sellOpt = null;
        b.gameObject.tag = "Scaffold";

        return (ScaffoldCost);
    }

    public static int BasicWall(Building b)
    {


    }

    public static int BasicGun(Building b)
    {

    }

    public static int BasicGen(Building b)
    {

    }
    
}
