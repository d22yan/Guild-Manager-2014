using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (0, 0, 70, 20), Constant.buttonBack)) {
			Application.LoadLevel(Constant.sceneMapScreen);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
