using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


    public GameObject currentCheckpoint;
    public GameObject deathParticle;
    private Player player;
    public float respawnDelay;
    public int pointDropOnDeath;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {

        Instantiate(deathParticle, player.transform.position, player.transform.rotation );
        player.enabled = false;
        ScoreManager.AddPoints(-pointDropOnDeath);
        player.GetComponent<Renderer>().enabled = false;
        Debug.Log("respawn player");
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;


    }
}
