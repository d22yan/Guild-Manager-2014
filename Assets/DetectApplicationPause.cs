using UnityEngine;
using System.Collections;

public class DetectApplicationPause : MonoBehaviour {
    public bool paused;
    void OnGUI() {
        if (paused)
        {
            GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
        }
    }
#if UNITY_ANDROID
    void OnApplicationPause(bool pauseStatus) {
        Debug.Log("paused: " + paused.ToString());
        GameState.State.PlayerGold = 1000;
        paused = pauseStatus;
    }

    void OnApplicationFocus(bool pauseStatus)
    {
        if (pauseStatus)
        {
            GameState.State.PlayerGold += 10;
        }
        else {
            GameState.State.PlayerGold += 100;
        }
    }
#endif
}
