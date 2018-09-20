using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;
    public static int playerHealth;
  

    Text text;

    private static LevelManager levelManager;

	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {


        if(playerHealth <=0 )
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel("Menu");
#pragma warning restore CS0618 // Type or member is obsolete
        }

        text.text = "" + playerHealth;
	}

    public static void HurtPlayer(int damageToGive)
    {
       
            playerHealth -= damageToGive;
 
            levelManager.RespawnPlayer();
  
    }


    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }

    public static void AddHealth(int healthToAdd)
    {
        playerHealth = playerHealth + healthToAdd;
    }

}
