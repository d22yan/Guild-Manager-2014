using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {

	public MonsterStatus monsterStatus;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Attack", 0, monsterStatus.AttackSpeed);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Attack() {
        GameState.PlayerStatus.CurrentHealth -= monsterStatus.AttackDamage;
		if (GameState.PlayerStatus.CurrentHealth < 1) {
            GameState.PlayerGold -= (int)(GameState.PlayerGold * Constant.RateGoldLossOnDeath);
            Application.LoadLevel("map_screen");

            GameState.PlayerStatus.CurrentHealth = GameState.PlayerStatus.getHealth();
		}
	}
}
