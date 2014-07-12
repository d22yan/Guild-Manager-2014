using UnityEngine;
using System.Collections;

public class PlayerStatus {
    public GuildStatus GuildStatus { get; set; }

    public int Attack { get; set; }
    public int Critical { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }

    public float CriticalChance { get; set; }

    public int CurrentHealth { get; set; }

	public int GetTotalAttack() {
		return Attack + GuildStatus.Mage.GetActiveStat();
	}
    public int GetTotalCritical()
    {
        return Critical + GuildStatus.Archer.GetActiveStat();
    }
	public int GetTotalDefense() {
		return Defense + GuildStatus.Paladin.GetActiveStat();
	}
	public int GetTotalHealth() {
        return Health + GuildStatus.Priest.GetActiveStat();
	}


    public PlayerStatus(int attack, int critical, int defense, int health)
    {
		GuildStatus = new GuildStatus();
		Attack = attack;
		Critical = critical;
		Defense = defense;
		Health = health;
        CurrentHealth = health;
        CriticalChance = 0.2f; // TODO 
	}
}
