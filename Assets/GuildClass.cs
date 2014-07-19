using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class GuildClass {

	public int Quantity { get; set; }
	public int Level { get; set; }
    public int RateModifier { get; set; }

    public GuildClass() {
        Quantity = Constant.InitialGuildClassQuantity;
        Level = Constant.InitialGuildClassLevel;
        RateModifier = Constant.InitialGuildClassRateModifier;
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
