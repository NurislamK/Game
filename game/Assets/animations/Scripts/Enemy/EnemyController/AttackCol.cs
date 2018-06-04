using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCol : MonoBehaviour {
	private GameObject plaer;
	public PlayerController thePlaer;
	private AudioSource hurt;
	public int damageToGive;
	// Use this for initialization
	void Start () {
		plaer = GameObject.FindGameObjectWithTag ("Player");
		thePlaer = FindObjectOfType<PlayerController> ();
		hurt = plaer.GetComponent<AudioSource> ();
	}
	void OnTriggerEnter(Collider other){
		Vector3 hitDirection = other.transform.position - transform.position;
		hitDirection = hitDirection.normalized;


		if (other.gameObject.tag == "Player") {
			thePlaer.KnockBack (hitDirection);
			hurt.Play();
			FindObjectOfType<HealthManager> ().HurtPlayer (damageToGive);



		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
