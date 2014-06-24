using UnityEngine;
using System.Collections;

public class PlayerHealed : MonoBehaviour {
    public Transform HealingEffect;

	// Use this for initialization
	void Start () {
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

    void HealedByPaladin()
    {
        GameState.State.PlayerStatus.CurrentHealth += GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveStat();
        if (GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveStat() > 0)
            DisplayHealingEffect();
    }
    void HealedByPriest()
    {
        GameState.State.PlayerStatus.CurrentHealth += GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveStat();
        if (GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveStat() > 0)
            DisplayHealingEffect();
    }
}
