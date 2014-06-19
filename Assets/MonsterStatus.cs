using UnityEngine;
using System.Collections;

public class MonsterStatus : MonoBehaviour {
	public bool IsAlive {set; get;}
	public int MaxHealth {set; get;}
	public int CurrentHealth {set; get;}
	public float AttackSpeed {set; get;}
	public int AttackDamage {set; get;}
	public int GoldDrop {set; get;}
	void Awake() {
		AttackSpeed = 0.1f;
		AttackDamage = 1;
		MaxHealth = 100;
		CurrentHealth = 100;
		GoldDrop = 5;
	}
}
