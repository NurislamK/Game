using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public CharacterController controller;
	public Vector3 moveDirection;
	public float gravityScale;
	public Animator anim;

	public float rotateSpeed;
	public GameObject playerModel;
	Quaternion rotation;
	public float knockBackForce;
	public float knockBackTime;
	public float knockBackCounter;
	private bool isMoving;
	private AudioSource hurt;
	public bool attacking;
	public GameObject weapon;


	void Start () {
		controller = GetComponent<CharacterController> ();
		isMoving = false;
		//anim = GetComponent<Animator> ();
		attacking = false;
	}


	void Attack()
	{
		attacking = true;
		isMoving = false;


	}
	void ColCall(){
		weapon.SetActive (true);
	}
	void ColDestroy(){
		weapon.SetActive (false);
	}



	void Update () { 
		if (!attacking) {
			if (knockBackCounter <= 0) {
				
			
				//moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis ("Vertical") * moveSpeed);
		
				if (controller.isGrounded) {
				

					moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis ("Vertical") * moveSpeed);
					if (Input.GetKeyDown (KeyCode.P)) {

						Attack ();		
					}

					//moveDirection = new Vector3 (Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
		
					moveDirection.y = 0f;
					if (Input.GetButtonDown ("Jump")) {
						//moveDirection = new Vector3 (moveDirection.x * 2f, jumpForce, moveDirection.z * 2f);
						moveDirection.y = jumpForce;
					}

		
				}

			} else {
				knockBackCounter -= Time.deltaTime;
				isMoving = false;

		
		
			} 


			
			if (knockBackCounter <= 0) {
				if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
					rotation = Quaternion.LookRotation (new Vector3 (moveDirection.x, 0f, moveDirection.z));


					playerModel.transform.rotation = Quaternion.Slerp (playerModel.transform.rotation, rotation, rotateSpeed * Time.deltaTime);
		
				}
			}

		} else {
			moveDirection = new Vector3 (0, 0, 0);
		}
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);  	 
		controller.Move (moveDirection * Time.deltaTime);

				

		anim.SetBool ("Attacking", attacking);
		anim.SetBool("IsGrounded",controller.isGrounded);
		//anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical"))) + Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetBool("isMoving", isMoving);
		if ((Mathf.Abs (Input.GetAxis ("Vertical"))) + Mathf.Abs (Input.GetAxis ("Horizontal")) < 0.1) {
			isMoving = false;
		
		} else {
			isMoving = true;}
	}

	public void KnockBack(Vector3 knockBackDirection) 
	{
		knockBackCounter = knockBackTime;


		moveDirection = knockBackDirection * knockBackForce;
		moveDirection.y = 10;
	
	}
}
