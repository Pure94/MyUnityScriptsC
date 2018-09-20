using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    public int healthToAdd;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == null)
        {
            return;

        }

        HealthManager.AddHealth(healthToAdd);
        Destroy(gameObject);

    }
}