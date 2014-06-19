using UnityEngine;
using System.Collections;

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
	public Vector2 buttonPosition;
	public Vector2 buttonSize;
	public Vector2 shopItemPosition;
	public Vector2 shopItemSize;
	public Vector2 buyButtonSize;
	public Vector2 buyButtonPosition;
	public Vector2 itemIconPosition;
	public Vector2 itemIconSize;

	public Vector2 itemDescriptionPosition;
	public Vector2 itemDescriptionSize;

	public Vector2 itemPricePosition;
	public Vector2 itemPriceSize;

	public Texture shopItemTexture;

	public Texture itemAttackTexture;
	public Texture itemDefenseTexture;
	public Texture itemHealthTexture;
	public Texture itemCriticalTexture;

    void DrawShopTab() {
		GUI.BeginGroup (new Rect (groupPosition.x, groupPosition.y, groupSize.x, groupSize.y));
		GUI.Box (new Rect (boxPosition.x, boxPosition.y, boxSize.x, boxSize.y), progressBarEmpty);
		GUI.Box (new Rect (shopItemPosition.x, shopItemPosition.y, shopItemSize.x, shopItemSize.y), shopItemTexture);
		if (GUI.Button (new Rect (buyButtonPosition.x, buyButtonPosition.y, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
			Debug.Log ("Clicked 1");
		}
		GUI.Box (new Rect (shopItemPosition.x, shopItemPosition.y + shopItemSize.y, shopItemSize.x, shopItemSize.y), shopItemTexture);
		if (GUI.Button (new Rect (buyButtonPosition.x, buyButtonPosition.y + shopItemSize.y, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
			Debug.Log ("Clicked 2");
		}
		GUI.Box (new Rect (shopItemPosition.x, shopItemPosition.y + shopItemSize.y * 2, shopItemSize.x, shopItemSize.y), shopItemTexture);
		if (GUI.Button (new Rect (buyButtonPosition.x, buyButtonPosition.y + shopItemSize.y * 2, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
			Debug.Log ("Clicked 3");
		}
		GUI.Box (new Rect (shopItemPosition.x, shopItemPosition.y  + shopItemSize.y * 3, shopItemSize.x, shopItemSize.y), shopItemTexture);
		if (GUI.Button (new Rect (buyButtonPosition.x, buyButtonPosition.y  + shopItemSize.y * 3, buyButtonSize.x, buyButtonSize.y), shopItemTexture)) {
			Debug.Log ("Clicked 4");
		}
		GUI.Box (new Rect(itemIconPosition.x, itemIconPosition.y, itemIconSize.x, itemIconSize.y), itemAttackTexture);
		GUI.Box (new Rect(itemIconPosition.x, itemIconPosition.y + shopItemSize.y, itemIconSize.x, itemIconSize.y), itemDefenseTexture);
		GUI.Box (new Rect(itemIconPosition.x, itemIconPosition.y + shopItemSize.y * 2, itemIconSize.x, itemIconSize.y), itemHealthTexture);
		GUI.Box (new Rect(itemIconPosition.x, itemIconPosition.y + shopItemSize.y * 3, itemIconSize.x, itemIconSize.y), itemCriticalTexture);
		GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y, itemDescriptionSize.x, itemDescriptionSize.y), "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111");
		GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + shopItemSize.y, itemDescriptionSize.x, itemDescriptionSize.y), "22222");
		GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + shopItemSize.y * 2, itemDescriptionSize.x, itemDescriptionSize.y), "333");
		GUI.Label(new Rect(itemDescriptionPosition.x, itemDescriptionPosition.y + shopItemSize.y * 3, itemDescriptionSize.x, itemDescriptionSize.y), "444");
		GUI.EndGroup ();
	}

	void DrawHireTab() {
		GUI.BeginGroup (new Rect (groupPosition.x, groupPosition.y, groupSize.x, groupSize.y));
		GUI.Box (new Rect (boxPosition.x, boxPosition.y, boxSize.x, boxSize.y), progressBarEmpty);
		GUI.EndGroup ();
	}

	void OnGUI() {
		if (GUI.Button (new Rect (120, 10, 100, 20), GameState.PlayerGold.ToString ())) {
			isShopDisplayed = !isShopDisplayed;

		}

		if (isShopDisplayed) {
			if (GUI.Button (new Rect (buttonPosition.x, buttonPosition.y, buttonSize.x, buttonSize.y), "Shop")) {
				DrawTab = DrawShopTab;
			}
			if (GUI.Button (new Rect (buttonPosition.x + buttonSize.x, buttonPosition.y, buttonSize.x, buttonSize.y), "Hire")) {
				DrawTab = DrawHireTab;
			}
			DrawTab();
		}
	}

	// Use this for initialization
	void Start () {
		isShopDisplayed = false;
		DrawTab = DrawShopTab;

		groupPosition = new Vector2(0, Screen.height * 0.2f + 25);
		groupSize = new Vector2(Screen.width, Screen.height - (Screen.height * 0.2f + 25) );
		boxPosition = new Vector2(0, 0);
		boxSize = new Vector2(Screen.width, Screen.height - (Screen.height * 0.2f + 25));
		buttonPosition = new Vector2(0, Screen.height * 0.2f);
		buttonSize = new Vector2(Screen.width * 0.5f, 20);

		shopItemPosition = new Vector2 (0, 0);
		shopItemSize = new Vector2 (Screen.width, 100);

		buyButtonSize = new Vector2 (50, 20);
		buyButtonPosition = new Vector2 (Screen.width - 75, shopItemPosition.y + 70);

		itemIconPosition = new Vector2 (10, 10);
		itemIconSize = new Vector2 (shopItemSize.y - 20, shopItemSize.y - 20);

		itemDescriptionPosition = new Vector2 (itemIconSize.x + 20, 10);
		itemDescriptionSize = new Vector2 (shopItemSize.x - (itemIconSize.x + 20 + buyButtonSize.x + 20) , shopItemSize.y - 20);

		itemPricePosition = new Vector2 (buyButtonPosition.x, buyButtonPosition.y - 40);
		itemPriceSize = new Vector2 (buyButtonSize.x, buyButtonSize.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
