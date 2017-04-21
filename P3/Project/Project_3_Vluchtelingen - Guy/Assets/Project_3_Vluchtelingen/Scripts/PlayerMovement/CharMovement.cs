using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour {

    public Vector3 rotation;
    public Vector3 camRotation;
    public GameObject cam;

    [Range(0f, 100f)]
    public float camSpeedVer;
    [Range(0f, 100f)]
    public float camSpeedHor;

    public Vector3 charMovement;
    public float hor;
    public float ver;
    public int speed;

    void Update()
    {
        rotation.y = Input.GetAxis("Mouse X");
        camRotation.x = -Input.GetAxis("Mouse Y");

        transform.Rotate(rotation * camSpeedHor * Time.deltaTime);
        cam.transform.Rotate(camRotation * camSpeedVer * Time.deltaTime);

        hor = Input.GetAxis("Vertical");
        ver = -Input.GetAxis("Horizontal");

        charMovement.x = hor;
        charMovement.z = ver;

        transform.Translate(charMovement * speed * Time.deltaTime);
    }
}
