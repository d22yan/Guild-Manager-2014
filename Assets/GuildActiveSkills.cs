using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuildActiveSkills : MonoBehaviour {
    public GUISkin yellowSkin;
    
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
        ScalingGUI.SetSkin(yellowSkin);
        if (ScalingGUI.Button(new Rect(30, 90, 10 * 9 / 16f, 10), mageTexture)) {
            TriggerMageActiveSkill();
        }
        if (ScalingGUI.Button(new Rect(40, 90, 10 * 9 / 16f, 10), archerTexture))
        {
            TriggerArcherActiveSkill();
        }
        if (ScalingGUI.Button(new Rect(50 + 10 - 10 * 9 / 16f, 90, 10 * 9 / 16f, 10), paladinTexture))
        {
            TriggerPaladinActiveSkill();
        }
        if (ScalingGUI.Button(new Rect(60 + 10 - 10 * 9 / 16f, 90, 10 * 9 / 16f, 10), priestTexture))
        {
            TriggerPriestActiveSkill();
        }
        if (AnimateFireballCounter > 0)
        {
            ScalingGUI.DrawTexture(new Rect(30, 30, 40, 40), PopExplosionTextures[PopExplosionTextures.Count - AnimateFireballCounter], ScaleMode.ScaleToFit, true, 0); // TODO hardcorded position
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
