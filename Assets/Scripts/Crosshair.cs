using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
    public Transform mainCamera;
	
	void Update () {
        this.transform.position = new Vector3(10 * (Input.mousePosition.x - (Screen.width / 2)) / Screen.height + mainCamera.position.x, 10 * (Input.mousePosition.y - (Screen.height / 2)) / Screen.height + mainCamera.position.y, 0);
	}

    public Vector3 getPos()
    {
        return this.transform.position;
    }
}
