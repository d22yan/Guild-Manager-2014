using UnityEngine;
using System.Collections;

public class PlayerHealed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("HealedByPaladin", 0, GameState.PlayerStatus.GuildStatus.Paladin.GetPassiveRate());
        InvokeRepeating("HealedByPriest", 0, GameState.PlayerStatus.GuildStatus.Priest.GetPassiveRate());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void HealthCheck()
    {
        if (GameState.PlayerStatus.CurrentHealth > GameState.PlayerStatus.getHealth())
        {
            GameState.PlayerStatus.CurrentHealth = GameState.PlayerStatus.getHealth();
        }
    }

    void HealedByPaladin()
    {
        GameState.PlayerStatus.CurrentHealth += GameState.PlayerStatus.GuildStatus.Paladin.GetPassiveStat();
        HealthCheck();
    }
    void HealedByPriest()
    {
        GameState.PlayerStatus.CurrentHealth += GameState.PlayerStatus.GuildStatus.Priest.GetPassiveStat();
        HealthCheck();
    }
}
