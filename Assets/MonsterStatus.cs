using UnityEngine;
using System.Collections;

public class MonsterStatus : MonoBehaviour {
	int maxHealth = 100;
	int currentHealth = 100;
	public int getCurrentHealth() {
		return currentHealth;
	}
	public void DealDamage(int damage) {
		currentHealth -= damage;
	}

}
