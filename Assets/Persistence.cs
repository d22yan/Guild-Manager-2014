using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class Persistence {

    static string GameStateFileName = "GameState.dat";

    public static void Save()
    {
        Debug.Log(Application.persistentDataPath);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + GameStateFileName, FileMode.OpenOrCreate);
        GameData data = new GameData(GameState.State);
        binaryFormatter.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + GameStateFileName))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + GameStateFileName, FileMode.Open);
            GameData data = (GameData)binaryFormatter.Deserialize(file);
            if (data != null)
            {
                GameState.State.PlayerGold = data.PlayerGold;
                GameState.State.ItemCosts = data.ItemCosts;
                GameState.State.HireCosts = data.HireCosts;
                GameState.State.HireLevelCosts = data.HireLevelCosts;
                GameState.State.PlayerStatus = data.PlayerStatus;
                GameState.State.PreviousScene = data.PreviousScene;
                if (data.PreviousTime != new DateTime() && data.PreviousScene != null)
                { 
                    TimeSpan TimeDifference = System.DateTime.UtcNow - data.PreviousTime;
                    double SecondsPassed = TimeDifference.TotalSeconds;

                    Debug.Log(System.DateTime.UtcNow);
                    Debug.Log(SecondsPassed);

                    int level = (int)Char.GetNumericValue(data.PreviousScene[data.PreviousScene.Length - 1]);
                    Debug.Log("Level: " + level.ToString());
                    MonsterStats AverageMonsterStatus = new MonsterStats(2 / (float)level, 13 * level, 140 * level, 15 * level);

                    double NumberOfHealsPriest = SecondsPassed / GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveRate();
                    double TotalHealPriest = GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveStat() * NumberOfHealsPriest;
                    double NumberOfHealsPaladin = SecondsPassed / GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveRate();
                    double TotalHealPaladin = GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveStat() * NumberOfHealsPaladin;
                    double TotalHeal = TotalHealPaladin + TotalHealPriest + GameState.State.PlayerStatus.CurrentHealth;

                    double NumberOfMonsterHit = SecondsPassed / AverageMonsterStatus.AttackSpeed;
                    Debug.Log("AttackSpeed: " + AverageMonsterStatus.AttackSpeed.ToString());
                    double TotalDamageMonster = (AverageMonsterStatus.AttackDamage - GameState.State.PlayerStatus.GetTotalDefense()) * NumberOfMonsterHit;
                    Debug.Log("NumberOfMonsterHit: " + NumberOfMonsterHit.ToString());

                    Debug.Log("AverageMonsterStatus.AttackDamage: " + AverageMonsterStatus.AttackDamage.ToString());
                    Debug.Log("GameState.State.PlayerStatus.GetTotalDefense(): " + GameState.State.PlayerStatus.GetTotalDefense().ToString());

                    double SecondsPassedBeforeDeath = SecondsPassed;

                    Debug.Log("TotalHeal: " + TotalHeal.ToString());
                    Debug.Log("TotalDamageMonster: " + TotalDamageMonster.ToString());
                    if (TotalHeal < TotalDamageMonster)
                    {
                        double Ratio = TotalHeal / TotalDamageMonster;
                        SecondsPassedBeforeDeath *= Ratio;
                        GameState.State.PlayerStatus.CurrentHealth = GameState.State.PlayerStatus.Health;
                    }

                    double NumberOfHitsMage = SecondsPassedBeforeDeath / GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveRate();
                    double TotalDamageMage = GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveStat() * NumberOfHitsMage;
                    double NumberOfHitsArcher = SecondsPassedBeforeDeath / GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveRate();
                    double TotalDamageArcher = GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveStat() * NumberOfHitsArcher;
                    double TotalDamage = TotalDamageArcher + TotalDamageMage;

                    double NumberOfMonsterDeath = TotalDamage / AverageMonsterStatus.MaxHealth;
                    double TotalGold = NumberOfMonsterDeath * AverageMonsterStatus.GoldDrop / 2;
                    GameState.State.PlayerGold += (int) TotalGold;

                    if (TotalHeal < TotalDamageMonster)
                    {
                        GameState.State.PlayerGold = (int) (GameState.State.PlayerGold * (1.0f - Constant.RateGoldLossOnDeath));
                    }
                    GameState.State.PreviousTime = new DateTime();
                }
            }
            file.Close();
        }
    }
}
