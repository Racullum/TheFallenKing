using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySystem : MonoBehaviour {

    private Text num_keys;

	// Use this for initialization
	void Start () {
        num_keys = GetComponent<Text>();
	}

    public void incrementKeys(int num)
    {
        num_keys.text = "x " + num;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
