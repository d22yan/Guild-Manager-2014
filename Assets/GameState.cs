using UnityEngine;
using System.Collections;

public static class GameState{

	public static int PlayerGold {get; set;}
    public static int HiredWarriors { get; set; }
    public static int HiredMages { get; set; }
    public static int HiredPriests { get; set; }
    public static int HiredPaladins { get; set; }

	static GameState() {
        HiredMages = 0;
        HiredPaladins = 0;
        HiredPriests = 0;
        HiredWarriors = 0;
		PlayerGold = 0;
	}
}
