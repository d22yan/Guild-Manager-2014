using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            }
            file.Close();
        }
    }
}
