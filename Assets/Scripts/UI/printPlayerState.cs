using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printPlayerState : MonoBehaviour {

	static string playerState;

    /*public Text state;
    public string playerState;

	// Use this for initialization
	void Start () {
		state = GetComponent<Text>();
        //playerState = GetComponent<State>();
		
	}
	
	// Update is called once per frame
	void Update () {
		state.text = playerState;
		
	}*/

	void OnGUI()
    {
        GUI.Label(new Rect (0, 0, 100, 100), playerState);
    }
	//Debug.Log(playerState);
}
