using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {


    private bool playerInZone;
    public string levelToLoad;

	// Use this for initialization
	void Start () {
        playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W) && playerInZone)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel(levelToLoad);
#pragma warning restore CS0618 // Type or member is obsolete
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }
}
