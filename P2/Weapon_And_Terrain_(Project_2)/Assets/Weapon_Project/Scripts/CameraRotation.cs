using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public Vector3 camRotation;
    public float viewRange;
    private float rotationY;

    // Update is called once per frame
    void Update()   {

        GameObject manager = GameObject.Find("GameManager");
        GameManager gameOptions = manager.GetComponent<GameManager>();

        camRotation.y = rotationY;
        rotationY -= Input.GetAxis("Mouse Y") * gameOptions.mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -viewRange, viewRange);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
    }
}
