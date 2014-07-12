using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuildActiveSkills : MonoBehaviour {

    public Texture archerTexture;
    public Texture priestTexture;
    public Texture mageTexture;
    public Texture paladinTexture;

    void OnGUI() {
        if (GUI.Button(new Rect(0, 200, 50, 50), mageTexture)) {
            TriggerMageActiveSkill();
        }
        if (GUI.Button(new Rect(0, 250, 50, 50), archerTexture))
        {
            TriggerArcherActiveSkill();
        }
        if (GUI.Button(new Rect(0, 300, 50, 50), paladinTexture))
        {
            TriggerPaladinActiveSkill();
        }
        if (GUI.Button(new Rect(0, 350, 50, 50), priestTexture))
        {
            TriggerPriestActiveSkill();
        }
    }

    void TriggerMageActiveSkill()
    {
        GameObject.Find("Monster(Clone)").GetComponent<MonsterAttacked>().AttackedByFireball();
    }

    void TriggerArcherActiveSkill()
    {
        GameState.State.PlayerStatus.GuildStatus.ArcherBuffStacks = GameState.State.PlayerStatus.GuildStatus.BaseArcherBuffStacks;
    }

    void TriggerPaladinActiveSkill()
    {
        GameState.State.PlayerStatus.GuildStatus.PaladinBuffStacks = GameState.State.PlayerStatus.GuildStatus.BasePaladinBuffStacks;
    }

    void TriggerPriestActiveSkill()
    {
        GameObject.Find("Player").GetComponent<PlayerHealed>().HealedByCure();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
