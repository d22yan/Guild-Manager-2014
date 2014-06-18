using UnityEngine;
using System.Collections;

public class PlayerDefeated : MonoBehaviour {

	public PlayerStatus playerStatus;
	public GameState gameState;
	public PlayerSpawn playerSpawn;


	// Use this for initialization
	void Start () {
		//gameState = GameObject.Find ("Main Camera").GetComponent<GameState> ();
		 //= GameObject.Find ("Main Camera").GetComponent<MonsterSpawn> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
