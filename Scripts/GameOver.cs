using UnityEngine;

using System.Collections;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour 
{

private RuntimePlatform alusta = Application.platform;

void Start() {
	
	MusicPlayer.pysaytaMusiikki = true;
	Master.resetoi = true;

}

void Update () {

 if(alusta == RuntimePlatform.Android){
		
		if (Input.touchCount > 0) { 
			SceneManager.LoadScene("Start");} 
	 }
	else if(alusta == RuntimePlatform.WindowsEditor){
		if (Input.GetMouseButtonDown (0)) { 
			SceneManager.LoadScene("Start"); }
	} 
}

}