using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterDefeated monsterDefeated;

    private float ImageScaleX;
    private float ImageScaleY;

	// Use this for initialization
	void Start () {
        ImageScaleX = transform.localScale.x;
        ImageScaleY = transform.localScale.y;
        InvokeRepeating("AttackedByMage", GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate(), GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate());
        InvokeRepeating("AttackedByArcher", GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate(), GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate());
	}
	
	// Update is called once per frame
	void Update () {
        DeathCheck();
	}

    void OnMouseDown() {
        transform.localScale = new Vector3(ImageScaleX * Constant.AnimateShrinkOnMonsterAttacked, ImageScaleY * Constant.AnimateShrinkOnMonsterAttacked, 0);
    }

	void OnMouseUp() {
        DealDamage (GameState.State.PlayerStatus.GetTotalAttack());
        transform.localScale = new Vector3(ImageScaleX, ImageScaleY, 0);
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
