using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    private int positionZero = 0;

    void Update()
    {

        GameObject manager = GameObject.Find("GameManager");
        GameManager gameOptions = manager.GetComponent<GameManager>();

        //Lets the x axis of the player rotate by using mousemovements.
        float rotationX = Input.GetAxis("Mouse X") * gameOptions.mouseSensitivity;
        transform.Rotate(positionZero, rotationX, positionZero);

    }
}
