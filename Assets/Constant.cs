using UnityEngine;
using System.Collections;

public static class Constant
{
    public const string buttonShop = "Shop";
    public const string buttonHire = "Hire";
    public const string buttonResume = "Continue";
    public const string buttonBegin = "Begin";
    public const string buttonBack = "Back";

    public const string battleScene1 = "battleScene1";
    public const string battleScene2 = "battleScene2";
    public const string battleScene3 = "battleScene3";
    public const string battleScene4 = "battleScene4";
    public const string battleScene5 = "battleScene5";

    public const string sceneMapScreen = "map_screen";

    public const string itemTitleArcher = "Archer";
    public const string itemDescriptionArcher = "Archers deal damage, give bonus Critical.";
    public const int itemCostArcher = 1;
    public const int itemIncrementArcher = 1;
    public const string itemPassiveTypeArcher = "Damage";

    public const string itemTitleMage = "Mage";
    public const string itemDescriptionMage = "Mages deal damage, give bonus Attack.";
    public const int itemCostMage = 1;
    public const int itemIncrementMage = 1;
    public const string itemPassiveTypeMage = "Damage";

    public const string itemTitlePriest = "Priest";
    public const string itemDescriptionPriest = "Priests perform healing, give bonus Health.";
    public const int itemCostPriest = 1;
    public const int itemIncrementPriest = 1;
    public const string itemPassiveTypePriest = "Healing";

    public const string itemTitlePaladin = "Paladin";
    public const string itemDescriptionPaladin = "Paladin perform healing, give bonus Defense.";
    public const int itemCostPaladin = 1;
    public const int itemIncrementPaladin = 1;
    public const string itemPassiveTypePaladin = "Healing";

    public const string itemTitleAttack = "Attack";
    public const string itemDescriptionAttack = "Attack increases your damage on monsters.";
    public const int itemCostAttack = 1;
    public const int itemIncrementAttack = 1;

    public const string itemTitleDefense = "Defense";
    public const string itemDescriptionDefense = "Defense increases your resistance to damage.";
    public const int itemCostDefense = 1;
    public const int itemIncrementDefense = 1;

    public const string itemTitleHealth = "Health";
    public const string itemDescriptionHealth = "Health increases your maximum hit points.";
    public const int itemCostHealth = 1;
    public const int itemIncrementHealth = 1;

    public const string itemTitleCritical = "Critical";
    public const string itemDescriptionCritical = "Critical increases your critical hit damage.";
    public const int itemCostCritical = 1;
    public const int itemIncrementCritical = 1;

    public const int InitialPlayerGold = 10;
    public const int InitialPlayerAttack = 10;
    public const int InitialPlayerDefense = 10;
    public const int InitialPlayerCritical = 10;
    public const int InitialPlayerHealth = 10;

    public const int InitialGuildClassQuantity = 0;
    public const int InitialGuildClassLevel = 1;
    public const int InitialGuildClassRateModifier = 1;

    public const float RateGoldLossOnDeath = 0.1f;

    public const int InitialMonsterAttackSpeed = 2;
    public const int InitialMonsterAttackDamage = 10;
    public const int InitialMonsterMaxHealth = 100;
    public const int InitialMonsterCurrentHealth = 100;
    public const int InitialMonsterGoldDrop = 5;

    public const int DelayGuildMemberInitialAttack = 1;
    public const int DelayMonsterInitialAttack = 1;

    public const float AnimationShrinkOnMonsterAttacked = 0.9f;
    public static readonly Vector2 AnimationTranslateDamageBox = new Vector2(0, 0.001f);

    public const int DisplayGuildMemberDamageOffset = 10;
}
