using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    // Update is called once per frame
    void Update()   {

        GameObject manager = GameObject.Find("GameManager");
        GameManager gameOptions = manager.GetComponent<GameManager>();

        float rotationX = Input.GetAxis("Mouse X") * gameOptions.mouseSensitivity;
        transform.Rotate(0, rotationX, 0);

    }
}
