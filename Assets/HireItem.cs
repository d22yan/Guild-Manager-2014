using UnityEngine;
using System.Collections;

public class HireItem : ShopItem {
    public string PassiveType { get; set; }
    
	public HireItem(string name, string description, int cost, int increment, Texture texture, string passiveType)
        : base(name, description, cost, increment, texture)
    {
        PassiveType = passiveType;
    }
}
