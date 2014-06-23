using UnityEngine;
using System.Collections;

public class PlayerHPBar : MonoBehaviour {
    public GUISkin redHPSkin;
    public GUISkin whiteHPSkin;

	float barDisplay = 1;
    Vector2 pos = new Vector2((Screen.width / 4), Screen.height - 50);
    Vector2 size = new Vector2(Screen.width / 2, 30);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	
	void OnGUI() {
        GUI.skin = whiteHPSkin;
		// draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), Mathf.Round(barDisplay * 100).ToString() + "%");

        GUI.skin = redHPSkin;
		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), Mathf.Round(barDisplay * 100).ToString() + "%");
		GUI.EndGroup ();
		
		GUI.EndGroup ();
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        barDisplay = (float)GameState.State.PlayerStatus.CurrentHealth / GameState.State.PlayerStatus.GetTotalHealth();
	}
}
