using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

    public static GameState State;

	public int PlayerGold { get; set; }
    public Dictionary<string, int> ItemCosts { get; set; }
    public Dictionary<string, int> HireCosts { get; set; }
    public PlayerStatus PlayerStatus { get; set; }

    void Awake() {
        if (State == null)
        {
            DontDestroyOnLoad(gameObject);
            State = this;

            PlayerGold = Constant.InitialPlayerGold;

            PlayerStatus = new PlayerStatus(
                Constant.InitialPlayerAttack, 
                Constant.InitialPlayerDefense,
                Constant.InitialPlayerCritical,
                Constant.InitialPlayerHealth
            );
            ItemCosts = new Dictionary<string, int>();
            HireCosts = new Dictionary<string, int>();

            ItemCosts.Add(Constant.itemTitleAttack, Constant.itemCostAttack);
            ItemCosts.Add(Constant.itemTitleDefense, Constant.itemCostDefense);
            ItemCosts.Add(Constant.itemTitleCritical, Constant.itemCostCritical);
            ItemCosts.Add(Constant.itemTitleHealth, Constant.itemCostHealth);
            HireCosts.Add(Constant.itemTitleArcher, Constant.itemCostArcher);
            HireCosts.Add(Constant.itemTitleMage, Constant.itemCostMage);
            HireCosts.Add(Constant.itemTitlePriest, Constant.itemCostPriest);
            HireCosts.Add(Constant.itemTitlePaladin, Constant.itemCostPaladin);
        }
        else if (State != this)
        {
            Destroy(gameObject);
        }
	}
}
