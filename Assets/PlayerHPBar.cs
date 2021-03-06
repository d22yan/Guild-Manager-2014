﻿using UnityEngine;
using System.Collections;

public class PlayerHPBar : HPBar {
    public GUISkin redHPSkin;
    public GUISkin whiteHPSkin;

	float barDisplay = 1;
    Vector2 position = new Vector2(25, 80);
    Vector2 size = new Vector2(50, 5);
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
        barDisplay = (float)GameState.State.PlayerStatus.CurrentHealth / GameState.State.PlayerStatus.GetTotalHealth();
	}
}
