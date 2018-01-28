using UnityEngine;

using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class EndScore : MonoBehaviour {

public Text pisteetteksti;

private RuntimePlatform alusta = Application.platform;


void Start() {
	
	MusicPlayer.musiikki = 10;
	MusicPlayer.vaihdaMusiikki = true;
	
	pisteetteksti.text = Master.score.ToString();
}

void Update () {
	
	 if(alusta == RuntimePlatform.Android){	
		if (Input.touchCount > 0) { Reset(); SceneManager.LoadScene("Start");} 
	 }
	else if(alusta == RuntimePlatform.WindowsEditor){
		if (Input.GetMouseButtonDown (0)) { Reset(); SceneManager.LoadScene("Start"); }

	} 
	
}

void Reset(){
	
	MusicPlayer.pysaytaMusiikki = true;
	Master.resetoi = true;
	
}

}