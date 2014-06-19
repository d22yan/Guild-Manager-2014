using UnityEngine;
using System.Collections;

public class GoldTotal : MonoBehaviour {

	public GUIStyle style1;

	void OnGUI() {
		GUI.Button(new Rect(120, 10, 100, 20), GameState.PlayerGold.ToString());
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
