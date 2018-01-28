using UnityEngine;

using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Resetter : MonoBehaviour {

public int kenttaNumero = 1;
public float perusNopeus = 0.025f;
public int maxPossut = 2;
private float perusNopeusSqr;
private int ajastin = 0;
private int alkuPisteet = 0;

public string kentta = "";
public string okentta = "";

public bool viimeinenKentta = false;
private bool lentaako;

public Rigidbody2D lintu;
public Image tahtiKeski;
public Image tahtiVasen;
public Image tahtiOikea;
public Image tappioKuva;
public Text virheTeksti;
public Text loppuTeksti;
public GameObject extLintu1;
public GameObject extLintu2;

private SpringJoint2D spring;
private Rigidbody2D kaytettyLintu;


void Start () {
	
	tahtiKeski.enabled = false;
	tahtiVasen.enabled = false;
	tahtiOikea.enabled = false;
	tappioKuva.enabled = false;
	lentaako = false;
	
	alkuPisteet = Master.score;
	Manager.possut = maxPossut;
	kaytettyLintu = lintu;
	
	perusNopeusSqr = perusNopeus * perusNopeus;
	spring = kaytettyLintu.GetComponent <SpringJoint2D> ();
	
	if(Master.yritykset == 2) {extLintu1.SetActive(false); }
	if(Master.yritykset == 1) {extLintu2.SetActive(false); extLintu1.SetActive(false); }
	
}
	  
void Update () {

	if((spring == null && kaytettyLintu.velocity.sqrMagnitude < perusNopeusSqr) || lentaako == true) 
	{ 
		++ajastin; 
	}

	if(Master.yritykset == 1 || Manager.possut < maxPossut){
		if(ajastin > 150) { Stars(); }
		if(ajastin > 400) { Reset(); }
	}
	else {
		if(ajastin > 150) { Reset(); }
	}	
	
}

void OnTriggerExit2D (Collider2D osuma){
	
	if(osuma.GetComponent<Rigidbody2D>() == kaytettyLintu) { lentaako = true; }
	
	if(osuma.tag == "Pig") { 
		--Manager.possut; 
		Master.pisteet += 50; 
	}
	
}

void Reset() {
	
	if(Manager.possut == maxPossut) { 
		--Master.yritykset;
		if(Master.yritykset == 0){
			SceneManager.LoadScene("GameOver");
		}
		else {
			Master.pisteet = alkuPisteet;
			SceneManager.LoadScene(okentta);
		}
	}
	else {	
		if(kenttaNumero == 3 || kenttaNumero == 6) { 
			MusicPlayer.musiikki = kenttaNumero; 
			MusicPlayer.vaihdaMusiikki = true;  }
		if(!viimeinenKentta) {
			Master.yritykset = 3;
			SceneManager.LoadScene(kentta);   }
		else { 
			SceneManager.LoadScene("Results"); }
	}
	
}

void Stars() {

	if(Manager.possut == maxPossut) { 
		loppuTeksti.text = "You lose !";
		tappioKuva.enabled = true; 
	}
	else if(Manager.possut == 0) { 
		tahtiKeski.enabled = true;
		tahtiVasen.enabled = true;
		tahtiOikea.enabled = true;
		loppuTeksti.text = "Awesome !";
	} 
	else { 	
		tahtiKeski.enabled = true;
		loppuTeksti.text = "Good !";
	}
	
}

}
