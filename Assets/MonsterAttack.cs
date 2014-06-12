using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {

	public PlayerStatus playerStatus;
	public MonsterStatus monsterStatus;


	// Use this for initialization
	void Start () {
		playerStatus = GameObject.Find ("p1_walk01").GetComponent<PlayerStatus> ();
		InvokeRepeating ("Attack", 2, monsterStatus.AttackSpeed);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Attack() {
		playerStatus.CurrentHealth -= monsterStatus.AttackDamage;
	}
}
