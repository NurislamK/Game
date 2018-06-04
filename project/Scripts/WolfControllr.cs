using UnityEngine;
using System.Collections;

public class WolfControllr : MonoBehaviour {
	public float moveSpeed;
	public Rigidbody2D myRigidBody;
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove; 
	private float timeToMoveCounter;
	public Vector3 moveDirection;
	private Animator anim;
	private Vector2 lastMove;
	private GameObject player;
    public bool tracking;
	private float dist;
	public float viewRange;








	 

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");


		moveDirection.Normalize ();


		myRigidBody = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();

		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
	
	}

	

	void FixedUpdate ()
	{
		tracking = false;
		dist = Vector3.Distance (player.transform.position, transform.position);
		if (dist < viewRange) {

			tracking=true;
		}

		if (!tracking) {

		
			if (moving) {

		
				timeToMoveCounter -= Time.deltaTime;
				myRigidBody.velocity = moveDirection.normalized;
		
				if (timeToMoveCounter < 0f) {
					moving = false;
					//timeBetweenMoveCounter = timeBetweenMove;}
					timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
				}
		
			} else {
		
				timeBetweenMoveCounter -= Time.deltaTime;
				myRigidBody.velocity = Vector3.zero;
				if (timeBetweenMoveCounter < 0f) {
					moving = true;
					//timeToMoveCounter = timeToMove;
					timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
			
					moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
				}
			}
		} else if(tracking){
			moveDirection = player.transform.position - transform.position;
			myRigidBody.velocity = moveDirection;
			moving = true;
		}
		
		anim.SetFloat ("MoveX",moveDirection.x);
		anim.SetFloat ("MoveY",moveDirection.y);
		anim.SetBool ("Moving", moving);
		anim.SetFloat ("lastMoveX", moveDirection.x);
		anim.SetFloat ("lastMoveY", moveDirection.y);}




	}






















