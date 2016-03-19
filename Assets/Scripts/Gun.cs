using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public Transform crosshair;
    public Transform aim;
    public Transform pivot;
    public Transform player;
    bool facingRight = true;
    float hyp;
    float leg;
    float w;
    float h;
    float angle;

	void Start () {
        leg = Mathf.Abs((aim.position - pivot.position).magnitude );
	}
	

	void Update () {
        hyp = Mathf.Abs((crosshair.position - pivot.position).magnitude);
        w = crosshair.position.x - pivot.position.x;
        h = crosshair.position.y - pivot.position.y;
        angle = Mathf.Acos(leg / hyp) - Mathf.Atan(Mathf.Abs(w/ h)); //radians

        angle = 180 * angle / Mathf.PI; //degrees

        
        if (h > 0)
            this.transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angle);
        if (h < 0)
            this.transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, 360 - angle);


        //Turn the player if they are looking the wrong way
        if(w < 0 && facingRight)
        {
            player.localRotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }
        if (w > 0 && !facingRight)
        {
            player.localRotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
    }
}
