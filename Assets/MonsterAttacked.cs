using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterDefeated monsterDefeated;

	// Use this for initialization
	void Start () {
        InvokeRepeating("AttackedByMage", GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate(), GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate());
        InvokeRepeating("AttackedByArcher", GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate(), GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate());
	}
	
	// Update is called once per frame
	void Update () {
        DeathCheck();
	}

	void OnMouseUp() {
		Debug.Log ("monster clicked");
		DealDamage (GameState.State.PlayerStatus.getAttack());
	}

	void DealDamage(int damage) {
		monsterStatus.CurrentHealth -= damage;
	}
    void AttackedByMage()
    {
        monsterStatus.CurrentHealth -= GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveStat();
    }
    void AttackedByArcher()
    {
        monsterStatus.CurrentHealth -= GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveStat();
    }
    void DeathCheck()
    {
        if (monsterStatus.CurrentHealth < 1)
        {
            monsterDefeated.DefeatMonster();
        }
    }
}
