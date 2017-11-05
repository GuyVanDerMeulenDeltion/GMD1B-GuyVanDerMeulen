using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour {

    [Header("Drill Rotation:")]
    [Range(0, 100)]
    public float drillRotationSpeed;
	
	void Update () {
        DrillRotate(drillRotationSpeed);
	}

    //Makes the drill rotate...
    void DrillRotate(float rotation) {
        transform.Rotate(rotation, 0, 0);
    }
}
