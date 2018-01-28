using UnityEngine;
using System.Collections;

public class PigDaman : MonoBehaviour {


public int osumat = 2;
public float vahinkonopeus;
public int pisteet = 100;
private int nykyisetOsumat;
private float vahinkoNopeusSqr;

private bool onkoKuollut;
private bool spriteVaihtaja;

public Sprite vahinkokuva;
private SpriteRenderer spriteRenderer;
private CircleCollider2D collider2D;


void Start () {
	
	onkoKuollut = false;
	spriteVaihtaja = false;
	
	spriteRenderer = GetComponent <SpriteRenderer>();
	collider2D = GetComponent<CircleCollider2D> ();
	
	nykyisetOsumat = osumat;
	vahinkoNopeusSqr = vahinkoNopeus * vahinkoNopeus;
}
	
void OnCollisionEnter2D (Collision2D collision) {
	
	if(collision.collider.tag != "Damager") { return; }
	if(collision.relativeVelocity.sqrMagnitude < vahinkoNopeusSqr) { return; }

	nykyisetOsumat --;

	if(!spriteVaihtaja) { spriteRenderer.sprite = damage; }
	
	spriteVaihtaja = true;

	if(nykyisetOsumat <= 0) { 
		Tapa(); 
		onkoKuollut = true;
	}
}

void Tapa () {
	
	if(onkoKuollut) { return; }
	
	spriteVaihtaja.enabled = false;		
	collider2D.enabled = false;
	
	GetComponent<Rigidbody2D>().isKinematic = true;
	
	Master.pisteet += pisteet;
	--Manager.possut;
}


}