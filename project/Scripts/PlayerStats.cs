using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public int currentLevel;

	public int currentEXP;

	public int[] toLevelUp;

	public int[]  HPlevels;
	public int[] defenceLevels;
	public int[] attackLevels;

	public int currentHP;
	public int currendATK;
	public int currentDEF;



	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentEXP >= toLevelUp[currentLevel]) {
			currentLevel++;




		}
	
	}
	public void AddExperience(int experienceToAdd)
	{
		currentEXP += experienceToAdd; 



	}

}
