using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
	private Animator anim;
	private Rigidbody2D myRigidBody;
	private bool playerMoving;
	private Vector2 lastmove;
	private static bool PlayerExists;
	public string startPoint;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;
	public VirtualJoystick Joystick;
	public Vector2 moveVector;



	// Use this for initialization
	void Start () {
		attacking = false;

		anim = GetComponent<Animator> ();
		myRigidBody = GetComponent<Rigidbody2D> ();

		if (!PlayerExists) {
			PlayerExists = true; 

			DontDestroyOnLoad (transform.gameObject);
		} else { 
			Destroy (gameObject);
		}
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		moveVector.Normalize ();
		moveVector.x = Joystick.Horizontal ();
		moveVector.y = Joystick.Vertical ();
		//moveVector = PoolInput ();
		if (!attacking) {
		
		


			playerMoving = false;

			if (moveVector.x > 0.1f || moveVector.x < -0.1f) {
				//transform.Translate (new Vector3 (Input.GetAxisRaw ( "Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				myRigidBody.velocity = new Vector2(moveVector.x*moveSpeed, myRigidBody.velocity.y);
				playerMoving = true;
				lastmove = new Vector2 (moveVector.x, 0f);

			}
			if(moveVector.y > 0.1f || moveVector.y < -0.1f){
			//if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, moveVector.y * currentMoveSpeed);
				playerMoving = true;

				lastmove = new Vector2 (0f, moveVector.y);

				
			}
			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				myRigidBody.velocity = new Vector2 (0f, myRigidBody.velocity.y);
			}
			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, 0f);
			}
			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			} else { 
				currentMoveSpeed = moveSpeed;
			}

				

}

		if (attackTimeCounter > 0) {
			attackTimeCounter-=Time.deltaTime;
		}
		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool("Attack", false);
		}


		 
			anim.SetFloat ("MoveX", moveVector.x);
			anim.SetFloat ("MoveY", moveVector.y);
			anim.SetBool ("PlayerMooving", playerMoving);
			anim.SetFloat ("LastMoveX", lastmove.x);
			anim.SetFloat ("LastMoveY", lastmove.y);

		
	}
	public void attack() 
    {
		attackTimeCounter = attackTime;
		attacking = true;
		myRigidBody.velocity = Vector2.zero;
	anim.SetBool ("Attack", true);
	}



	}


