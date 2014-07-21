using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class ScalingGUI {
    private static Rect BuildScaledRectangle(Rect percentageRectangle)
    {
        return new Rect(
            Screen.width * percentageRectangle.x / 100,
            Screen.height * percentageRectangle.y / 100,
            Screen.width * percentageRectangle.width / 100,
            Screen.height * percentageRectangle.height / 100
        );
    }
    public static void SetSkin(GUISkin skin)
    {
        skin.button.fontSize = (int)Math.Round(Screen.width * 2d / 100);
        skin.label.fontSize = (int)Math.Round(Screen.width * 1.75d / 100);
        skin.box.fontSize = (int)Math.Round(Screen.width * 2d / 100);
        GUI.skin = skin;
    }

    public static bool Button(Rect percentageRectangle, string value) 
    {
        return GUI.Button(BuildScaledRectangle(percentageRectangle), value);
    }

    public static bool Button(Rect percentageRectangle, Texture texture)
    {
        return GUI.Button(BuildScaledRectangle(percentageRectangle), texture);
    }

    public static bool Button(Rect percentageRectangle, Texture texture, GUIStyle guiStyle)
    {
        return GUI.Button(BuildScaledRectangle(percentageRectangle), texture, guiStyle);
    }

    public static void Box(Rect percentageRectangle, Texture texture)
    {
        GUI.Box(BuildScaledRectangle(percentageRectangle), texture);
    }

    public static void Box(Rect percentageRectangle, string value)
    {
        GUI.Box(BuildScaledRectangle(percentageRectangle), value);
    }

    public static void Label(Rect percentageRectangle, string value)
    {
        GUI.Label(BuildScaledRectangle(percentageRectangle), value);
    }

    public static void DrawTexture(Rect percentageRectangle, Texture texture, ScaleMode scaleMode, bool alphaBlend, float imageAspect)
    {
        GUI.DrawTexture(BuildScaledRectangle(percentageRectangle), texture, scaleMode, alphaBlend, imageAspect);
    }

    public static void BeginGroup(Rect percentageRectangle)
    {
        GUI.BeginGroup(BuildScaledRectangle(percentageRectangle));
    }

    public static void EndGroup()
    {
        GUI.EndGroup();
    }

}
