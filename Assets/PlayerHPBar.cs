using UnityEngine;
using System.Collections;

public class PlayerHPBar : MonoBehaviour {

	float barDisplay = 1;
	int barWidth = (Screen.width/4) * 2;
	Vector2 pos = new Vector2((Screen.width/4),Screen.height-23);
	Vector2 size = new Vector2((Screen.width/4)*3,20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	
	void OnGUI() {
		// draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		GUI.Box (new Rect (0,0, barWidth, size.y), progressBarEmpty);
		
		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0,0, barWidth, size.y), progressBarFull);
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
