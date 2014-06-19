using UnityEngine;
using System.Collections;

public class PlayerDefeated : MonoBehaviour {

	public PlayerStatus playerStatus;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DefeatPlayer() {
		GameState.PlayerGold -= (int)(GameState.PlayerGold * 0.1);
		Application.LoadLevel ("map_screen");
	}
}
