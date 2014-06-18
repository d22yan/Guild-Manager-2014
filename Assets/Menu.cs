using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private bool isDisplayed;


	void OnGUI() {
		//if (isDisplayed) {
			if (GUI.Button (new Rect (10, 70, 50, 30), "Resume")) {
				Application.LoadLevel("battle_screen");
				Debug.Log("Resume CLICKED");
			}
		//}
	}

	// Use this for initialization
	void Start () {
		isDisplayed = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
