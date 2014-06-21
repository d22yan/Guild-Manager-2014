using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (0, 0, 70, 20), Constant.buttonResume)) {
			Application.LoadLevel(Constant.sceneBattleScreen);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
