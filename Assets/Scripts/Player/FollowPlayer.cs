using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    private Transform trans;
	// Use this for initialization
	void Start () {
        trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        trans.position = new Vector3(player.transform.position.x + .5f, trans.position.y, trans.position.z);
	}
}
