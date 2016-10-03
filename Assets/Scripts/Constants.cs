using UnityEngine;
using System.Collections;

public static class Constants{
    //Turret Balance
    //Basic Turret
    public const float TurretBasicDmg = 2;
    public const float TurretBasicBulletSpd = 15;
    public const float TurretBasicRange = 25;
    public const float TurretBasicInacc = 0;
    public const float TurretBasicRate = 1;
    public static GameObject TurretBasicProj = (GameObject)Resources.Load("Prefabs/BulletFab", typeof(GameObject));
    //Mortar Turret
    public const float TurretMortarDmg = 20;
    public const float TurretMortarBulletSpd = 20;
    public const float TurretMortarRange = 25;
    public const float TurretMortarInacc = 0;
    public const float TurretMortarRate = 1;
    public static GameObject TurretMortarProj = (GameObject)Resources.Load("Prefabs/BombFab", typeof(GameObject));

    //Building Assets
    public static GameObject TurretBasicFab = (GameObject)Resources.Load("Prefabs/TurretBasicFab", typeof(GameObject));
    public static GameObject TurretMortarFab = (GameObject)Resources.Load("Prefabs/TurretMortarFab", typeof(GameObject));
}
