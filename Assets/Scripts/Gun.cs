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
    }
	

	void Update () {
        //Left Arm
        hyp = Mathf.Abs((crosshair.position - middle.position).magnitude);   // Calculate the angle to set the arm
        w = crosshair.position.x - middle.position.x;
        h = crosshair.position.y - middle.position.y;

        //Turn the player if they are looking the wrong way
        if (w < 0 && facingRight)
        {
            player.localRotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }
        if (w > 0 && !facingRight)
        {
            player.localRotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }

        angleLeft = Mathf.Atan(h / w);
        angleLeft = 3 * (180 * angleLeft / Mathf.PI) / 4;


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

        //angleRight = Mathf.Atan(Mathf.Abs(h) / Mathf.Abs(w));
        //angleRight = (180 * angleRight / Mathf.PI);
        angleRight = Vector2.Angle(radius, new Vector2(0, -1));
        Debug.Log(angleRight);

        rightArm.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angleRight);
    }
}
