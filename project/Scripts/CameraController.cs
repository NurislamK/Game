using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;
	private static bool CameraExists;

	// Use this for initialization
	void Start () {
		
		if (!CameraExists) {
			CameraExists = true;
			DontDestroyOnLoad (transform.gameObject);	
		} else {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
