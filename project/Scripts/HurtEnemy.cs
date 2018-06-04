using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {
	public int damageToGive;
	public GameObject damageBurst;
	public Transform burstPoint;
	public GameObject damageNumber;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy")  
	{
			//Destroy(other.gameObject);
			other.gameObject.GetComponent<EnemyHPmanger>().HurtEnemy(damageToGive);
			Instantiate(damageBurst,burstPoint.position, burstPoint.rotation);
			var clone = (GameObject)Instantiate(damageNumber, burstPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
		
		}}
}
