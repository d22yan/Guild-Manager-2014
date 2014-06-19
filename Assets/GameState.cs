using UnityEngine;
using System.Collections;

public static class GameState{

	public static int PlayerGold {get; set;}

	static GameState() {
		PlayerGold = 0;
	}
}
