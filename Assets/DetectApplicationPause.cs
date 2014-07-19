using UnityEngine;
using System.Collections;

public class DetectApplicationPause : MonoBehaviour {
    public bool paused;
    void OnGUI() {
        if (paused)
        {
            GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
            GameState.State.PlayerGold = 0;
        }
    }
    void OnApplicationPause(bool pauseStatus) {
        Debug.Log("paused");
        paused = pauseStatus;
    }
}
