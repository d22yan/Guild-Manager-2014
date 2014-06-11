using UnityEngine;
using System.Collections;

public class MonsterHPBar : MonoBehaviour {

	public MonsterStatus monsterStatus;
	float barDisplay = 0;
	Vector2 pos = new Vector2(20,40);
	Vector2 size = new Vector2(60,20);
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
		Debug.Log ("asd");
	}
	
	// Update is called once per frame
	void Update () {
		barDisplay = (float)monsterStatus.getCurrentHealth () / 100;
	}
	
}
