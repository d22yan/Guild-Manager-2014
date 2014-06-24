using UnityEngine;
using System.Collections;

public class BackgroundRescale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var sr = gameObject.GetComponent<SpriteRenderer> ();
		if (sr == null) return;
		transform.localScale.Set (1, 1, 1);
		var width = sr.sprite.bounds.size.x;
		var height = sr.sprite.bounds.size.y;
		
		var worldScreenHeight = Camera.main.orthographicSize * 2.0;
		var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		transform.localScale.Set((float)worldScreenWidth / width, (float)worldScreenHeight / height, 0.0f );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
