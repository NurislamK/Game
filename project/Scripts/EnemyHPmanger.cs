using UnityEngine;
using System.Collections;

public class EnemyHPmanger : MonoBehaviour {
	public int CurrentHP;
	public int MaxHP;
	private PlayerStats thePlayerStats;
	public int EXPtoGive;
	// Use this for initialization
	void Start () {
		CurrentHP = MaxHP;
		thePlayerStats = FindObjectOfType<PlayerStats> ();

		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentHP<=0)
		{
			gameObject.SetActive(false);
			thePlayerStats.AddExperience(EXPtoGive);	
			
		}
	}
	public void HurtEnemy(int damageToGive)
	{CurrentHP -= damageToGive;
	}
	public void SetMaxHealth()
	{
		CurrentHP = MaxHP;
		
		
	}
}