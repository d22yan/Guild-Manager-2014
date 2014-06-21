using UnityEngine;
using System.Collections;

public class GuildStatus {

    public GuildClass Archer { get; set; }
    public GuildClass Mage { get; set; }
    public GuildClass Priest { get; set; }
    public GuildClass Paladin { get; set; }

    public GuildStatus() {
        Archer = new GuildClass();
        Mage = new GuildClass();
        Priest = new GuildClass();
        Paladin = new GuildClass();
    }
}
