using UnityEngine;
using System.Collections;

public class MonsterSpawn : MonoBehaviour {

	public Sprite sprite1;
    public Sprite sprite1Hit;
	public Sprite sprite2;
    public Sprite sprite2Hit;
	public Sprite sprite3;
    public Sprite sprite3Hit;


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
		System.Random rand = new System.Random();
		int randomNumber = rand.Next (0, 3);
		switch(randomNumber) {
			case 0:
				monsterClone.GetComponent<SpriteRenderer>().sprite = sprite1;
                monsterClone.GetComponent<MonsterAttacked>().monsterHit = sprite1Hit;
				monsterClone.GetComponent<MonsterStatus>().AttackDamage = 11;
				break;
			case 1:
				monsterClone.GetComponent<SpriteRenderer>().sprite = sprite2;
                monsterClone.GetComponent<MonsterAttacked>().monsterHit = sprite2Hit;
				monsterClone.GetComponent<MonsterStatus>().AttackDamage = 12;
				break;
			case 2:
				monsterClone.GetComponent<SpriteRenderer>().sprite = sprite3;
                monsterClone.GetComponent<MonsterAttacked>().monsterHit = sprite3Hit;
				monsterClone.GetComponent<MonsterStatus>().AttackDamage = 13;
				break;
		}
	}
}
