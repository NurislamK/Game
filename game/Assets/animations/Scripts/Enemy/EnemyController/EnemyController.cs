using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
	
	Transform player;

	NavMeshAgent nav;
	public Animator enemyAnim;
	public Rigidbody enemyRB;
	private bool areMoving;
	public float distanceToPlayer;
	public float attackRange;
	private bool canAttack;
	public float detectRange;
	public float knockBackTime;
	public float knockBackCounter;
	public float knockBackForce;



	// Use this for initialization
	void Start () {
		enemyRB = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent>();
		//canAttack = false;

		//nav.updateRotation = true;
		nav.SetDestination (transform.position);
		areMoving = false;
		
	}

	public void KnockBack(Vector3 knockBackDirection) 
	{
		knockBackCounter = knockBackTime;


		nav.velocity = knockBackDirection * knockBackForce;
		//nav.velocity.y = 10f;

	}

	void Update () {
		if (knockBackCounter <= 0) {
			distanceToPlayer = (transform.position - player.position).magnitude;
			//nav.updateRotation = true;
			enemyAnim.SetBool ("Moving", areMoving);
			//enemyAnim.SetBool ("PlayerInRange", canAttack);

			//enemyAnim.SetFloat ("Speed", enemyRB.velocity.magnitude);
			//transform.rotation.y = Quaternion.LookRotation(player.position.y - transform.position.y);
			//nav.SetDestination (player.position);
			/*if (enemyAnim.GetBool("PlayerInRange")==true){
			areMoving = false;
			nav.SetDestination (transform.position);
		}*/
			if (distanceToPlayer < detectRange) {
				areMoving = true;
				nav.SetDestination (player.position);
				if (attackRange > distanceToPlayer) {
					areMoving = false;
				}
			}
			if (nav.velocity.magnitude == 0) {
				areMoving = false;
			}



		} else {
			knockBackCounter -= Time.deltaTime;
			areMoving = false;
		}
	}

	/*void OnTriggerStay(Collider  other){
		
		//distanceToPlayer = Vector3.Distance(transform.position, player.position);
		//if (attackRange < distanceToPlayer) {
		areMoving= true;
			if (other.gameObject.tag == "Player") {
				nav.SetDestination (player.position);
				areMoving= true;
			if (attackRange > distanceToPlayer) {
				areMoving = false;
			}	//canAttack = false;
			//nav.SetDestination (player.position);
			}
		} */ /*else if(attackRange >= distanceToPlayer) {
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(player.position.x - transform.position.x, 0f, player.position.z - transform.position.z));

			areMoving = false;
			transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 2f);
			if (Quaternion.Angle(transform.rotation, lookRotation)< 10f) {

				canAttack = true;
				//areMoving = false;
			}
			nav.SetDestination (transform.position);

			}
			
		}*/

	/*void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			nav.SetDestination (transform.position);
			areMoving = false;



		}
	} */


		
	


	}


