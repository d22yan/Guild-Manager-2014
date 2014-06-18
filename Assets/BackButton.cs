using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (30, 5, 30, 30), "back")) {
			Application.LoadLevel("map_screen");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
