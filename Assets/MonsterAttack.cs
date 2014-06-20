using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {

	public MonsterStatus monsterStatus;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Attack", 2, monsterStatus.AttackSpeed);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Attack() {
        PlayerStatus.CurrentHealth -= monsterStatus.AttackDamage;
		if (PlayerStatus.CurrentHealth < 1) {
            GameState.PlayerGold -= (int)(GameState.PlayerGold * 0.1);
            Application.LoadLevel("map_screen");

            PlayerStatus.CurrentHealth = PlayerStatus.Health;
		}
	}
}
