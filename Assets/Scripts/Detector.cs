using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {
    private Building selection;

    //Scan for buildings behind the player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Scaffold") || collider.CompareTag("Building"))
        {
        selection = collider.GetComponent<Building>();
        }
    }

    //If the player walks away from a building and it is still selected, clear the selection
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.GetComponent<Building>() == selection)
        {
            selection = null;
        }
    }

    public Building GetSelection() { return selection; }
	
}
