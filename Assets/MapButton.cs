using UnityEngine;
using System.Collections;

public class MapButton : MonoBehaviour {
    public Texture texture1;
    public Texture texture2;
    public Texture texture3;
    public Texture texture4;
    public Texture texture5;
    void OnGUI()
    {
        if (ScalingGUI.Button(new Rect(10, 20, 20, 20), texture1, GUIStyle.none))
        {
            Application.LoadLevel(Constant.battleScene1);
            GameState.State.PreviousScene = Constant.battleScene1;
        }
        if (ScalingGUI.Button(new Rect(70, 20, 20, 20), texture2, GUIStyle.none))
        {
            Application.LoadLevel(Constant.battleScene2);
            GameState.State.PreviousScene = Constant.battleScene2;
        }
        if (ScalingGUI.Button(new Rect(10, 50, 20, 20), texture3, GUIStyle.none))
        {
            Application.LoadLevel(Constant.battleScene3);
            GameState.State.PreviousScene = Constant.battleScene3;
        }
        if (ScalingGUI.Button(new Rect(70, 50, 20, 20), texture4, GUIStyle.none))
        {
            Application.LoadLevel(Constant.battleScene4);
            GameState.State.PreviousScene = Constant.battleScene4;
        }
        if (ScalingGUI.Button(new Rect(40, 70, 20, 20), texture5, GUIStyle.none))
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
