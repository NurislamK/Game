using UnityEngine;
using System.Collections;

public class JoystickController : MonoBehaviour {
	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
	private Animator anim;
	private Rigidbody2D myRigidBody;
	private bool playerMoving;
	public Vector2 lastmove;
	public VirtualJoystick Joystick;
	private static bool PlayerExists;
	public string startPoint;

	private bool evading;
	public float evadeTime;
	public float evadeTimeCounter;
	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;
	public Vector2 moveVector;
	public float dashPower;





	void Start () {
		evading = false;
		myRigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
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
		playerMoving = false;


		if (Mathf.Abs (moveVector.normalized.y) > 0.35f && Mathf.Abs (moveVector.normalized.x) < 0.35f)
			moveVector.x = 0f;
		else if (Mathf.Abs (moveVector.normalized.x) > 0.35f && Mathf.Abs (moveVector.normalized.y) < 0.35f)
			moveVector.y = 0f; 
		
		if (moveVector.y > 0.1f) {
			moveVector.y = 0.5f;
			
			
		}
		if (moveVector.y < -0.1f) {
			moveVector.y = -0.5f;
			
		}
		
		if (moveVector.x > 0.1f) {
			moveVector.x = 0.5f;
			
		}
		if (moveVector.x < -0.1f) {
			moveVector.x = -0.5f;
			
		}

		if (!evading) {
			if (!attacking) {





				if (moveVector.x > 0.1f || moveVector.x < -0.1f) {

					myRigidBody.velocity = new Vector2 (moveVector.normalized.x * currentMoveSpeed, myRigidBody.velocity.y);
					lastmove = new Vector2 (moveVector.x, moveVector.y);
					playerMoving = true;
				}
	
				if (moveVector.y > 0.1f || moveVector.y < -0.1f) {
					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, moveVector.normalized.y * currentMoveSpeed);
					lastmove = new Vector2 (moveVector.x, moveVector.y);
					playerMoving = true;
				}




				if (moveVector.x < 0.1f && moveVector.x > -0.1f) {
					myRigidBody.velocity = new Vector2 (0f, myRigidBody.velocity.y);
				}
				if (moveVector.y < 0.1f && moveVector.y > -0.1f) {
					myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, 0f);
				}
				if (Mathf.Abs (moveVector.x) > 0.1f && Mathf.Abs (moveVector.y) > 0.1f) {
					currentMoveSpeed = moveSpeed * diagonalMoveModifier;
				} else { 
					currentMoveSpeed = moveSpeed;
				}



			}
		
			if (attackTimeCounter > 0) {
				attackTimeCounter -= Time.deltaTime;
			}
			if (attackTimeCounter <= 0) {
				attacking = false;
				anim.SetBool ("Attack", false);
			}


		
			anim.SetFloat ("MoveX", moveVector.x);
			anim.SetFloat ("MoveY", moveVector.y);
			anim.SetBool ("PlayerMooving", playerMoving);
			anim.SetFloat ("LastMoveX", lastmove.x);
			anim.SetFloat ("LastMoveY", lastmove.y);
		}
		if (evadeTimeCounter > 0) {
			evadeTimeCounter -= Time.deltaTime;
		}
		if (evadeTimeCounter > 0.2) {
			Vector2 dir = lastmove;

			//myRigidBody.velocity = new Vector2(-dir.x*10f, -dir.y*10f);
			myRigidBody.AddRelativeForce (dir * Time.fixedDeltaTime * dashPower);
		}
		if (evadeTimeCounter <= 0) {
			evading = false;
			
		}
	}
	public void Dash()
	{

		if (!evading) {
			evadeTimeCounter = evadeTime;
			evading = true;
		}

	
	}



	public void attack() 
	{
		attackTimeCounter = attackTime;
		attacking = true;
		myRigidBody.velocity = Vector2.zero;
		anim.SetBool ("Attack", true);
	}

}

