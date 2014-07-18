using UnityEngine;
using System.Collections;

public class MapButton : MonoBehaviour {
    public GUISkin blueSkin;
    void OnGUI()
    {
        ScalingGUI.SetSkin(blueSkin);
        if (ScalingGUI.Button(new Rect(10, 30, 10, 10), "to 1"))
        {
            Application.LoadLevel(Constant.battleScene1);
            GameState.State.PreviousScene = Constant.battleScene1;
        }
        if (ScalingGUI.Button(new Rect(80, 30, 10, 10), "to 2"))
        {
            Application.LoadLevel(Constant.battleScene2);
            GameState.State.PreviousScene = Constant.battleScene2;
        }
        if (ScalingGUI.Button(new Rect(10, 60, 10, 10), "to 3"))
        {
            Application.LoadLevel(Constant.battleScene3);
            GameState.State.PreviousScene = Constant.battleScene3;
        }
        if (ScalingGUI.Button(new Rect(80, 60, 10, 10), "to 4"))
        {
            Application.LoadLevel(Constant.battleScene4);
            GameState.State.PreviousScene = Constant.battleScene4;
        }
        if (ScalingGUI.Button(new Rect(45, 80, 10, 10), "to 5"))
        {
            Application.LoadLevel(Constant.battleScene5);
            GameState.State.PreviousScene = Constant.battleScene5;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
