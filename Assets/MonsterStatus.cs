using UnityEngine;
using System.Collections;

public class MonsterStatus : MonoBehaviour {
	public int MaxHealth {set; get;}
	public int CurrentHealth {set; get;}
	MonsterStatus() {
		MaxHealth = 100;
		CurrentHealth = 100;
	}
}
