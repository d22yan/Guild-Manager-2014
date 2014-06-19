using UnityEngine;
using System.Collections;

public class GoldTotal : MonoBehaviour {

	public GUIStyle style1;
	public bool isShopDisplayed;
	public Vector2 size;
	public Texture progressBarEmpty;
	public delegate void drawTabDelegate();
	public drawTabDelegate DrawTab;

	void DrawShopTab() {
		GUI.BeginGroup (new Rect (40, 40, 300, 300));
		GUI.Box (new Rect (0,0, size.x, size.y), progressBarEmpty);
		GUI.EndGroup ();
	}

	void DrawHireTab() {
		GUI.BeginGroup (new Rect (40, 40, 300, 300));
		GUI.Box (new Rect (0,100, size.x, size.y), progressBarEmpty);
		GUI.EndGroup ();
	}

	void DrawBlacksmithTab() {
		GUI.BeginGroup (new Rect (40, 40, 300, 300));
		GUI.Box (new Rect (0,200, size.x, size.y), progressBarEmpty);
		GUI.EndGroup ();
	}

	void OnGUI() {
		if (GUI.Button (new Rect (120, 10, 100, 20), GameState.PlayerGold.ToString ())) {
			isShopDisplayed = !isShopDisplayed;

		}

		if (isShopDisplayed) {
			if (GUI.Button (new Rect (120, 200, 100, 20), "Shop")) {
				DrawTab = DrawShopTab;
			}
			if (GUI.Button (new Rect (220, 200, 100, 20), "Hire")) {
				DrawTab = DrawHireTab;
			}
			if (GUI.Button (new Rect (320, 200, 100, 20), "Blacksmith")) {
				DrawTab = DrawBlacksmithTab;
			}
			DrawTab();
		}
	}

	// Use this for initialization
	void Start () {
		isShopDisplayed = false;
		DrawTab = DrawShopTab;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
