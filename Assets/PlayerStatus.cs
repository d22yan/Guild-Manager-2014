using UnityEngine;
using System.Collections;

public class PlayerStatus {
	public int Attack { get; set; }
	public int Defense { get; set; }
	public int Critical { get; set; }
	public int Health { get; set; }
	public int CurrentHealth { get; set; }
	
	public PlayerStatus(int attack, int defense, int critical, int health) {
		Attack = attack;
		Defense = defense;
		Critical = critical;
		CurrentHealth = health;
		Health = health;
	}
}
