using UnityEngine;
using System.Collections;

public static class ScalingGUI {

    private static float BaseDPI = 150;

    public static bool Button(Rect rectangle, string value) 
    {
        Rect ScaledRectangle = new Rect(rectangle.x, rectangle.y, GetScalingFactor() * rectangle.width, GetScalingFactor() * rectangle.height);
        return GUI.Button(rectangle, value);
    }

    public static float GetScalingFactor()
    {
        return (Screen.dpi == 0) ? 1 : Screen.dpi / BaseDPI;
    }

}
