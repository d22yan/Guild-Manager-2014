using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class GameData {
    public int PlayerGold { get; set; }
    public Dictionary<string, int> ItemCosts { get; set; }
    public Dictionary<string, int> HireCosts { get; set; }
    public Dictionary<string, int> HireLevelCosts { get; set; }
    public PlayerStatus PlayerStatus { get; set; }
    public string PreviousScene { get; set; }
    public DateTime PreviousTime { get; set; }

    public GameData(GameState state)
    {
        PlayerGold = state.PlayerGold;
        ItemCosts = state.ItemCosts;
        HireCosts = state.HireCosts;
        HireLevelCosts = state.HireLevelCosts;
        PlayerStatus = state.PlayerStatus;
        PreviousScene = state.PreviousScene;
        PreviousTime = state.PreviousTime;
    }
}
