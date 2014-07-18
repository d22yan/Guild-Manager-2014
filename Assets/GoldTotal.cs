using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using System.Collections.Generic;

public class GoldTotal : MonoBehaviour {
    public GUISkin greenSkin;
    public GUISkin blueSkin;
    public GUISkin yellowSkin;

	public Texture shopTexture;
	public Texture shopItemTexture;
    public Texture attackTexture;
    public Texture defenseTexture;
    public Texture healthTexture;
    public Texture criticalTexture;
    public Texture archerTexture;
    public Texture priestTexture;
    public Texture mageTexture;
    public Texture paladinTexture;

    public Vector2 groupPosition;
    public Vector2 groupSize;
    public Vector2 boxPosition;
    public Vector2 boxSize;
    public Vector2 tabButtonPosition;
    public Vector2 tabButtonSize;
    public Vector2 itemPosition;
    public Vector2 itemSize;
    public Vector2 buyButtonSize;
    public Vector2 buyButtonPosition;
    public Vector2 iconPosition;
    public Vector2 iconSize;
    public Vector2 itemDescriptionPosition;
    public Vector2 itemDescriptionSize;
    public Vector2 itemPricePosition;
    public Vector2 itemPriceSize;

    public bool isShopDisplayed;

    public delegate void drawTabDelegate();
    public drawTabDelegate DrawTab;

    delegate void IncrementDelegate(int increment);
    List<IncrementDelegate> statusIncrementDelegates;
    List<IncrementDelegate> classIncrementDelegates;

    delegate int NumberDelegate();
    List<NumberDelegate> statusDelegates;
    List<NumberDelegate> statusBonusDelegates;
    List<NumberDelegate> classDelegates;
    List<NumberDelegate> classPassiveDelegates;

    public List<HireItem> hireItems;
    public List<ShopItem> shopItems;

    void DrawShopTab() {
        ScalingGUI.SetSkin(yellowSkin);
        ScalingGUI.BeginGroup(new Rect(groupPosition.x, groupPosition.y, groupSize.x, groupSize.y));
        for (int i = 0; i < shopItems.Capacity; i++) {
            ScalingGUI.Box(new Rect(itemPosition.x, itemPosition.y + itemSize.y * i, itemSize.x, itemSize.y), shopItemTexture);
            ScalingGUI.Box(new Rect(iconPosition.x, iconPosition.y + itemSize.y * i, iconSize.x, iconSize.y), shopItems[i].Texture);
            ScalingGUI.Label(new Rect(
                itemDescriptionPosition.x, itemDescriptionPosition.y + itemSize.y * i, 
                itemDescriptionSize.x, itemDescriptionSize.y),
                string.Format(
                    "Increase your {0} by {1}.\n{2}\n\nYour current {0}: {4}\nBonus {0} from {3}s in Guild: {5}",
                    shopItems[i].Name, shopItems[i].Increment, shopItems[i].Description, hireItems[i].Name,
                    statusDelegates[i](), statusBonusDelegates[i]()));
            ScalingGUI.Label(new Rect(itemPricePosition.x, itemPricePosition.y + itemSize.y * i, itemPriceSize.x, itemPriceSize.y), "$" + GameState.State.ItemCosts[shopItems[i].Name].ToString());
            if (GameState.State.PlayerGold >= GameState.State.ItemCosts[shopItems[i].Name]) {
                if (ScalingGUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), "Buy"))
                {
                    statusIncrementDelegates[i](shopItems[i].Increment);
                    GameState.State.PlayerGold -= GameState.State.ItemCosts[shopItems[i].Name];
                    GameState.State.ItemCosts[shopItems[i].Name]++;
                }
            }
        }
        ScalingGUI.EndGroup();
	}

	void DrawHireTab() {
        ScalingGUI.SetSkin(yellowSkin);
        ScalingGUI.BeginGroup(new Rect(groupPosition.x, groupPosition.y, groupSize.x, groupSize.y));
        for (int i = 0; i < hireItems.Capacity; i++ ) {
            ScalingGUI.Box(new Rect(itemPosition.x, itemPosition.y + itemSize.y * i, itemSize.x, itemSize.y), shopItemTexture);
            ScalingGUI.Box(new Rect(iconPosition.x, iconPosition.y + itemSize.y * i, iconSize.x, iconSize.y), hireItems[i].Texture);
            ScalingGUI.Label(new Rect(
                itemDescriptionPosition.x, itemDescriptionPosition.y + itemSize.y * i,
                itemDescriptionSize.x, itemDescriptionSize.y), 
                string.Format(
                    "Recruit {1} more {0}.\n{2}\n\nNumber of {0}s in Guild: {4}\n{3} over time from {0}s: {5}",
                    hireItems[i].Name, hireItems[i].Increment, hireItems[i].Description, hireItems[i].PassiveType,
                    classDelegates[i](), classPassiveDelegates[i]()));
            ScalingGUI.Label(new Rect(itemPricePosition.x, itemPricePosition.y + itemSize.y * i, itemPriceSize.x, itemPriceSize.y), "$" + GameState.State.HireCosts[hireItems[i].Name].ToString());
            if (GameState.State.PlayerGold >= GameState.State.HireCosts[hireItems[i].Name]) {
                if (ScalingGUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), "Buy"))
                {
                    classIncrementDelegates[i](hireItems[i].Increment);
                    GameState.State.PlayerGold -= GameState.State.HireCosts[hireItems[i].Name];
                    GameState.State.HireCosts[hireItems[i].Name]++;
                }
            }
        }
        ScalingGUI.EndGroup();
	}

    void InitializeShopItems() {
        statusDelegates = new List<NumberDelegate>() { 
            () => GameState.State.PlayerStatus.Attack,
            () => GameState.State.PlayerStatus.Critical,
            () => GameState.State.PlayerStatus.Defense,
            () => GameState.State.PlayerStatus.Health
        };

        statusBonusDelegates = new List<NumberDelegate>() { 
            () => GameState.State.PlayerStatus.GuildStatus.Mage.GetActiveStat(),
            () => GameState.State.PlayerStatus.GuildStatus.Archer.GetActiveStat(),
            () => GameState.State.PlayerStatus.GuildStatus.Paladin.GetActiveStat(),
            () => GameState.State.PlayerStatus.GuildStatus.Priest.GetActiveStat()
        };

        classDelegates = new List<NumberDelegate>() { 
            () => GameState.State.PlayerStatus.GuildStatus.Mage.Quantity,
            () => GameState.State.PlayerStatus.GuildStatus.Archer.Quantity,
            () => GameState.State.PlayerStatus.GuildStatus.Paladin.Quantity,
            () => GameState.State.PlayerStatus.GuildStatus.Priest.Quantity
        };

        classPassiveDelegates = new List<NumberDelegate>() { 
            () => GameState.State.PlayerStatus.GuildStatus.Mage.GetPassiveStat(),
            () => GameState.State.PlayerStatus.GuildStatus.Archer.GetPassiveStat(),
            () => GameState.State.PlayerStatus.GuildStatus.Paladin.GetPassiveStat(),
            () => GameState.State.PlayerStatus.GuildStatus.Priest.GetPassiveStat()
        };

        statusIncrementDelegates = new List<IncrementDelegate>() { 
            (i) => GameState.State.PlayerStatus.Attack += i,
            (i) => GameState.State.PlayerStatus.Critical += i,
            (i) => GameState.State.PlayerStatus.Defense += i,
            (i) => GameState.State.PlayerStatus.Health += i
        };

        classIncrementDelegates = new List<IncrementDelegate>() { 
            (i) => GameState.State.PlayerStatus.GuildStatus.Mage.Quantity += i,
            (i) => GameState.State.PlayerStatus.GuildStatus.Archer.Quantity += i,
            (i) => GameState.State.PlayerStatus.GuildStatus.Paladin.Quantity += i,
            (i) => GameState.State.PlayerStatus.GuildStatus.Priest.Quantity += i
        };
        
        hireItems = new List<HireItem>() { 
            new HireItem(Constant.itemTitleMage, Constant.itemDescriptionMage, Constant.itemCostMage, Constant.itemIncrementMage, mageTexture, Constant.itemPassiveTypeMage),
            new HireItem(Constant.itemTitleArcher, Constant.itemDescriptionArcher, Constant.itemCostArcher, Constant.itemIncrementArcher, archerTexture, Constant.itemPassiveTypeArcher),
            new HireItem(Constant.itemTitlePaladin, Constant.itemDescriptionPaladin, Constant.itemCostPaladin, Constant.itemIncrementPaladin, paladinTexture, Constant.itemPassiveTypePaladin),
            new HireItem(Constant.itemTitlePriest, Constant.itemDescriptionPriest, Constant.itemCostPriest, Constant.itemIncrementPriest, priestTexture, Constant.itemPassiveTypePriest)
        };

        shopItems = new List<ShopItem>() { 
            new ShopItem(Constant.itemTitleAttack, Constant.itemDescriptionAttack, Constant.itemCostAttack, Constant.itemIncrementAttack, attackTexture),
            new ShopItem(Constant.itemTitleCritical, Constant.itemDescriptionCritical, Constant.itemCostCritical, Constant.itemIncrementCritical, criticalTexture),
            new ShopItem(Constant.itemTitleDefense, Constant.itemDescriptionDefense, Constant.itemCostDefense, Constant.itemIncrementDefense, defenseTexture),
            new ShopItem(Constant.itemTitleHealth, Constant.itemDescriptionHealth, Constant.itemCostHealth, Constant.itemIncrementHealth, healthTexture)
        };
    }

    void InitializeVector() {
        var shopWidth = 80;
        var shopItemHeight = 18;
        var shopHeight = shopItemHeight * 4;

        tabButtonSize = new Vector2(shopWidth / 2, 8);

        var shopPositionX = (100 - shopWidth) / 2;
        var shopPositionY = (100 - shopHeight + tabButtonSize.y) / 2;

        tabButtonPosition = new Vector2(shopPositionX, shopPositionY - 8);

        groupPosition = new Vector2(shopPositionX, shopPositionY);
        groupSize = new Vector2(shopWidth, shopHeight);

        itemPosition = new Vector2(0, 0);
        itemSize = new Vector2(shopWidth, shopItemHeight);

        buyButtonPosition = new Vector2 (shopWidth - 11, shopItemHeight - 8 - 16/9f);
        buyButtonSize = new Vector2 (10, 8);

        iconPosition = new Vector2(2 * 9 / 16, 2);
        iconSize = new Vector2 ((itemSize.y - 4) * 9 / 16, itemSize.y - 4);

        itemDescriptionPosition = new Vector2(iconPosition.x + iconSize.x + 1, 1);
        itemDescriptionSize = new Vector2(itemSize.x - (itemDescriptionPosition.x + 1 + buyButtonSize.x + 1), itemSize.y - 2);

        itemPricePosition = new Vector2 (buyButtonPosition.x, 1);
        itemPriceSize = new Vector2 (buyButtonSize.x, buyButtonSize.y);
    }

	void OnGUI() {
        ScalingGUI.SetSkin(greenSkin);
        if (ScalingGUI.Button(new Rect(80, 0, 20, 10), "$" + GameState.State.PlayerGold.ToString()))
        {
			isShopDisplayed = !isShopDisplayed;
		}
        ScalingGUI.SetSkin(blueSkin);
		if (isShopDisplayed) {
            if (ScalingGUI.Button(new Rect(tabButtonPosition.x, tabButtonPosition.y, tabButtonSize.x, tabButtonSize.y), Constant.buttonShop))
            {
				DrawTab = DrawShopTab;
			}
            if (ScalingGUI.Button(new Rect(tabButtonPosition.x + tabButtonSize.x, tabButtonPosition.y, tabButtonSize.x, tabButtonSize.y), Constant.buttonHire))
            {
				DrawTab = DrawHireTab;
			}
			DrawTab();
		}
	}

    void Awake() {
        DrawTab = DrawShopTab;
        InitializeVector();
        InitializeShopItems();
    }

	// Use this for initialization
	void Start () {
		isShopDisplayed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
