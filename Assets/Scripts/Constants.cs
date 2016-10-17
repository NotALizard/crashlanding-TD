using UnityEngine;
using System.Collections;

public static class Constants{
    //Turret Balance
    //Basic Turret
    public const float TurretBasicDmg = 10;
    public const float TurretBasicBulletSpd = 15;
    public const float TurretBasicRange = 25;
    public const float TurretBasicInacc = 0;
    public const float TurretBasicRate = 1;
    public static GameObject TurretBasicProj = (GameObject)Resources.Load("Prefabs/BulletFab", typeof(GameObject));
    //Rapid Turret
    public const float TurretRapidDmg = 3;
    public const float TurretRapidBulletSpd = 15;
    public const float TurretRapidRange = 25;
    public const float TurretRapidInacc = 8;
    public const float TurretRapidRate = 0.2f;
    public static GameObject TurretRapidProj = (GameObject)Resources.Load("Prefabs/BulletFab", typeof(GameObject));
    //Laser Turret
    public const int LaserUses = 3;
    public const float LaserStunDuration = 2;
    public const float LaserStunPower = 2;
    public const float TurretLaserDmg = 3;
    public const float TurretLaserBulletSpd = 15;
    public const float TurretLaserRange = 25;
    public const float TurretLaserInacc = 0;
    public const float TurretLaserRate = 5;
    public static GameObject TurretLaserProj = (GameObject)Resources.Load("Prefabs/LaserFab", typeof(GameObject));
    //Mortar Turret
    public const float TurretMortarDmg = 30;
    public const float TurretMortarBulletSpd = 20;
    public const float TurretMortarRange = 25;
    public const float TurretMortarInacc = 0;
    public const float TurretMortarRate = 3;
    public static GameObject TurretMortarProj = (GameObject)Resources.Load("Prefabs/BombFab", typeof(GameObject));

    //Building Assets
    public static GameObject GhostFab = (GameObject)Resources.Load("Prefabs/ScaffoldFab", typeof(GameObject));
    public static GameObject TurretBasicFab = (GameObject)Resources.Load("Prefabs/TurretBasicFab", typeof(GameObject));
    public static GameObject TurretMortarFab = (GameObject)Resources.Load("Prefabs/TurretMortarFab", typeof(GameObject));
    public static GameObject TurretRapidFab = (GameObject)Resources.Load("Prefabs/TurretRapidFab", typeof(GameObject));
    public static GameObject TurretLaserFab = (GameObject)Resources.Load("Prefabs/TurretLaserFab", typeof(GameObject));
}
