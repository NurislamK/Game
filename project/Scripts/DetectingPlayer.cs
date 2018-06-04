using UnityEngine;
using System.Collections;

public class DetectingPlayer : MonoBehaviour {
	private GameObject player;



	public float viewRange;
	public bool attacking;


	public float attackRange;
	private Animator anim;
	private float dist;
	public int damageTogGive;






	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		attacking = false;
	




	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		dist = Vector3.Distance (player.transform.position, transform.position);
		if (dist < viewRange) {

		GetComponent<WolfControllr>().moveDirection = player.transform.position - transform.position;


		}
		if (dist < attackRange && !attacking) {
			InvokeRepeating ("AttackingAnimation", 0f, 3f);
			attacking = true;

			GetComponent<WolfControllr> ().myRigidBody.velocity = Vector3.zero;
		} else if(dist>attackRange && attacking) {
			attacking=false;
			CancelInvoke();
		
		}

			
			
			





	}
	void AttackingAnimation(){



		anim.SetTrigger ("Attack");
		if (dist <= attackRange) {
			player.GetComponent<PlayerHealthManager>().HurtPlayer(damageTogGive);


		}


		}




	
	
	
	
	
	
	
	}









		






	

