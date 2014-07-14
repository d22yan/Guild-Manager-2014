using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuildActiveSkills : MonoBehaviour {

    public Texture archerTexture;
    public Texture priestTexture;
    public Texture mageTexture;
    public Texture paladinTexture;

    public bool AnimateFireballFlag;
    public int AnimateFireballCounter;
    public float AnimateFireballStartTime;
    public float AnimateFireballIntervalTime;
    public List<Texture> PopExplosionTextures;

    void Awake()
    {
        AnimateFireballFlag = false;
        AnimateFireballIntervalTime = 0.1f;
        AnimateFireballCounter = 0;
    }

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
        if (AnimateFireballCounter > 0)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), PopExplosionTextures[PopExplosionTextures.Count - AnimateFireballCounter], ScaleMode.ScaleToFit, true, 0); // TODO hardcorded position
        }
    }

    void TriggerMageActiveSkill()
    {
        GameObject.Find("Monster(Clone)").GetComponent<MonsterAttacked>().AttackedByFireball();
        AnimateFireballFlag = true; 
        AnimateFireballCounter = PopExplosionTextures.Count;
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
        AnimateFireBall();
	}

    void AnimateFireBall() // TODO possibly use Unity Animator
    {
        if (AnimateFireballCounter > 0)
        {
            if (AnimateFireballFlag)
            {
                AnimateFireballStartTime = Time.time;
                AnimateFireballFlag = false;
            }
            if (Time.time - AnimateFireballStartTime > AnimateFireballIntervalTime)
            {
                AnimateFireballStartTime = Time.time;
                AnimateFireballCounter--;
            }
        }
    }
}
