using UnityEngine;
using System.Collections;

public class HPBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void DrawHPBar(float HPBarPercentage,GUISkin emptySkin, GUISkin fullSkin, Vector2 position, Vector2 size) {
        ScalingGUI.SetSkin(emptySkin);
        ScalingGUI.BeginGroup(new Rect(position.x, position.y, size.x, size.y));
        ScalingGUI.Box(new Rect(0, 0, size.x, size.y), Mathf.Round(HPBarPercentage * 100).ToString() + "%");
        ScalingGUI.SetSkin(fullSkin);
        ScalingGUI.BeginGroup(new Rect(0, 0, size.x * HPBarPercentage, size.y));
        ScalingGUI.Box(new Rect(0, 0, size.x, size.y), Mathf.Round(HPBarPercentage * 100).ToString() + "%");
        ScalingGUI.EndGroup();
        ScalingGUI.EndGroup();
    }

}
