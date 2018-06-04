using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
	public int maxHealth;
	public int curHealth;
	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HurtPlayer(int damage)
	{
		curHealth -= damage;	
	}

	public void HealPlayer(int healAmount)
	{
		curHealth += healAmount;
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
	}
}
