using UnityEngine;

using UnityEngine.UI;
using System.Collections;



public class BirdTracker : MonoBehaviour {


public float lankaPituus = 3.0f;
public int pisteet;
public string lintuTyyppi = "";
private float lankaPituusSqr;
private float ympyraRadius;
private bool onkoKlikattu;
private bool lentaako;

public Text virheteksti;

public AudioSource lentoaani;
public AudioSource osumaaani;

public LineRenderer lankaEtu;
public LineRenderer lankaTaka;
private SpringJoint2D spring;
private Transform katapultti;
private Ray rayToMouse;
private Ray vasenKatapulttiLintu;

private Vector2 prevVelocity;
private Rigidbody2D rigidBody;
private CircleCollider2D ympyra;

private Vector3 touchPosWorld;

private RuntimePlatform alusta = Application.platform;


void Awake () {
	
	spring = GetComponent <SpringJoint2D> ();
	rigidBody = GetComponent<Rigidbody2D> ();
	ympyra = GetComponent<CircleCollider2D> ();
	
	katapultti = spring.connectedBody.transform;
	
}

void Start () {
	
	lentaako = false;
	
	lankaPituusSqr = lankaPituus * lankaPituus;
	ympyraRadius = ympyra.radius;
	
	rayToMouse = new Ray(katapultti.position, Vector3.zero);
	vasenKatapulttiLintu = new Ray(vasenKatapulttiLintu.transform.position, Vector3.zero);
	
	LankaAsetus();
}
	

void Update () {
	
	 if(alusta == RuntimePlatform.Android && Master.starts == false){

		if (Input.touchCount > 0) { OnTouchDown ();} 
		if (Input.touchCount == 0 && onkoKlikattu == true) { OnTouchUp (); }
		if(onkoKlikattu) { DraggingAndroid(); }
	}
	else if(alusta == RuntimePlatform.WindowsEditor && Master.aloittaa == false){
		if (Input.GetMouseButtonDown (0)) { OnTouchDown (); } 
		if (Input.GetMouseButtonUp (0)) { OnTouchUp (); }
		if(clickedOn) { DraggingPC(); }
	}

	if(spring != null) { 
		if(!rigidBody.isKinematic && prevVelocity.sqrMagnitude > rigidBody.velocity.sqrMagnitude) {
			Destroy(spring);
			lentoaani.Play();
			Manager.lentaako = true;
			rigidBody.velocity = prevVelocity;
		}    
		if(!onkoKlikattu) {
			prevVelocity = rigidBody.velocity;
		}
		LankaPaivitys();
	} else {   
		ympyra.radius = 1.15f;
		lentaako = true;
 		lankaEtu.enabled = false;
		lankaTaka.enabled = false;
	}
	
}

void LankaAsetus() {
	
	    lankaEtu.SetPosition(0, lankaEtu.transform.position);
		lankaEtu.sortingLayerName = "foreground";
		lankaEtu.sortingOrder = 3;
		
        lankaTaka.SetPosition(0, lankaTaka.transform.position);
        lankaTaka.sortingLayerName = "foreground";
        lankaTaka.sortingOrder = 1;
		
}

void LankaPaivitys(){
	
	Vector2 katapulttiLinttu = transform.position - catapultLineFront.transform.position;
	vasenKatapulttiLintu.direction = katapulttiLinttu;
	Vector3 holdPoint = vasenKatapulttiLintu.GetPoint(katapulttiLinttu.magnitude + ympyraRadius);
	lankaEtu.SetPosition(1, holdPoint); 
	lankaTaka.SetPosition(1, holdPoint);

}

void OnTouchDown() {
	
	spring.enabled = false;
	onkoKlikattu = true;
	
}

void OnTouchUp() {
	
	virheteksti.text = "";
	spring.enabled = true;
	rigidBody.isKinematic = false;
	onkoKlikattu = false;
	
}

void DraggingAndroid() {
	
	Vector3 SormiSijainti = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
	Vector2 katapulttiHiiri = SormiSijainti - katapultti.position;

	if(katapulttiHiiri.sqrMagnitude > maxStretchSqr) {
		rayToMouse.direction = katapulttiHiiri;
		SormiSijainti = rayToMouse.GetPoint(maxStretch);
	}

	SormiSijainti.z = 0f;
	transform.position = SormiSijainti;
}

void DraggingPC() {
	
	Vector3 HiiriSijainti = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	Vector2 katapulttiHiiri = HiiriSijainti - katapultti.position;

	if(katapulttiHiiri.sqrMagnitude > lankaPituusSqr) {
		rayToMouse.direction = katapulttiHiiri;
		HiiriSijainti = rayToMouse.GetPoint(maxStretch);
	}

	HiiriSijainti.z = 0f;
	transform.position = HiiriSijainti;
}


void OnCollisionEnter2D (Collision2D osuma) {
	
	if(lentaako) { 
		osumaaani.Play(); 
		Master.pisteet += pisteet;
	}
	
}

}
