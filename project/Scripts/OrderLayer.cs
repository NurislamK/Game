using UnityEngine;
using System.Collections;

public class OrderLayer : MonoBehaviour {
	private SpriteRenderer spriteRend;
	private Transform trans;
	private float a;

	// Use this for initialization
	void Start () {
		spriteRend = GetComponent<SpriteRenderer> ();
		trans = GetComponent<Transform> ();
	    
	}
	
	// Update is called once per frame
	void Update () {

		spriteRend.sortingOrder = -Mathf.RoundToInt(trans.position.y*100);


	
	}
}
