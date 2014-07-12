using UnityEngine;
using System.Collections;

public class MapButton : MonoBehaviour {
    public GUISkin blueSkin;
    void OnGUI()
    {
        GUI.skin = blueSkin;
        if (GUI.Button(new Rect(0, 300, 100, 40), "to 2"))
        {
            Application.LoadLevel(Constant.battleScene2);
        }
        if (GUI.Button(new Rect(0, 500, 100, 40), "to 3"))
        {
            Application.LoadLevel(Constant.battleScene3);
        }
        if (GUI.Button(new Rect(300, 300, 100, 40), "to 4"))
        {
            Application.LoadLevel(Constant.battleScene4);
        }
        if (GUI.Button(new Rect(300, 500, 100, 40), "to 5"))
        {
            Application.LoadLevel(Constant.battleScene5);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
