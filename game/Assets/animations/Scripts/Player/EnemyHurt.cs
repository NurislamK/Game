using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour {
	

	private AudioSource hurt;
	public int damageToGive;
	private GameObject playeer;
	private EnemyController enemy;

	// Use this for initialization
	void Start () {
		playeer = GameObject.FindGameObjectWithTag ("Player");

			}

	void OnTriggerEnter(Collider other){
		Vector3 hitDirection = other.transform.position - transform.position;
		hitDirection = hitDirection.normalized;


		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyController> ().KnockBack (hitDirection);

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
