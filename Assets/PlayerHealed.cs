using UnityEngine;
using System.Collections;

public class PlayerHealed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("HealedByPaladin", 0, GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveRate());
        InvokeRepeating("HealedByPriest", 0, GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveRate());
	}
	
	// Update is called once per frame
	void Update () {
	
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
        HealthCheck();
    }
    void HealedByPriest()
    {
        GameState.State.PlayerStatus.CurrentHealth += GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveStat();
        HealthCheck();
    }
}
