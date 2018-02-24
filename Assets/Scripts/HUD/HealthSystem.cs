using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

    private Image heart;
    public Sprite[] hearts;
    public void decreaseHearts(int health)
    {
        Debug.Log("Decreasing hearts");
        heart.sprite = hearts[health];

        if(health == 0)
        {
            heart.sprite = hearts[hearts.Length - 1];
        }
    }

	// Use this for initialization
	void Start () {
        heart = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
