using UnityEngine;
using System.Collections;

public class Rotatortest : MonoBehaviour {


    // NOTE: We hebben nog geen uitleg over dit gekregen door tijdnood, maar ik zal mijn best doen om uit te leggen wat dit is.
    // NOTE2: Deze comments gelden ook voor Rotatortest2, Rotatortest3, en 4.

    // De uiteindelijke kracht waarmee de flipper een object met rigidbody weg kan slaan.
    public float flipperStrength;

    // De uiteindelijke formule dat samenhangt zodat de flipper heen en weer kan bewegen.
    public float pushForce;

    // Reference naar een component die op het object zit waar deze script ook op staat
    private HingeJoint hinge;

    // Hiermee word bij het start van het spel hinge pernament een shortcut naar hingejoint
    void Start () {
        hinge = GetComponent<HingeJoint>();

	}
	
	// Hiermee wanneer de input *vertical* word ingedrukt worden alle calculaties gedaan voor de bewegingen en kracht van de flipper
	void FixedUpdate () {
	if (Input.GetButtonDown("Vertical")) {
            Vector3 f = transform.up * flipperStrength;
            Vector3 p = (transform.right) + transform.position * pushForce;
            GetComponent<Rigidbody>().AddForceAtPosition(f, p);

        }
	}
}
