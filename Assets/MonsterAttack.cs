﻿using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {

	public MonsterStatus monsterStatus;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Attack", monsterStatus.AttackSpeed, monsterStatus.AttackSpeed);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Attack() {
        int MonsterTotalDamage = monsterStatus.AttackDamage - GameState.State.PlayerStatus.GetTotalDefense();
        
        if (GameState.State.PlayerStatus.GuildStatus.PaladinBuffStacks > 0)
        {
            MonsterTotalDamage = (int)Mathf.Floor(MonsterTotalDamage * 0.5f);
            GameState.State.PlayerStatus.GuildStatus.PaladinBuffStacks--;
        }

        if (MonsterTotalDamage < 1)
        {
            MonsterTotalDamage = 1;
        }
        GameState.State.PlayerStatus.CurrentHealth -= MonsterTotalDamage;
		if (GameState.State.PlayerStatus.CurrentHealth < 1) {
            GameState.State.PlayerGold -= (int)(GameState.State.PlayerGold * Constant.RateGoldLossOnDeath);
            Application.LoadLevel("map_screen");

            GameState.State.PlayerStatus.CurrentHealth = GameState.State.PlayerStatus.GetTotalHealth();
		}
	}
}
