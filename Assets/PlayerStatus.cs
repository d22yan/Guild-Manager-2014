using UnityEngine;
using System.Collections;

public static class PlayerStatus {
	public static int Attack { get; set; }
	public static int Defense { get; set; }
	public static int Critical { get; set; }
	public static int Health { get; set; }
	public static int CurrentHealth { get; set; }
	static PlayerStatus() {
		Attack = 5;
		Defense = 5;
		Critical = 5;
		CurrentHealth = 100;
		Health = 100;
	}
}
