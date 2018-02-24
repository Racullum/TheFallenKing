using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSystem : MonoBehaviour {


    private PlayerController player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(player.getNumKeys() == 3)
        {
            if(SceneManager.GetActiveScene().buildIndex < 6)
            {
                PlayerPrefs.SetString(("Level" + (SceneManager.GetActiveScene().buildIndex + 1).ToString() + "Unlocked"), "yes");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
