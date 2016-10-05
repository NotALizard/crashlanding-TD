using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {

	public void UpdateBar(float ratio)
    {
        transform.localScale = new Vector3(10 * ratio, transform.localScale.y, transform.localScale.z);
    }
}
