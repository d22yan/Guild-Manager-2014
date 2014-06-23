using UnityEngine;
using System.Collections;

public class DisplayDamage : MonoBehaviour {

    private float CreationTime;
    private float TimeToFade;

	// Use this for initialization
	void Start () {
        CreationTime = Time.time;
        TimeToFade = 1;      
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0.001f, 0.001f, 0f));
        Utility.SetAlpha(guiText.material, Mathf.Cos((Time.time - CreationTime) * ((Mathf.PI / 2) / TimeToFade)));
        Destroy(gameObject, TimeToFade);
	}
}
