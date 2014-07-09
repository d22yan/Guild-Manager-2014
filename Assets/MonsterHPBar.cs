using UnityEngine;
using System.Collections;

public class MonsterHPBar : HPBar {
    public GUISkin redHPSkin;
    public GUISkin whiteHPSkin;

	public MonsterStatus monsterStatus;
	float barDisplay = 1;
    Vector2 position = new Vector2((Screen.width - Screen.width / 4) / 2, Screen.height / 4);
    Vector2 size = new Vector2((Screen.width / 4), 30);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;

	void OnGUI() {
        DrawHPBar(barDisplay, whiteHPSkin, redHPSkin, position, size);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		barDisplay = (float)monsterStatus.CurrentHealth / monsterStatus.MaxHealth;
	}
	
}
