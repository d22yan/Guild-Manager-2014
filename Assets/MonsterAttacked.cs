using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterDefeated monsterDefeated;

    private Vector2 InitialScale;
    private Vector2 InitialMonsterSpawnPosition;
    private Vector2 InitialMousePoisition;
    
    public GameObject DamageBox;

	// Use this for initialization
	void Start () {
        InitialScale = new Vector2(transform.localScale.x, transform.localScale.y);
        InitialMonsterSpawnPosition = new Vector2(transform.position.x, transform.position.y);
        InitialMousePoisition = new Vector2(Screen.width / 2, Screen.height / 2);
        InvokeRepeating("AttackedByMage", GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate(), GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate());
        InvokeRepeating("AttackedByArcher", GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate(), GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate());
	}
	
	// Update is called once per frame
	void Update () {
        DeathCheck();
	}

    void OnMouseDown() {
        InitialMousePoisition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        transform.localScale = new Vector3(InitialScale.x * Constant.AnimationShrinkOnMonsterAttacked, InitialScale.y * Constant.AnimationShrinkOnMonsterAttacked, 0);
    }

	void OnMouseUp() {
        int TotalDamage = GameState.State.PlayerStatus.GetTotalAttack();
        DealDamage(TotalDamage);
        DisplayDamage(TotalDamage.ToString(), new Vector2(InitialMousePoisition.x, InitialMousePoisition.y));
        transform.localScale = new Vector3(InitialScale.x, InitialScale.y, 0);
	}

    void DisplayDamage(string Damage, Vector2 InputPosition) {
        GameObject boxClone = (GameObject)Instantiate(DamageBox, new Vector2(InputPosition.x / Screen.width, InputPosition.y/ Screen.height), new Quaternion());
        boxClone.guiText.text = "-" + Damage;
    }

	void DealDamage(int damage) {
		monsterStatus.CurrentHealth -= damage;
	}

    void AttackedByMage() {
        int TotalDamage = GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveStat();
        if (TotalDamage > 0) {
            DealDamage(TotalDamage);
            DisplayDamage(TotalDamage.ToString(), new Vector2(InitialMonsterSpawnPosition.x + Screen.width / 2, InitialMonsterSpawnPosition.y + Screen.height / 2));
        }
    }

    void AttackedByArcher() {
        int TotalDamage = GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveStat();
        if (TotalDamage > 0) {
            DealDamage(TotalDamage);
            DisplayDamage(TotalDamage.ToString(), new Vector2(InitialMonsterSpawnPosition.x + Screen.width / 2, InitialMonsterSpawnPosition.y + Screen.height / 2));
        }
    }

    void DeathCheck()
    {
        if (monsterStatus.CurrentHealth < 1)
        {
            monsterDefeated.DefeatMonster();
        }
    }
}
