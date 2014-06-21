using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterDefeated monsterDefeated;

    private bool IsAttackingMonster;

	// Use this for initialization
	void Start () {
        IsAttackingMonster = false;
        InvokeRepeating(
            "AttackedByGuildMembers",
            Constant.DelayGuildMemberInitialAttack,
            GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate() + GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate()
        );
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseUp() {
		DealDamage (GameState.State.PlayerStatus.getAttack());
	}

	void DealDamage(int damage) {
		monsterStatus.CurrentHealth -= damage;
        DeathCheck();
	}

    void AttackedByGuildMembers()
    {
        monsterStatus.CurrentHealth -= GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveStat();
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
