using UnityEngine;
using System.Collections;


public class MusicPlayer : MonoBehaviour {


public static bool vaihdateema = false;
public static bool pysaytateema = false;
public static int musiikki;

public AudioSource alkuteema;
public AudioSource talviteema;
public AudioSource lopputeema;
public AudioSource viimeinenteema;


void Start() {
	
	musiikki = 0;
	
}

void Awake() {
	
	DontDestroyOnLoad(this);
	
}

void Update() {
	
	if(vaihdateema) {  
		pysaytaMusiikki(); 
		vaihdaMusiikki(); 
	}
	if(stopMusic) { 
		pysaytaMusiikki(); 
		resetoiMusiikki(); 
	}
	
}

void Music() {
	
	if(musiikki == 1) { alkuteema.Play(); }
	else if(musiikki == 3) { talviteema.Play(); }
	else if(musiikki == 6) { viimeinenteema.Play(); }
	else if(musiikki == 99) { lopputeema.Play(); }
	
	vaihdateema = false;	
	
}

void pysaytaMusiikki(){
	
	alkuteema.Stop();
	talviteema.Stop();
	viimeinenteema.Stop();
	lopputeema.Stop();
	
}

void resetoiMusiikki() {
	
	musiikki = 0;
	vaihdaMusiikki = false;	
	pysaytaMusiikki = false;
	
}

}