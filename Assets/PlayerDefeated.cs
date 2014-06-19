using UnityEngine;
using System.Collections;

public class PlayerDefeated : MonoBehaviour {

	public PlayerStatus playerStatus;


	// Use this for initialization
	void Start () {
		//gameState = GameObject.Find ("Main Camera").GetComponent<GameState> ();
		 //= GameObject.Find ("Main Camera").GetComponent<MonsterSpawn> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DefeatPlayer() {
		GameState.PlayerGold -= (int)(GameState.PlayerGold * 0.1);
		Application.LoadLevel ("map_screen");
	}
}
