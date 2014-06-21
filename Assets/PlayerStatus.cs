using UnityEngine;
using System.Collections;

public class PlayerStatus {
	private int attack;
	private int defense;
	private int critical;
	private int health;

	public GuildStatus GuildStatus { get; set; }

	public int getAttack() {
		return attack + GuildStatus.Mage.GetActiveStat();
	}

	public void setAttack(int value) {
		attack = value;
	}

	public int getDefense() {
		return defense + GuildStatus.Paladin.GetActiveStat();
	}

	public void setDefense(int value) {
		defense = value;
	}

	public int getCritical() {
        return critical + GuildStatus.Archer.GetActiveStat();
	}

	public void setCritical(int value) {
		critical = value;
	}

	public int getHealth() {
        return health + GuildStatus.Priest.GetActiveStat();
	}

	public void setHealth(int value) {
		health = value;
	}

    public int CurrentHealth { get; set; }

	public PlayerStatus(int attack, int defense, int critical, int health) {
		GuildStatus = new GuildStatus();
		this.attack = attack;
		this.defense = defense;
		this.critical = critical;
		this.health = health;
        CurrentHealth = health;
	}
}
