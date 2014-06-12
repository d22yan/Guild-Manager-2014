using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public PlayerStatus playerStatus;
	public MonsterDefeated monsterDefeated;

	// Use this for initialization
	void Start () {
		playerStatus = GameObject.Find ("p1_walk01").GetComponent<PlayerStatus> ();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnMouseUp() {
		Debug.Log ("monster clicked");
		DealDamage (playerStatus.AttackDamage);
	}

	void DealDamage(int damage) {

		monsterStatus.CurrentHealth -= damage;
		if (monsterStatus.CurrentHealth < 1) {
			monsterDefeated.DefeatMonster();
		}
	}
}
