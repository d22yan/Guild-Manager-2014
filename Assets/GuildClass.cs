using UnityEngine;
using System.Collections;

public class GuildClass {

	public int Quantity { get; set; }
	public int Level { get; set; }
    public int RateModifier { get; set; }

    public GuildClass() {
        Quantity = 0;
        Level = 1;
        RateModifier = 1;
    }

    public int GetActiveStat() {
		return Level * Quantity;
	}

    public int GetPassiveStat() {
        return Level * Quantity;
    }
    
    public float GetPassiveRate() {
        return 5f / (Level * RateModifier);
    }


}
