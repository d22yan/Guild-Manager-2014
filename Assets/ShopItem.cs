using UnityEngine;
using System.Collections;

public class ShopItem {

    public int Cost { get; set; }
    public string Description { get; set; }
    public int Increment { get; set; }
    public string Name { get; set; }
    public Texture Texture { get; set; }
    
    public ShopItem(string name, string description, int cost, int increment, Texture texture)
    {
        this.Description = description;
        this.Cost = cost;
        this.Increment = increment;
        this.Name = name;
        this.Texture = texture;
    }

}
