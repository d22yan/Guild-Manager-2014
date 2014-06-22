using UnityEngine;
using System.Collections;

public static class Constant {
	public static string buttonShop = "Shop";
	public static string buttonHire = "Hire";
	public static string buttonResume = "Resume";
	public static string buttonBack = "Back";

	public static string sceneBattleScreen = "battle_screen";
	public static string sceneMapScreen = "map_screen";

    public static string itemTitleArcher = "Archer";
	public static string itemDescriptionArcher = "Archers grant bonus Critical and deal damage.";
	public static int itemCostArcher = 1;
	public static int itemIncrementArcher = 1;
    public static string itemPassiveTypeArcher = "Damage";

	public static string itemTitleMage = "Mage";
    public static string itemDescriptionMage = "Mages grant bonus Attack and deal damage.";
	public static int itemCostMage = 1;
	public static int itemIncrementMage = 1;
    public static string itemPassiveTypeMage = "Damage";

	public static string itemTitlePriest = "Priest";
    public static string itemDescriptionPriest = "Priests grant bonus Health and perform healing.";
	public static int itemCostPriest = 1;
	public static int itemIncrementPriest = 1;
    public static string itemPassiveTypePriest = "Healing";

	public static string itemTitlePaladin = "Paladin";
    public static string itemDescriptionPaladin = "Paladin grant bonus Defense and perform healing.";
	public static int itemCostPaladin = 1;
	public static int itemIncrementPaladin = 1;
    public static string itemPassiveTypePaladin = "Healing";

	public static string itemTitleAttack = "Attack";
	public static string itemDescriptionAttack = "Attack increases your damage on monsters.";
	public static int itemCostAttack = 1;
	public static int itemIncrementAttack = 1;

	public static string itemTitleDefense = "Defense";
    public static string itemDescriptionDefense = "Defense increases your resistance to damage.";
	public static int itemCostDefense = 1;
	public static int itemIncrementDefense = 1;

	public static string itemTitleHealth = "Health";
    public static string itemDescriptionHealth = "Health increases your maximum hit points.";
	public static int itemCostHealth = 1;
	public static int itemIncrementHealth = 1;

	public static string itemTitleCritical = "Critical";
	public static string itemDescriptionCritical = "Critical increases your critical hit damage.";
	public static int itemCostCritical = 1;
	public static int itemIncrementCritical = 1;

    

    public static int InitialPlayerGold = 1000;
    public static int InitialPlayerAttack = 1;
    public static int InitialPlayerDefense = 1;
    public static int InitialPlayerCritical = 1;
    public static int InitialPlayerHealth = 100;

	public static int InitialGuildClassQuantity = 0;
	public static int InitialGuildClassLevel = 1;
	public static int InitialGuildClassRateModifier = 1;

	public static float RateGoldLossOnDeath = 0.1f;

	public static int InitialMonsterAttackSpeed = 1;
	public static int InitialMonsterAttackDamage = 1;
	public static int InitialMonsterMaxHealth = 100;
	public static int InitialMonsterCurrentHealth = 100;
	public static int InitialMonsterGoldDrop = 5;

    public static int DelayGuildMemberInitialAttack = 1;
    public static int DelayMonsterInitialAttack = 1;

    public static float AnimateShrinkOnMonsterAttacked = 0.9f;
}
