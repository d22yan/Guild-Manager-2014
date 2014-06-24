using UnityEngine;
using System.Collections;

public class PlayerHealed : MonoBehaviour {
    public Transform HealingEffect;
    public GameObject HealingBox;

    private Vector2 InitialScale;
    private Vector2 InitialPosition;

	// Use this for initialization
	void Start () {
        InitialScale = new Vector2(transform.localScale.x, transform.localScale.y);
        InitialPosition = new Vector2(transform.position.x, transform.position.y);
		InvokeRepeating("HealedByPaladin", GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveRate(),GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveRate());
		InvokeRepeating("HealedByPriest", GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveRate(),GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveRate());
	}
	
	// Update is called once per frame
	void Update () {
		HealthCheck ();
	}

    void HealthCheck()
    {
        if (GameState.State.PlayerStatus.CurrentHealth > GameState.State.PlayerStatus.GetTotalHealth())
        {
            GameState.State.PlayerStatus.CurrentHealth = GameState.State.PlayerStatus.GetTotalHealth();
        }
    }

    void DisplayHealingEffect()
    {
        Transform healingEffect = (Transform)Instantiate(HealingEffect, transform.position, transform.rotation);
        Destroy(healingEffect.gameObject, 2);
    }

    void DisplayHealing(int Healing, Vector2 InputPosition)
    {
        GameObject boxClone = (GameObject)Instantiate(HealingBox, new Vector2(InputPosition.x / Screen.width, InputPosition.y / Screen.height), new Quaternion());
        boxClone.guiText.text = "+" + Healing;
    }

    void HealedByPaladin()
    {
        var healAmount = GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveStat();
        if (healAmount > 0)
        {
            GameState.State.PlayerStatus.CurrentHealth += healAmount;
            DisplayHealingEffect();
            DisplayHealing(healAmount, new Vector2(InitialPosition.x + Screen.width * 1 / 3, InitialPosition.y + 80));
        }
    }
    void HealedByPriest()
    {
        var healAmount = GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveStat();
        if (healAmount > 0)
        {
            GameState.State.PlayerStatus.CurrentHealth += healAmount;
            DisplayHealingEffect();
            DisplayHealing(healAmount, new Vector2(InitialPosition.x + Screen.width * 2 / 3, InitialPosition.y + 80));
        }
    }
}
