using UnityEngine;
using System.Collections;

public class GuildStatus {

    public GuildClass Archer { get; set; }
    public GuildClass Mage { get; set; }
    public GuildClass Priest { get; set; }
    public GuildClass Paladin { get; set; }

    public int PaladinBuffStacks { get; set; }
    public int ArcherBuffStacks { get; set; }

    public int BasePaladinBuffStacks { get; set; }
    public int BaseArcherBuffStacks { get; set; }

    public int MageSkillCooldown { get; set; }
    public int PriestSkillCooldown { get; set; }
    public int PaladinSkillCooldown { get; set; }
    public int ArcherSkillCooldown { get; set; }

    public int BaseMageSkillCooldown { get; set; }
    public int BasePriestSkillCooldown { get; set; }
    public int BasePaladinSkillCooldown { get; set; }
    public int BaseArcherSkillCooldown { get; set; }

    public GuildStatus() {
        Archer = new GuildClass();
        Mage = new GuildClass();
        Priest = new GuildClass();
        Paladin = new GuildClass();

        PaladinBuffStacks = 0;
        ArcherBuffStacks = 0;

        BaseArcherBuffStacks = 10;
        BasePaladinBuffStacks = 10;
        
        MageSkillCooldown = 0;
        PriestSkillCooldown = 0;
        PaladinSkillCooldown = 0;
        ArcherSkillCooldown = 0;

        BaseMageSkillCooldown = 20;
        BasePriestSkillCooldown = 20;
        BasePaladinSkillCooldown = 20;
        BaseArcherSkillCooldown = 20;
    }
}
