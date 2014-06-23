using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {
    public GUISkin blueSkin;

	void OnGUI() {
        GUI.skin = blueSkin;
		if (GUI.Button (new Rect (0, 0, 100, 40), Constant.buttonResume)) {
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
