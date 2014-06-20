using UnityEngine;
using System.Collections;

public class ShopItem {


    public string Description { get; set; }
    public int Cost { get; set; }
    public string Name { get; set; }
    public Texture Texture { get; set; }
    public int Increment { get; set; }


    public ShopItem(string description, int cost, string name, Texture texture)
    {
        this.Description = description;
        this.Cost = cost;
        this.Name = name;
        this.Texture = texture;
    }

}
