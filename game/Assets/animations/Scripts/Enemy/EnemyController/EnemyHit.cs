using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHit : MonoBehaviour {
	Transform player;
	NavMeshAgent nav;
	public Animator enemyAnim;

	public float distanceToPlayer;
	public float attackRange;

	private bool canAttack;
	public GameObject col;

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		//nav.stoppingDistance = attackRange;

		nav.updateRotation = true;


		
	}



	public void Ataka () {
		col.SetActive(true);


	
	}
	public void ColDown(){
		col.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		enemyAnim.SetBool ("PlayerInRange", canAttack);
		distanceToPlayer = (transform.position - player.position).magnitude;
		if (!GetComponent<EnemyController> ().enabled) {
			nav.SetDestination (transform.position);

			//print("script was removed");

		}

		//transform.rotation.y = Quaternion.LookRotation(player.position.y - transform.position.y);

		if (attackRange < distanceToPlayer) {
		
			canAttack = false;

		}
		if (GetComponent<EnemyController> ().knockBackCounter <= 0) {
			if (attackRange >= distanceToPlayer) {
				Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (player.position.x - transform.position.x, 0f, player.position.z - transform.position.z));



				transform.rotation = Quaternion.Lerp (transform.rotation, lookRotation, Time.deltaTime * 2f);
				if (Quaternion.Angle (transform.rotation, lookRotation) < 10f) {

					canAttack = true;


					//areMoving = false;
				}
				nav.SetDestination (transform.position);

			}

		}

	}

	}

