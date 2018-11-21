using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printPlayerState : MonoBehaviour {

    public Text playerState;
    string state;

	// Use this for initialization
	void Start () {
        playerState = GetComponent<State>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
