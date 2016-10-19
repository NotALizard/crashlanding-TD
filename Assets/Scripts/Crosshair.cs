using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
    public Transform mainCamera;
    private float size;

    void Start()
    {
        size = mainCamera.GetComponent<Camera>().orthographicSize * 2;
    }
	
	void Update () {
        this.transform.position = new Vector3(size * (Input.mousePosition.x - (Screen.width / 2)) / Screen.height + mainCamera.position.x, size * (Input.mousePosition.y - (Screen.height / 2)) / Screen.height + mainCamera.position.y, 0);
	}

    public Vector3 getPos()
    {
        return this.transform.position;
    }
}
