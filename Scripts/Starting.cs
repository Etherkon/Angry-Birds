using UnityEngine;

using UnityEngine.UI;

using System.Collections;
using UnityEngine.SceneManagement; 


public class Starting : MonoBehaviour {

public string kentta;
private bool voikoKlikata;

public Text virheteksti;

private RuntimePlatform alusta = Application.platform;

public AudioSource alkuteema;


void Start() {
	alkuteema.Play();
	voikoKlikata = false;
}

void Update () {
	
	// Tarkistus millä alustalla pyöritetään
	
	 if(alusta == RuntimePlatform.Android){
		if(Input.touchCount == 0)
		{
			voikoKlikata = true;
		}		
		if (Input.touchCount > 0 && voikoKlikata == true) { 
			alkuteema.Stop();
			MusicPlayer.vaihdaMusiikki = true;
			MusicPlayer.musiikki = 1;
			SceneManager.LoadScene(kentta);} 
	 }
	else if(alusta == RuntimePlatform.WindowsEditor){
		if (Input.GetMouseButtonDown (0)) { 
			alkuteema.Stop();
			MusicPlayer.vaihdaMusiikki = true;
			MusicPlayer.musiikki = 1;
			SceneManager.LoadScene(kentta); }
	} 
}




}
