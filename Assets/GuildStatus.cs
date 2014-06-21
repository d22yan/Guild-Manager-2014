using UnityEngine;
using System.Collections;

public class GuildStatus {

	struct Archer {
		int Quantity { get; set; };
		int Level { get; set; };
		int Attack;
        int Defense;
        int GetArcherAttack() {
			
		}
	}

	struct Mage {
        int Quantity { get; set; };
        int Level { get; set; };
        int Attack;
        int Critical;
        int GetMageAttack() {
			
		}
	}

    struct Priest {
        int Quantity { get; set; };
        int Level { get; set; };
        int Health;
        int HealthRegen;
        int GetPriestHealth() {
			
		}
    }

    struct Paladin {
        int Quantity { get; set; };
        int Level { get; set; };
        int Defense;
        int HealthRegen;
        int GetPaladinDefense() {
			
		}

    }


    
    public int HiredArcher { get; set; }
    public int HiredMages { get; set; }
    public int HiredPriests { get; set; }
    public int HiredPaladins { get; set; }



    public GuildStatus() {
        HiredMages = 0;
        HiredPaladins = 0;
        HiredPriests = 0;
        HiredArcher = 0;
    }
}
