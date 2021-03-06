﻿using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterDefeated monsterDefeated;
    public Sprite monsterHit;

    private Sprite originalSprite;
    private Queue spriteToggled;
    private Vector2 InitialScale;
    private Vector2 InitialMonsterSpawnPosition;
    private Vector2 InitialMousePoisition;

    private int ArrowRainCount;
    
    public GameObject DamageBox;

	// Use this for initialization
	void Start () {
        ArrowRainCount = 0;
        originalSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        spriteToggled = new Queue();
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
        gameObject.GetComponent<SpriteRenderer>().sprite = monsterHit;
        StartCoroutine(ToggleHitSprite());
    }

    IEnumerator ToggleHitSprite()
    {
        spriteToggled.Enqueue(true);
        yield return new WaitForSeconds(1);
        spriteToggled.Dequeue();

        if (spriteToggled.Count == 0)
            gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
    }

	void OnMouseUp() {
        int TotalDamage = GameState.State.PlayerStatus.GetTotalAttack();
        System.Random rand = new System.Random();
        double randomNumber = rand.NextDouble();

        if (GameState.State.PlayerStatus.GuildStatus.ArcherBuffStacks > 0)
        {
            randomNumber = 0;
            GameState.State.PlayerStatus.GuildStatus.ArcherBuffStacks--;
        }

        if (randomNumber < GameState.State.PlayerStatus.CriticalChance)
        {
            TotalDamage = (int) Mathf.Floor(TotalDamage * (1 + (GameState.State.PlayerStatus.GetTotalCritical() / 100.0f)));
        }
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
            DisplayDamage(TotalDamage.ToString(), new Vector2((InitialMonsterSpawnPosition.x + Screen.width / 2) + Constant.DisplayGuildMemberDamageOffset, (InitialMonsterSpawnPosition.y + Screen.height / 2) + Constant.DisplayGuildMemberDamageOffset));
        }
    }

    public void AttackedByFireball() {
        int damage = GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveStat() * 5;
        DealDamage(damage);
        DisplayDamage(damage.ToString(), new Vector2((InitialMonsterSpawnPosition.x + Screen.width / 2) + Constant.DisplayGuildMemberDamageOffset, (InitialMonsterSpawnPosition.y + Screen.height / 2) + Constant.DisplayGuildMemberDamageOffset + 5));
    }

    void AttackedByArcher() {
        int TotalDamage = GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveStat();
        if (TotalDamage > 0) {
            DealDamage(TotalDamage);
            DisplayDamage(TotalDamage.ToString(), new Vector2((InitialMonsterSpawnPosition.x + Screen.width / 2) - Constant.DisplayGuildMemberDamageOffset, (InitialMonsterSpawnPosition.y + Screen.height / 2) - Constant.DisplayGuildMemberDamageOffset));
        }
    }

    void AttackedByArrow()
    {
        int TotalDamage = GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveStat();
        if (TotalDamage > 0)
        {
            DealDamage(TotalDamage);
            DisplayDamage(TotalDamage.ToString(), new Vector2((InitialMonsterSpawnPosition.x + Screen.width / 2) - Constant.DisplayGuildMemberDamageOffset, (InitialMonsterSpawnPosition.y + Screen.height / 2) - Constant.DisplayGuildMemberDamageOffset));
        }
        ArrowRainCount--;

        if (ArrowRainCount == 0)
        {
            CancelInvoke("AttackedByArrow");
        }
    }

    public void AttackedByArrowRain()
    {
        ArrowRainCount = 5;
        InvokeRepeating("AttackedByArrow", 0f, 0.3f);
    }

    void DeathCheck()
    {
        if (monsterStatus.CurrentHealth < 1)
        {
            monsterDefeated.DefeatMonster();
        }
    }
}
