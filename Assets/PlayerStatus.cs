using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public int Attack { get; set; }
	public int Defense { get; set; }
	public int Critical { get; set; }
	public int Health { get; set; }
	public int CurrentHealth { get; set; }
	void Awake() {
		Attack = 5;
		Defense = 5;
		Critical = 5;
		CurrentHealth = 100;
		Health = 100;
	}
}
