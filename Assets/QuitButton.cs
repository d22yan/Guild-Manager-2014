using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {
    public GUISkin skin;

    void OnGUI()
    {
        ScalingGUI.SetSkin(skin);
        if (ScalingGUI.Button(new Rect(0, 90, 20, 10), "quit"))
        {
            Application.Quit();
        }
    }

}
