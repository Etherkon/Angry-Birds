using UnityEngine;

using UnityEngine.UI;
using System.Collections;



public class Manager : MonoBehaviour {

public static int possut;
public static int kierros;
public static bool lentaako;

public Text pisteetteksti;

void Start () {
	
	kierros = 1;
	lentaako = false;
	
}	

void Update () {	

	pisteetteksti.text = "SCORE: " + Master.pisteet.ToString ();
	
}

}
