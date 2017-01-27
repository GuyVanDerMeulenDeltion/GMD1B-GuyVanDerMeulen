using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotation : MonoBehaviour {

    public Vector3 gemrotation;
    public float gemrotationspeed;
	

	void Update ()
    {
        //Makes the gem in the staff rotate.
        gemrotation.y = gemrotationspeed;
        transform.Rotate(gemrotation);
    }
}
