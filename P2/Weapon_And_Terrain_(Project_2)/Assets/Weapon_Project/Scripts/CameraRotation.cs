using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public Vector3 camRotation;
    public float viewRange;
    private float rotationY;

    void Update()   {

        GameObject manager = GameObject.Find("GameManager");
        GameManager gameOptions = manager.GetComponent<GameManager>();

        //This makes the cam rotate with the y axis by using the mouse, with ofcourse a set senstivity thats called from the GameManager Script.
        //This also clamps the Y Axis between the viewrange set in the inspector.
        camRotation.y = rotationY;
        rotationY -= Input.GetAxis("Mouse Y") * gameOptions.mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -viewRange, viewRange);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
    }
}
