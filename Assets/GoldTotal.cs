using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using System.Collections.Generic;

public class GoldTotal : MonoBehaviour {
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

    delegate void StatusDelegate(int increment);
    List<StatusDelegate> statusDelegates;
    delegate int ClassDelegate(int increment);
    List<ClassDelegate> classDelegates;

    public List<ShopItem> hireItems;
    public List<ShopItem> statusItems;

    void DrawShopTab() {
        GUI.BeginGroup(new Rect (groupPosition.x, groupPosition.y, groupSize.x, groupSize.y));
        GUI.Box(new Rect (boxPosition.x, boxPosition.y, boxSize.x, boxSize.y), shopTexture);
        for (int i = 0; i < statusItems.Capacity; i++) {
            GUI.Box(new Rect(itemPosition.x, itemPosition.y + itemSize.y * i, itemSize.x, itemSize.y), shopItemTexture);
            GUI.Box(new Rect(iconPosition.x, iconPosition.y + itemSize.y * i, iconSize.x, iconSize.y), statusItems[i].Texture);
            GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + itemSize.y * i, itemDescriptionSize.x, itemDescriptionSize.y), statusItems[i].Description);
            GUI.Label(new Rect(buyButtonPosition.x - 20, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), "$" + GameState.State.ItemCosts[statusItems[i].Name].ToString());
            if (GameState.State.PlayerGold >= GameState.State.ItemCosts[statusItems[i].Name]) {
                if (GUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
                    statusDelegates[i](statusItems[i].Increment);
                    GameState.State.PlayerGold -= GameState.State.ItemCosts[statusItems[i].Name];
                    GameState.State.ItemCosts[statusItems[i].Name]++;
                }
            }
        }
        GUI.EndGroup();
	}

	void DrawHireTab() {
		GUI.BeginGroup (new Rect (groupPosition.x, groupPosition.y, groupSize.x, groupSize.y));
		GUI.Box (new Rect (boxPosition.x, boxPosition.y, boxSize.x, boxSize.y), shopTexture);
        for (int i = 0; i < hireItems.Capacity; i++ ) {
            GUI.Box(new Rect(itemPosition.x, itemPosition.y + itemSize.y * i, itemSize.x, itemSize.y), shopItemTexture);
            GUI.Box(new Rect(iconPosition.x, iconPosition.y + itemSize.y * i, iconSize.x, iconSize.y), hireItems[i].Texture);
            GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + itemSize.y * i, itemDescriptionSize.x, itemDescriptionSize.y), hireItems[i].Description);
            GUI.Label(new Rect(buyButtonPosition.x - 20, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), "$" + GameState.State.HireCosts[hireItems[i].Name].ToString());
            if (GameState.State.PlayerGold >= GameState.State.HireCosts[hireItems[i].Name]) {
                if (GUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
                    classDelegates[i](hireItems[i].Increment);
                    GameState.State.PlayerGold -= GameState.State.HireCosts[hireItems[i].Name];
                    GameState.State.HireCosts[hireItems[i].Name]++;
                }
            }
        }
		GUI.EndGroup ();
	}

    void InitializeShopItems() {
        statusDelegates = new List<StatusDelegate>() { 
            (i) => GameState.State.PlayerStatus.setAttack(GameState.State.PlayerStatus.getAttack() + i),
            (i) => GameState.State.PlayerStatus.setDefense(GameState.State.PlayerStatus.getDefense() + i),
            (i) => GameState.State.PlayerStatus.setHealth(GameState.State.PlayerStatus.getHealth() + i),
            (i) => GameState.State.PlayerStatus.setCritical(GameState.State.PlayerStatus.getCritical() + i)
        };

        classDelegates = new List<ClassDelegate>() { 
            (i) => GameState.State.PlayerStatus.GuildStatus.Mage.Quantity += i,
            (i) => GameState.State.PlayerStatus.GuildStatus.Paladin.Quantity += i,
            (i) => GameState.State.PlayerStatus.GuildStatus.Priest.Quantity += i,
            (i) => GameState.State.PlayerStatus.GuildStatus.Archer.Quantity += i

        };

        ShopItem archer = new ShopItem(Constant.itemTitleArcher, Constant.itemDescriptionArcher, Constant.itemCostArcher, Constant.itemIncrementArcher, archerTexture);
        ShopItem mage = new ShopItem(Constant.itemTitleMage, Constant.itemDescriptionMage, Constant.itemCostMage, Constant.itemIncrementMage, mageTexture);
        ShopItem priest = new ShopItem(Constant.itemTitlePriest, Constant.itemDescriptionPriest, Constant.itemCostPriest, Constant.itemIncrementPriest, priestTexture);
        ShopItem paladin = new ShopItem(Constant.itemTitlePaladin, Constant.itemDescriptionPaladin, Constant.itemCostPaladin, Constant.itemIncrementPaladin, paladinTexture);

        ShopItem attack = new ShopItem(Constant.itemTitleAttack, Constant.itemDescriptionAttack, Constant.itemCostAttack, Constant.itemIncrementAttack, attackTexture);
        ShopItem defense = new ShopItem(Constant.itemTitleDefense, Constant.itemDescriptionDefense, Constant.itemCostDefense, Constant.itemIncrementDefense, defenseTexture);
        ShopItem health = new ShopItem(Constant.itemTitleHealth, Constant.itemDescriptionHealth, Constant.itemCostHealth, Constant.itemIncrementHealth, healthTexture);
        ShopItem critical = new ShopItem(Constant.itemTitleCritical, Constant.itemDescriptionCritical, Constant.itemCostCritical, Constant.itemIncrementCritical, criticalTexture);

        hireItems = new List<ShopItem>() { mage, paladin, priest, archer };
        statusItems = new List<ShopItem>() { attack, defense, health, critical };
    }

    void InitializeVector() {
        boxPosition = new Vector2(0, 0);
        itemPosition = new Vector2(0, 0);
        boxSize = new Vector2(Screen.width, Screen.height - (Screen.height * 0.2f + 20));
        buyButtonPosition = new Vector2 (Screen.width - 75, itemPosition.y + 70);
        buyButtonSize = new Vector2 (50, 20);
        groupPosition = new Vector2(0, Screen.height * 0.2f + 20);
        groupSize = new Vector2(Screen.width, Screen.height - (Screen.height * 0.2f + 20) );
        iconPosition = new Vector2 (10, 10);
        itemSize = new Vector2(Screen.width, 100);
        iconSize = new Vector2 (itemSize.y - 20, itemSize.y - 20);
        itemDescriptionPosition = new Vector2 (iconSize.x + 20, 10);
        itemDescriptionSize = new Vector2 (itemSize.x - (iconSize.x + 20 + buyButtonSize.x + 20) , itemSize.y - 20);
        itemPricePosition = new Vector2 (buyButtonPosition.x, buyButtonPosition.y - 40);
        itemPriceSize = new Vector2 (buyButtonSize.x, buyButtonSize.y);
        tabButtonPosition = new Vector2(0, Screen.height * 0.2f);
        tabButtonSize = new Vector2(Screen.width * 0.5f, 20);
    }

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width - 50, 0, 50, 20), GameState.State.PlayerGold.ToString())) {
			isShopDisplayed = !isShopDisplayed;
		}

		if (isShopDisplayed) {
			if (GUI.Button (new Rect (tabButtonPosition.x, tabButtonPosition.y, tabButtonSize.x, tabButtonSize.y), Constant.buttonShop)) {
				DrawTab = DrawShopTab;
			}
			if (GUI.Button (new Rect (tabButtonPosition.x + tabButtonSize.x, tabButtonPosition.y, tabButtonSize.x, tabButtonSize.y), Constant.buttonHire)) {
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
