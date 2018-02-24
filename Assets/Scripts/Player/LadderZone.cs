using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour {
    private PlayerController player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if(collision.name == "Player")
        {
            Debug.Log("Player is on Ladder");
            player.onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            player.onLadder = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
