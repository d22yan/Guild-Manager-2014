using UnityEngine;
using System.Collections;
using System;

public static class ScalingGUI {
    public static void SetSkin(GUISkin skin)
    {
        skin.button.fontSize = (int)Math.Round(Screen.width * 2d / 100);
        skin.label.fontSize = (int)Math.Round(Screen.width * 1.5d / 100);
        GUI.skin = skin;
    }

    public static bool Button(Rect percentageRectangle, string value) 
    {
        var scaledRectangle = new Rect(
            Screen.width * percentageRectangle.x / 100,
            Screen.height * percentageRectangle.y / 100,
            Screen.width * percentageRectangle.width / 100,
            Screen.height * percentageRectangle.height / 100
        );

        return GUI.Button(scaledRectangle, value);
    }

    public static void Box(Rect percentageRectangle, Texture texture)
    {
        var scaledRectangle = new Rect(
            Screen.width * percentageRectangle.x / 100,
            Screen.height * percentageRectangle.y / 100,
            Screen.width * percentageRectangle.width / 100,
            Screen.height * percentageRectangle.height / 100
        );

        GUI.Box(scaledRectangle, texture);
    }

    public static void Label(Rect percentageRectangle, string value)
    {
        var scaledRectangle = new Rect(
            Screen.width * percentageRectangle.x / 100,
            Screen.height * percentageRectangle.y / 100,
            Screen.width * percentageRectangle.width / 100,
            Screen.height * percentageRectangle.height / 100
        );

        GUI.Label(scaledRectangle, value);
    }

    public static void BeginGroup(Rect percentageRectangle)
    {
        var scaledRectangle = new Rect(
            Screen.width * percentageRectangle.x / 100,
            Screen.height * percentageRectangle.y / 100,
            Screen.width * percentageRectangle.width / 100,
            Screen.height * percentageRectangle.height / 100
        );

        GUI.BeginGroup(scaledRectangle);
    }

    public static void EndGroup()
    {
        GUI.EndGroup();
    }

}
