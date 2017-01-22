using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotation : MonoBehaviour {

    public Vector3 gemrotation;
    public float gemrotationspeed;
	
	// Update is called once per frame
	void Update () {

        gemrotation.y = gemrotationspeed;
        transform.Rotate(gemrotation);
    }
}
