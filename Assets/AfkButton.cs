using UnityEngine;
using System.Collections;

public class AfkButton : MonoBehaviour {

    public GUISkin skin;

    void OnGUI()
    {
        ScalingGUI.SetSkin(skin);
        if (ScalingGUI.Button(new Rect(80, 90, 20, 10), "afk"))
        {
            GameState.State.PreviousTime = System.DateTime.UtcNow;
            Persistence.Save();
            Application.Quit();
        }
    }
}
