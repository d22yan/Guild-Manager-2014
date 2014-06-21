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
		AttackSpeed = Constant.InitialMonsterAttackSpeed;
		AttackDamage = Constant.InitialMonsterAttackDamage;
		MaxHealth = Constant.InitialMonsterMaxHealth;
		CurrentHealth = Constant.InitialMonsterCurrentHealth;
		GoldDrop = Constant.InitialMonsterGoldDrop;
	}
}
