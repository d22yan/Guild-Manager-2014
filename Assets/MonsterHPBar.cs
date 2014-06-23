using UnityEngine;
using System.Collections;

public class MonsterHPBar : MonoBehaviour {

	public MonsterStatus monsterStatus;
	float barDisplay = 1;
	Vector2 pos = new Vector2((Screen.width/5)*2,Screen.height/4);
	Vector2 size = new Vector2((Screen.width/5),20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;

	void OnGUI() {
		// draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y),progressBarEmpty);
		
		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y),progressBarFull);
		GUI.EndGroup ();
		
		GUI.EndGroup ();

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		barDisplay = (float)monsterStatus.CurrentHealth / monsterStatus.MaxHealth;
	}
	
}
