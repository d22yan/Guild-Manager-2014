using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuildActiveSkills : MonoBehaviour {

    public Texture pop_explosion0001;
    public Texture pop_explosion0002;
    public Texture pop_explosion0003;
    public Texture pop_explosion0004;
    public Texture pop_explosion0005;
    public Texture pop_explosion0006;
    public Texture pop_explosion0007;
    public Texture pop_explosion0008;
    public Texture pop_explosion0009;
    public Texture pop_explosion0010;
    public Texture pop_explosion0011;
    public Texture pop_explosion0012;
    public Texture pop_explosion0013;
    public Texture pop_explosion0014;
    public Texture pop_explosion0015;
    public Texture pop_explosion0016;
    public Texture pop_explosion0017;
    public Texture pop_explosion0018;

    public Texture archerTexture;
    public Texture priestTexture;
    public Texture mageTexture;
    public Texture paladinTexture;

    public int AnimateFireBallCounter;
    public float startTime;
    public float intervalTime;

    public bool FireballFlag;
    public List<Texture> pop_explosion;

    void Awake()
    {
        intervalTime = 0.1f;
        AnimateFireBallCounter = 0;
        pop_explosion = new List<Texture>();
        pop_explosion.Add(pop_explosion0001);
        pop_explosion.Add(pop_explosion0002);
        pop_explosion.Add(pop_explosion0003);
        pop_explosion.Add(pop_explosion0004);
        pop_explosion.Add(pop_explosion0005);
        pop_explosion.Add(pop_explosion0006);
        pop_explosion.Add(pop_explosion0007);
        pop_explosion.Add(pop_explosion0008);
        pop_explosion.Add(pop_explosion0009);
        pop_explosion.Add(pop_explosion0010);
        pop_explosion.Add(pop_explosion0011);
        pop_explosion.Add(pop_explosion0012);
        pop_explosion.Add(pop_explosion0013);
        pop_explosion.Add(pop_explosion0014);
        pop_explosion.Add(pop_explosion0015);
        pop_explosion.Add(pop_explosion0016);
        pop_explosion.Add(pop_explosion0017);
        pop_explosion.Add(pop_explosion0018);
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
        if (AnimateFireBallCounter > 0)
        {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400), pop_explosion[pop_explosion.Count - AnimateFireBallCounter], ScaleMode.ScaleToFit, true, 0); // TODO hardcorded position
        }
    }

    void TriggerMageActiveSkill()
    {
        GameObject.Find("Monster(Clone)").GetComponent<MonsterAttacked>().AttackedByFireball();
        FireballFlag = true; 
        AnimateFireBallCounter = pop_explosion.Count;
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
        if (AnimateFireBallCounter > 0)
        {
            if (FireballFlag)
            {
                startTime = Time.time;
                FireballFlag = false;
            }
            if (Time.time - startTime > intervalTime)
            {
                startTime = Time.time;
                AnimateFireBallCounter--;
            }
        }
    }
}
