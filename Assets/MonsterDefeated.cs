using UnityEngine;
using System.Collections;

public class MonsterDefeated : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public GameState gameState;
	public MonsterSpawn monsterSpawn;

	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("Main Camera").GetComponent<GameState> ();
		monsterSpawn = GameObject.Find ("Main Camera").GetComponent<MonsterSpawn> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DefeatMonster() {
		gameState.PlayerGold += monsterStatus.GoldDrop;
		Debug.Log (gameState.PlayerGold);
		Destroy (gameObject);
		monsterSpawn.Spawn ();
	}

	void MonsterDeathAnimation() {

	}
}
