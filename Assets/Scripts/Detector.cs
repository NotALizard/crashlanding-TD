using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {
    private Building selection;

    //Scan for buildings behind the player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Scaffold") || collider.CompareTag("Building"))
        {
            Debug.Log("set");
            selection = collider.GetComponent<Building>();
        }
    }

    //If the player walks away from a building and it is still selected, clear the selection
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.GetComponent<Building>() == selection)
        {
            Debug.Log("cleared");
            selection = null;
        }
    }

    public Building GetSelection() { return selection; }

    public void SetSelection(Building s) { selection = s; }
	
}
