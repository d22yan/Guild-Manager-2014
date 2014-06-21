using UnityEngine;
using System.Collections;

public class MonsterDefeated : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterSpawn monsterSpawn;

	// Use this for initialization
	void Start () {
		monsterSpawn = GameObject.Find ("Main Camera").GetComponent<MonsterSpawn> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DefeatMonster() {
		GameState.State.PlayerGold += monsterStatus.GoldDrop;
		Debug.Log (GameState.State.PlayerGold);
		Destroy (gameObject);
		monsterSpawn.Spawn ();
	}

	void MonsterDeathAnimation() {

	}
}
