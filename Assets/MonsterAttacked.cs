using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterDefeated monsterDefeated;

	// Use this for initialization
	void Start () {
        InvokeRepeating("AttackedByMage", 0, GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate());
        InvokeRepeating("AttackedByArcher", 0, GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate());
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseUp() {
		Debug.Log ("monster clicked");
		DealDamage (GameState.State.PlayerStatus.getAttack());
	}

	void DealDamage(int damage) {
		monsterStatus.CurrentHealth -= damage;
        DeathCheck();
	}
    void AttackedByMage()
    {
        monsterStatus.CurrentHealth -= GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveStat();
        DeathCheck();
    }
    void AttackedByArcher()
    {
        monsterStatus.CurrentHealth -= GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveStat();
        DeathCheck();
    }
    void DeathCheck()
    {
        if (monsterStatus.CurrentHealth < 1)
        {
            monsterDefeated.DefeatMonster();
        }
    }
}
