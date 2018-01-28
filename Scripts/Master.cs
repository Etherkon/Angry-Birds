using UnityEngine;

using System.Collections;


public class Master : MonoBehaviour {

	
public static int pisteet;
public static int yritykset;
public static bool aloittaa = true;
public static bool resetoi = false;

void Start() {
	
	pisteet = 0;
	yritykset = 3;
	
	DontDestroyOnLoad(this);
	
}

void Awake() {
}


void Update() {
	if(resetoi) { Reset(); }

}

void Reset() {
	
	pisteet = 0;
	yritykset = 3;
	resetoi = false;
	
}

}
