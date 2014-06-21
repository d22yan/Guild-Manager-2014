using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterDefeated monsterDefeated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseUp() {
		Debug.Log ("monster clicked");
		DealDamage (GameState.PlayerStatus.Attack);
	}

	void DealDamage(int damage) {
		monsterStatus.CurrentHealth -= damage;
		if (monsterStatus.CurrentHealth < 1) {
			monsterDefeated.DefeatMonster();
		}
	}
}
