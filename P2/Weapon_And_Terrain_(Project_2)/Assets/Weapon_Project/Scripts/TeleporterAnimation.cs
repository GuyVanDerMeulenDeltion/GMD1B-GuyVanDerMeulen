using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterAnimation : MonoBehaviour {

    public Vector3 particleRotation;

    public float rotationSpeed;
    public float rotationSpeedAssist;
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(particleRotation);
        rotationSpeed = Time.deltaTime * rotationSpeedAssist;

        particleRotation.z += rotationSpeed; ;

    }
}
