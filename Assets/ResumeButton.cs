using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {
    public GUISkin blueSkin;

	void OnGUI() {
        GUI.skin = blueSkin;
        if (ScalingGUI.Button(new Rect(0, 0, 20, 10), Constant.buttonResume))
        {
			Application.LoadLevel(Constant.battleScene1);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
