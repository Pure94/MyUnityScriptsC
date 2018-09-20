using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

    public int jumpPadStrenght;


    private static Player player; 

    private void OnTriggerEnter2D(Collider2D collision)
    {

        player = FindObjectOfType<Player>();
        if (collision.GetComponent<Player>() == null)
        {
            return;

        }

        player.JumpPad(jumpPadStrenght);

    }
}
