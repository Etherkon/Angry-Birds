using UnityEngine;
using System.Collections;


public class IceBreaker : MonoBehaviour {
	

public int osumat = 2;
public float vahinkoNopeus;

private int nykyisetOsumat;
private float vahinkoNopeusSqr;
private SpriteRenderer spriteRenderer;
private BoxCollider2D osuma2D;


void Start () {
	
	nykyisetOsumat = osumat;
	vahinkoNopeusSqr = vahinkoNopeus * vahinkoNopeus;
	
	spriteRenderer = GetComponent <SpriteRenderer>();
	osuma2D = GetComponent<BoxCollider2D> ();
	
}
	
void OnCollisionEnter2D (Collision2D osuma) {
	
	if(osuma.collider.tag != "Damager") { return; }
	if(osuma.relativeVelocity.sqrMagnitude < vahinkoNopeusSqr) { return; }

	nykyisetOsumat --;

	if(nykyisetOsumat <= 0) { 
		Tapa(); 
	}
	
}

void Tapa () {
	
	spriteRenderer.enabled = false;		
	osuma2D.enabled = false;
	
	GetComponent<Rigidbody2D>().isKinematic = true;
	
}

}