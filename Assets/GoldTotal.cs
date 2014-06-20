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
    public Texture warriorTexture;
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

    delegate int StatusDelegate(int increment);
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
            GUI.Label(new Rect(buyButtonPosition.x - 20, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), statusItems[i].Cost.ToString());
            if (GameState.PlayerGold >= statusItems[i].Cost) {
                if (GUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
                    statusDelegates[i](statusItems[i].Increment);
                    GameState.PlayerGold -= statusItems[i].Cost;
                    statusItems[i].Cost++;
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
            GUI.Label(new Rect(buyButtonPosition.x - 20, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), hireItems[i].Cost.ToString());
            if (GameState.PlayerGold >= hireItems[i].Cost) {
                if (GUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
                    classDelegates[i](hireItems[i].Increment);
                    GameState.PlayerGold -= hireItems[i].Cost;
                    hireItems[i].Cost++;
                }
            }
        }
		GUI.EndGroup ();
	}

    void InitializeShopItems() {
        statusDelegates = new List<StatusDelegate>() 
        { 
            (i) => PlayerStatus.Attack += i,
            (i) => PlayerStatus.Defense += i,
            (i) => PlayerStatus.Health += i,
            (i) => PlayerStatus.Critical += i
        };

        classDelegates = new List<ClassDelegate>() 
        { 
            (i) => GameState.HiredWarriors += i,
            (i) => GameState.HiredMages += i,
            (i) => GameState.HiredPriests += i,
            (i) => GameState.HiredPaladins += i
        };

        ShopItem warrior = new ShopItem("Warrior", "Warrior description", 1, 1, warriorTexture);
        ShopItem mage = new ShopItem("Mage", "Mage description", 1, 1, mageTexture);
        ShopItem priest = new ShopItem("Priest", "Priest description", 1, 1, priestTexture);
        ShopItem paladin = new ShopItem("Paladin", "Paladin description", 1, 1, paladinTexture);

        ShopItem attack = new ShopItem("Attack", "attack description", 1, 1, attackTexture);
        ShopItem defense = new ShopItem("Defense", "defense description", 1, 1, defenseTexture);
        ShopItem health = new ShopItem("Health", "health description", 1, 1, healthTexture);
        ShopItem critical = new ShopItem("Critical", "critical description", 1, 1, criticalTexture);

        hireItems = new List<ShopItem>() {warrior, mage, priest, paladin };
        statusItems = new List<ShopItem>() {attack, defense, health, critical};
    }

    void InitializeVector() {
        boxPosition = new Vector2(0, 0);
        itemPosition = new Vector2(0, 0);
        boxSize = new Vector2(Screen.width, Screen.height - (Screen.height * 0.2f + 25));
        buyButtonPosition = new Vector2 (Screen.width - 75, itemPosition.y + 70);
        buyButtonSize = new Vector2 (50, 20);
        groupPosition = new Vector2(0, Screen.height * 0.2f + 25);
        groupSize = new Vector2(Screen.width, Screen.height - (Screen.height * 0.2f + 25) );
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
		if (GUI.Button (new Rect (120, 10, 100, 20), GameState.PlayerGold.ToString ())) {
			isShopDisplayed = !isShopDisplayed;
		}

		if (isShopDisplayed) {
			if (GUI.Button (new Rect (tabButtonPosition.x, tabButtonPosition.y, tabButtonSize.x, tabButtonSize.y), "Shop")) {
				DrawTab = DrawShopTab;
			}
			if (GUI.Button (new Rect (tabButtonPosition.x + tabButtonSize.x, tabButtonPosition.y, tabButtonSize.x, tabButtonSize.y), "Hire")) {
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
