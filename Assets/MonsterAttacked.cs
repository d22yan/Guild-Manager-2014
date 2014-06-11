using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		Debug.Log ("monster clicked");
		var monsterStatus = gameObject.GetComponent<MonsterStatus>();
		monsterStatus.DealDamage (10);
	}
}
