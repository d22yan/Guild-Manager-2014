using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		Debug.Log ("monster clicked");
		DealDamage (1);
	}

	void DealDamage(int damage) {
		monsterStatus.CurrentHealth -= damage;
	}
}
