using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public int AttackDamage { get; set; }
	public int MaxHealth { get; set; }
	public int CurrentHealth { get; set; }
	void Awake() {
		AttackDamage = 5;
		CurrentHealth = 100;
		MaxHealth = 100;
	}
}
