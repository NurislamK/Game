using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
	public Slider healthBar;
	public Text HPtext;
	public PlayerHealthManager playerHealth;
	private static bool UIexists;
	private PlayerStats playerStats;
	public Text levelText;
	// Use this for initialization
	void Start () {	if (!UIexists) {
			UIexists = true; 
			
			DontDestroyOnLoad (transform.gameObject);
		} else { 
			Destroy (gameObject);
		}
		playerStats = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHP;
		healthBar.value = playerHealth.playerCurrentHP;
		HPtext.text = "HP: " + playerHealth.playerCurrentHP + "/" + playerHealth.playerMaxHP;
		levelText.text = "Lvl: " + playerStats.currentLevel;

	}
}
