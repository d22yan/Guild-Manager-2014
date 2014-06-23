using UnityEngine;
using System.Collections;

public class PlayerHealed : MonoBehaviour {

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

    void HealedByPaladin()
    {
        GameState.State.PlayerStatus.CurrentHealth += GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveStat();
    }
    void HealedByPriest()
    {
        GameState.State.PlayerStatus.CurrentHealth += GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveStat();
    }
}
