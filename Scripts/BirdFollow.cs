using UnityEngine;

using UnityEngine.UI;
using System.Collections;


public class BirdFollow : MonoBehaviour {

public int kenttaNumero = 1;
public float nopeus = 3.0f;
private int ajastin;

public Transform lintu;
public Transform vasenRaja;
public Transform oikeaRaja;

public Text kenttateksti;
public Text virheteksti;

private Transform vuorossaLintu;

void Start () {
	
	ajastin = 0;
	vuorossaLintu = bird;
	Master.aloittaa = true;
	
	kenttateksti.text = "Level " + kenttaNumero.ToString();
	
}

void Update () {
	
	if(Master.aloittaa && Master.yrityksia == 3){
		++ajastin;
		if(ajastin > 240) { 
			Master.aloittaa = false;  
			kenttateksti.enabled = false;
		}
	}
	else {
		Master.aloittaa = false;
		Vector3 uusiSijainti = transform.position;
		uusiSijainti.x = vuorossaLintu.position.x;
		uusiSijainti.x = Mathf.Clamp(uusiSijainti.x, vasenRaja.position.x, oikeaRaja.position.x);
		transform.position = uusiSijainti; 
	}
}

}
