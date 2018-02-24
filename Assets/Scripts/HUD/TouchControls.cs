using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {


    private PlayerController thePlayer;
    private ChestController theChest;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theChest = FindObjectOfType<ChestController>();
	}

    public void jump()
    {
        thePlayer.jump();
    }

    public void AButton()
    {
       // theChest.anim.SetBool("isOpened", true);
        thePlayer.openChest();
    }
    public void leftArrow()
    {
        thePlayer.moveLeft();
    }

    public void rightArrow()
    {
        thePlayer.moveRight();
    }

    public void upArrow()
    {
        thePlayer.moveUp();
    }

    public void downArrow()
    {
        thePlayer.moveDown();
    }

    public void unpressedArrow()
    {
        thePlayer.stopMovement();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
