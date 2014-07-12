using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawn : MonoBehaviour {

	public Sprite sprite1;
    public Sprite sprite1Hit;
	public Sprite sprite2;
    public Sprite sprite2Hit;
	public Sprite sprite3;
    public Sprite sprite3Hit;

    private List<List<MonsterStats>> MonsterCollection;
    private string CurrentSceneName;

	public GameObject monster;
	// Use this for initialization
	void Start () {
        CurrentSceneName = Application.loadedLevelName;
        MonsterCollection = new List<List<MonsterStats>>();
        for (int i = 1; i < 6; i++)
        {
            MonsterCollection.Add(new List<MonsterStats>(){
                    new MonsterStats(2 / (float)i, 11 * i, 100 * i, 5 * i),
                    new MonsterStats(2 / (float)i, 12 * i, 120 * i, 10 * i),
                    new MonsterStats(2 / (float)i, 13 * i, 140 * i, 15 * i)
                });
        }
            
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn() {
        List<MonsterStats> MonsterList = new List<MonsterStats>();
        switch(CurrentSceneName) {
            case Constant.battleScene1:
                MonsterList = MonsterCollection[0];
                break;
            case Constant.battleScene2:
                MonsterList = MonsterCollection[1];
                break;
            case Constant.battleScene3:
                MonsterList = MonsterCollection[2];
                break;
            case Constant.battleScene4:
                MonsterList = MonsterCollection[3];
                break;
            case Constant.battleScene5:
                MonsterList = MonsterCollection[4];
                break;
        }
        
		GameObject monsterClone = (GameObject)Instantiate (monster, new Vector2 (0, 0), new Quaternion ());
		System.Random rand = new System.Random();
		int randomNumber = rand.Next (0, 3);
		switch(randomNumber) {
			case 0:
				monsterClone.GetComponent<SpriteRenderer>().sprite = sprite1;
                monsterClone.GetComponent<MonsterAttacked>().monsterHit = sprite1Hit;
                monsterClone.GetComponent<MonsterStatus>().AttackSpeed = MonsterList[0].AttackSpeed;
                monsterClone.GetComponent<MonsterStatus>().AttackDamage= MonsterList[0].AttackDamage;
                monsterClone.GetComponent<MonsterStatus>().MaxHealth = MonsterList[0].MaxHealth;
                monsterClone.GetComponent<MonsterStatus>().GoldDrop = MonsterList[0].GoldDrop;
                monsterClone.GetComponent<MonsterStatus>().CurrentHealth = MonsterList[0].CurrentHealth;
				break;
			case 1:
				monsterClone.GetComponent<SpriteRenderer>().sprite = sprite2;
                monsterClone.GetComponent<MonsterAttacked>().monsterHit = sprite2Hit;
				monsterClone.GetComponent<MonsterStatus>().AttackSpeed = MonsterList[1].AttackSpeed;
                monsterClone.GetComponent<MonsterStatus>().AttackDamage= MonsterList[1].AttackDamage;
                monsterClone.GetComponent<MonsterStatus>().MaxHealth = MonsterList[1].MaxHealth;
                monsterClone.GetComponent<MonsterStatus>().GoldDrop = MonsterList[1].GoldDrop;
                monsterClone.GetComponent<MonsterStatus>().CurrentHealth = MonsterList[1].CurrentHealth;
				break;
			case 2:
				monsterClone.GetComponent<SpriteRenderer>().sprite = sprite3;
                monsterClone.GetComponent<MonsterAttacked>().monsterHit = sprite3Hit;
				monsterClone.GetComponent<MonsterStatus>().AttackSpeed = MonsterList[2].AttackSpeed;
                monsterClone.GetComponent<MonsterStatus>().AttackDamage= MonsterList[2].AttackDamage;
                monsterClone.GetComponent<MonsterStatus>().MaxHealth = MonsterList[2].MaxHealth;
                monsterClone.GetComponent<MonsterStatus>().GoldDrop = MonsterList[2].GoldDrop;
                monsterClone.GetComponent<MonsterStatus>().CurrentHealth = MonsterList[2].CurrentHealth;
				break;
		}
	}
}
