using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {
    public GUISkin blueSkin;

	void OnGUI() {
        GUI.skin = blueSkin;
        string buttonText;
        string levelName;

        if (GameState.State.PreviousScene == null)
        {
            buttonText = Constant.buttonBegin;
            levelName = Constant.battleScene1;
        }
        else 
        {
            buttonText = Constant.buttonResume;
            levelName = GameState.State.PreviousScene;
        }

        if (ScalingGUI.Button(new Rect(0, 0, 20, 10), buttonText))
        {
            Application.LoadLevel(levelName);
            GameState.State.PreviousScene = levelName;
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
