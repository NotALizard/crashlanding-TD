using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public Transform crosshair;
    public Transform aim;
    public Transform pivot;
    public Transform player;
    public Transform leftArm;
    public Transform rightArm;
    public Transform middle;
    public Transform rightShoulder;
    public Transform rightHand;
    public Transform bulletSpawn;
    public Transform bulletLine;
    public GameObject bulletFab;
    Player playerScript;
    Vector2 radius;
    bool facingRight = true;
    float hyp;
    float leg;
    float w;
    float h;
    float angleLeft;
    float angleGun;
    float angleRight;
    float rightLength;

    void Start () {
        leg = Mathf.Abs((aim.position - pivot.position).magnitude);
        rightLength = Mathf.Abs((rightHand.position - rightShoulder.position).magnitude);
        playerScript = player.GetComponent<Player>();
    }
	
	void Update () {
        //Left Arm
        hyp = Mathf.Abs((crosshair.position - middle.position).magnitude);   // Calculate the angle to set the arm
        w = crosshair.position.x - middle.position.x;
        h = crosshair.position.y - middle.position.y;

        //Turn the player if they are looking the wrong way
        if (w < 0 && facingRight)
        {
            playerScript.Flip();
            facingRight = false;
        }
        if (w > 0 && !facingRight)
        {
            playerScript.Flip();
            facingRight = true;
        }

        angleLeft = Mathf.Atan(h / w);
        angleLeft = 4 * (angleLeft * Mathf.Rad2Deg) / 4;


        if ((h < 0 && facingRight) || (h > 0 && !facingRight))
            angleLeft = 360 - angleLeft;
        leftArm.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angleLeft);

        //Gun 
        hyp = Mathf.Abs((crosshair.position - pivot.position).magnitude);
        w = crosshair.position.x - pivot.position.x;
        h = crosshair.position.y - pivot.position.y;

        angleGun = Mathf.Atan(Mathf.Abs(h) / Mathf.Abs(w));
        angleGun = (180 * angleGun / Mathf.PI);
        if ((facingRight && w < 0) || (!facingRight && w > 0))  //Fix for special case of pointing straight up or down when crosshair is really close to player
            angleGun = 90 + (90 - angleGun);

        if (h > 0)
            angleGun = angleGun - angleLeft;
        if (h < 0)
            angleGun = -angleGun - angleLeft;

        this.transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angleGun);

        //Right Arm
        hyp = Mathf.Abs((rightHand.position - rightShoulder.position).magnitude);
        radius = rightHand.position - rightShoulder.position;
        w = rightHand.position.x - rightShoulder.position.x;
        h = rightHand.position.y - rightShoulder.position.y;

        angleRight = Vector2.Angle(radius, new Vector2(0, -1));
        if ((facingRight && w < 0) || (!facingRight && w > 0))  //Fix for special case of pointing straight up or down when crosshair is really close to player
            angleRight = 180 + (180 - angleRight);


        rightArm.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angleRight + 3.64f);
        hyp = Mathf.Abs((rightHand.position - rightShoulder.position).magnitude);
        rightArm.localScale = new Vector3(1, hyp / rightLength, 1);

    }

    public void Fire(int num, float spread, int dmg){
        Bullet script;
        float tempAngle = Vector2.Angle(new Vector2(bulletSpawn.position.x - bulletLine.position.x, bulletSpawn.position.y - bulletLine.position.y), new Vector2(1, 0));
        if (bulletSpawn.position.y < bulletLine.position.y)
            tempAngle = 360 - tempAngle;
        for (int i = 0; i < num; i++)
        {
            script = ((GameObject)Instantiate(bulletFab, bulletSpawn.position, transform.rotation)).GetComponent<Bullet>();
            script.SetAngle(Random.Range(0, spread) - (spread / 2) + tempAngle);
            script.SetDamage(dmg);
            script.UpdateVelocity();
        }
    }
}
