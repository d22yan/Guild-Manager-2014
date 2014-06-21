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
        GameState.State.PlayerStatus.CurrentHealth -= monsterStatus.AttackDamage;
		if (GameState.State.PlayerStatus.CurrentHealth < 1) {
            GameState.State.PlayerGold -= (int)(GameState.State.PlayerGold * Constant.RateGoldLossOnDeath);
            Application.LoadLevel("map_screen");

            GameState.State.PlayerStatus.CurrentHealth = GameState.State.PlayerStatus.getHealth();
		}
	}
}
