using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {
	public int playerCurrentHP;
	public int playerMaxHP;


	// Use this for initialization
	void Start () {
		playerCurrentHP = playerMaxHP;


	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHP<=0)
		{
			gameObject.SetActive(false);

	
	}
}



	public void HurtPlayer(int damageTogGive)
	{playerCurrentHP -= damageTogGive;
	}
	public void SetMaxHealth()
	{
		playerCurrentHP = playerMaxHP;


	}
}