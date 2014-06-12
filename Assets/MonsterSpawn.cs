using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour {

	public GameObject monster;
	// Use this for initialization
	void Start () {
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn() {
		GameObject monsterClone = (GameObject)Instantiate (monster, new Vector2 (0, 0), new Quaternion ());		
	}
}
