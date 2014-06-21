using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameState{

	public static int PlayerGold { get; set; }
    public static Dictionary<string, int> ItemCosts { get; set; }
    public static Dictionary<string, int> HireCosts { get; set; }
    public static PlayerStatus PlayerStatus { get; set; }
    public static GuildStatus GuildStatus { get; set; }

    static GameState() {
		PlayerGold = 50;
        
        PlayerStatus = new PlayerStatus(1, 1, 1, 100);
        GuildStatus = new GuildStatus();
        ItemCosts = new Dictionary<string,int>();
        HireCosts = new Dictionary<string,int>();
        
        ItemCosts.Add(Constant.itemTitleAttack, Constant.itemCostAttack);
        ItemCosts.Add(Constant.itemTitleDefense, Constant.itemCostDefense);
        ItemCosts.Add(Constant.itemTitleCritical, Constant.itemCostCritical);
        ItemCosts.Add(Constant.itemTitleHealth, Constant.itemCostHealth);
        HireCosts.Add(Constant.itemTitleArcher, Constant.itemCostWarrior);
        HireCosts.Add(Constant.itemTitleMage, Constant.itemCostMage);
        HireCosts.Add(Constant.itemTitlePriest, Constant.itemCostPriest);
        HireCosts.Add(Constant.itemTitlePaladin, Constant.itemCostPaladin);
	}
}
