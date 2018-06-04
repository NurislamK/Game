using UnityEngine;
using System.Collections;

public class menuManager : MonoBehaviour {

	// Use this for initialization
	public void GameStart(string name){
		Application.LoadLevel(name);
	}
	public void QuitGame(){
		Application.Quit ();
	}
}
