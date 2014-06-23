using UnityEngine;
using System.Collections;

public static class Utility {
    public static void SetAlpha(this Material material, float value) {
        Color color = material.color;
        color.a = value;
        material.color = color;
    }
}
