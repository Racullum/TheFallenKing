using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

    private PlayerController thePlayer;
    public Animator anim;
    public int num_keys = 1;
    private AudioSource key_sound;
	// Use this for initialization
	void Start () {
        key_sound = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        thePlayer = FindObjectOfType<PlayerController>();
	}

    public void decrementKeys()
    {
        num_keys--;
        key_sound.Play();
        anim.SetBool("isOpened", true);
        if(num_keys == 0)
        {
            thePlayer.can_open_chest = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(num_keys > 0)
        {
            thePlayer.chest = this.gameObject;
            thePlayer.can_open_chest = true;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        thePlayer.can_open_chest = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
