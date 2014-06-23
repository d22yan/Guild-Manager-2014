using UnityEngine;
using System.Collections;


public class MonsterAttacked : MonoBehaviour {

	public MonsterStatus monsterStatus;
	public MonsterDefeated monsterDefeated;

    private Vector2 InitialScale;
    private Vector2 InitialPosition;
    
    public GameObject DamageBox;
	public Transform blood;

	// Use this for initialization
	void Start () {
        InitialScale = new Vector2(transform.localScale.x, transform.localScale.y);
        InitialPosition = new Vector2(transform.position.x, transform.position.y);
        InvokeRepeating("AttackedByMage", GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate(), GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate());
        InvokeRepeating("AttackedByArcher", GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate(), GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate());
	}
	
	// Update is called once per frame
	void Update () {
        DeathCheck();
	}

    void OnMouseDown() {
		Transform bloodEffect = (Transform) Instantiate (blood, transform.position, transform.rotation);
		Destroy (bloodEffect.gameObject, 2);
        transform.localScale = new Vector3(InitialScale.x * Constant.AnimateShrinkOnMonsterAttacked, InitialScale.y * Constant.AnimateShrinkOnMonsterAttacked, 0);
    }

	void OnMouseUp() {
        DealDamage(GameState.State.PlayerStatus.GetTotalAttack());
        DisplayDamage(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.localScale = new Vector3(InitialScale.x, InitialScale.y, 0);
	}

    void DisplayDamage(Vector2 InputPosition) {
        GameObject boxClone = (GameObject)Instantiate(DamageBox, new Vector2(InputPosition.x / Screen.width, InputPosition.y/ Screen.height), new Quaternion());
        boxClone.guiText.text = "-" + GameState.State.PlayerStatus.GetTotalAttack().ToString();
    }

	void DealDamage(int damage) {
		monsterStatus.CurrentHealth -= damage;
	}

    void AttackedByMage() {
        DealDamage(GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveStat());
        DisplayDamage(new Vector2(InitialPosition.x + Screen.width / 2, InitialPosition.y + Screen.height / 2));
    }

    void AttackedByArcher() {
        DealDamage(GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveStat());
        DisplayDamage(new Vector2((InitialPosition.x + Screen.width / 2) / Screen.width, (InitialPosition.y + Screen.height / 2) / Screen.height));
    }

    void DeathCheck()
    {
        if (monsterStatus.CurrentHealth < 1)
        {
            monsterDefeated.DefeatMonster();
        }
    }
}
