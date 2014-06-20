using UnityEngine;
using System.Collections;
using System.Linq.Expressions;
using System.Collections.Generic;

public class GoldTotal : MonoBehaviour {

	public Texture progressBarEmpty;

	public bool isShopDisplayed;

	public GUIStyle style1;
	public delegate void drawTabDelegate();
	public drawTabDelegate DrawTab;

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

	public Texture shopItemTexture;

	public Texture itemAttackTexture;
	public Texture itemDefenseTexture;
	public Texture itemHealthTexture;
	public Texture itemCriticalTexture;

    public Texture warriorTexture;
    public Texture priestTexture;
    public Texture mageTexture;
    public Texture paladinTexture;

    public int attackCost;
    public int healthCost;
    public int defenseCost;
    public int criticalCost;
    public int numberOfClasses;

    delegate int StatusDelegate(int increment);
    List<StatusDelegate> statusDelegates;
    delegate int ClassDelegate(int increment);
    List<ClassDelegate> classDelegates;

    public System.Collections.Generic.List<ShopItem> hireItems;

    void DrawShopTab() {
		GUI.BeginGroup (new Rect (groupPosition.x, groupPosition.y, groupSize.x, groupSize.y));
		GUI.Box (new Rect (boxPosition.x, boxPosition.y, boxSize.x, boxSize.y), progressBarEmpty);
		GUI.Box (new Rect (itemPosition.x, itemPosition.y, itemSize.x, itemSize.y), shopItemTexture);
        GUI.Label(new Rect(buyButtonPosition.x-20, buyButtonPosition.y, buyButtonSize.x, buyButtonSize.y), attackCost.ToString());    
		if(GameState.PlayerGold>=attackCost) {
            if (GUI.Button (new Rect (buyButtonPosition.x, buyButtonPosition.y, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
			    //attack
                PlayerStatus.Attack+=100;
                GameState.PlayerGold -= attackCost;
                attackCost++;
		    }
        }
		GUI.Box (new Rect (itemPosition.x, itemPosition.y + itemSize.y, itemSize.x, itemSize.y), shopItemTexture);
        GUI.Label(new Rect(buyButtonPosition.x - 20, buyButtonPosition.y + itemSize.y, buyButtonSize.x, buyButtonSize.y), defenseCost.ToString());    
        if (GameState.PlayerGold >= defenseCost)
        {
            if (GUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y, buyButtonSize.x, buyButtonSize.y), shopItemTexture))
            {
                //defense
                PlayerStatus.Defense += 2;
                GameState.PlayerGold -= defenseCost;
                defenseCost++;
            }
        }
		GUI.Box (new Rect (itemPosition.x, itemPosition.y + itemSize.y * 2, itemSize.x, itemSize.y), shopItemTexture);
        GUI.Label(new Rect(buyButtonPosition.x - 20, buyButtonPosition.y + itemSize.y * 2, buyButtonSize.x, buyButtonSize.y), healthCost.ToString());    
        if (GameState.PlayerGold >= healthCost)
        {
            if (GUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * 2, buyButtonSize.x, buyButtonSize.y), shopItemTexture))
            {
                //health
                PlayerStatus.Health += 100;
                GameState.PlayerGold -= healthCost;
                healthCost++;

            }
        }
		GUI.Box (new Rect (itemPosition.x, itemPosition.y  + itemSize.y * 3, itemSize.x, itemSize.y), shopItemTexture);
        GUI.Label(new Rect(buyButtonPosition.x - 20, buyButtonPosition.y + itemSize.y * 3, buyButtonSize.x, buyButtonSize.y), criticalCost.ToString());    
        if (GameState.PlayerGold >= criticalCost)
        {
            if (GUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * 3, buyButtonSize.x, buyButtonSize.y), shopItemTexture))
            {
                PlayerStatus.Critical += 4;
                GameState.PlayerGold -= criticalCost;
                criticalCost++;
            }
        }
		GUI.Box (new Rect(iconPosition.x, iconPosition.y, iconSize.x, iconSize.y), itemAttackTexture);
		GUI.Box (new Rect(iconPosition.x, iconPosition.y + itemSize.y, iconSize.x, iconSize.y), itemDefenseTexture);
		GUI.Box (new Rect(iconPosition.x, iconPosition.y + itemSize.y * 2, iconSize.x, iconSize.y), itemHealthTexture);
		GUI.Box (new Rect(iconPosition.x, iconPosition.y + itemSize.y * 3, iconSize.x, iconSize.y), itemCriticalTexture);
		GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y, itemDescriptionSize.x, itemDescriptionSize.y), "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111");
		GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + itemSize.y, itemDescriptionSize.x, itemDescriptionSize.y), "22222");
		GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + itemSize.y * 2, itemDescriptionSize.x, itemDescriptionSize.y), "333");
		GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + itemSize.y * 3, itemDescriptionSize.x, itemDescriptionSize.y), "444");
		GUI.EndGroup ();
	}

	void DrawHireTab() {
		GUI.BeginGroup (new Rect (groupPosition.x, groupPosition.y, groupSize.x, groupSize.y));
		GUI.Box (new Rect (boxPosition.x, boxPosition.y, boxSize.x, boxSize.y), progressBarEmpty);

        for (int i = 0; i < numberOfClasses; i++ )
        {
            GUI.Box(new Rect(itemPosition.x, itemPosition.y + itemSize.y * i, itemSize.x, itemSize.y), shopItemTexture);
            GUI.Label(new Rect(buyButtonPosition.x - 20, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), hireItems[i].Cost.ToString());
            if (GameState.PlayerGold >= hireItems[i].Cost)
            {
                if (GUI.Button(new Rect(buyButtonPosition.x, buyButtonPosition.y + itemSize.y * i, buyButtonSize.x, buyButtonSize.y), shopItemTexture))
                {
                    classDelegates[i](hireItems[i].Increment);
                    GameState.PlayerGold -= hireItems[i].Cost;
                    hireItems[i].Cost++;
                }
            }
            GUI.Box(new Rect(iconPosition.x, iconPosition.y + itemSize.y * i, iconSize.x, iconSize.y), hireItems[i].Texture);
            GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + itemSize.y * i, itemDescriptionSize.x, itemDescriptionSize.y), hireItems[i].Description);
        }
		GUI.EndGroup ();
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

    void Awake()
    {
        DrawTab = DrawShopTab;
    }

	// Use this for initialization
	void Start () {
		isShopDisplayed = false;
		

        attackCost      = 1;
        healthCost      = 1;
        defenseCost     = 1;
        criticalCost    = 1;
        numberOfClasses = 4;

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

        ShopItem warrior = new ShopItem("12312312", 1, "Warrior", warriorTexture);
        ShopItem mage = new ShopItem("12312312", 1, "Mage", mageTexture);
        ShopItem priest = new ShopItem("12312312", 1, "Priest", priestTexture);
        ShopItem paladin = new ShopItem("12312312", 1, "Paladin", paladinTexture);

        hireItems = new List<ShopItem>() {warrior, mage, priest, paladin };

		groupPosition = new Vector2(0, Screen.height * 0.2f + 25);
		groupSize = new Vector2(Screen.width, Screen.height - (Screen.height * 0.2f + 25) );
		boxPosition = new Vector2(0, 0);
		boxSize = new Vector2(Screen.width, Screen.height - (Screen.height * 0.2f + 25));
		tabButtonPosition = new Vector2(0, Screen.height * 0.2f);
		tabButtonSize = new Vector2(Screen.width * 0.5f, 20);

		itemPosition = new Vector2 (0, 0);
		itemSize = new Vector2 (Screen.width, 100);

		buyButtonSize = new Vector2 (50, 20);
		buyButtonPosition = new Vector2 (Screen.width - 75, itemPosition.y + 70);

		iconPosition = new Vector2 (10, 10);
		iconSize = new Vector2 (itemSize.y - 20, itemSize.y - 20);

		itemDescriptionPosition = new Vector2 (iconSize.x + 20, 10);
		itemDescriptionSize = new Vector2 (itemSize.x - (iconSize.x + 20 + buyButtonSize.x + 20) , itemSize.y - 20);

		itemPricePosition = new Vector2 (buyButtonPosition.x, buyButtonPosition.y - 40);
		itemPriceSize = new Vector2 (buyButtonSize.x, buyButtonSize.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
