using UnityEngine;
using System.Collections;

public class WolfController : MonoBehaviour {
	public float moveSpeed;
	public Rigidbody2D myRigidBody;
	public bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove; 
	private float timeToMoveCounter;
	public Vector3 moveDirection;
	private Animator anim;
	private Vector2 lastMove;
	private GameObject player;








	 

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");






		myRigidBody = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();


		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
	
	}

	

	void Update ()
	
{




		if (GetComponent<DetectingPlayer> ().attacking == false) {

			if (moving) {

		
				timeToMoveCounter -= Time.deltaTime;


				myRigidBody.velocity = moveDirection;
				if (timeToMoveCounter < 0f) {
					moving = false;
					timeBetweenMoveCounter = timeBetweenMove;}
					timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

		
			} else {
		
				timeBetweenMoveCounter -= Time.deltaTime;
				myRigidBody.velocity = Vector2.zero;
				if (timeBetweenMoveCounter < 0f) {
					moving = true;
					timeToMoveCounter = timeToMove;
					moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);

				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
			

				}

			}



			anim.SetFloat ("MoveX", moveDirection.x);
			anim.SetFloat ("MoveY", moveDirection.y);
			anim.SetBool ("Moving", moving);
			anim.SetFloat ("lastMoveX", moveDirection.x);
			anim.SetFloat ("lastMoveY", moveDirection.y);
		}

	

		}


	}



	






















