using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovementRotation : MonoBehaviour {

    private GameObject gameManager;

    private GameManager gameOptions;

    private Vector3 currentLocation;

    public float vertVelocity;

    private int zero = 0;

    private void Awake()    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameOptions = gameManager.GetComponent<GameManager>();
    }

    void Update()   {

        CharacterController charMovement = GetComponent<CharacterController>();

        charMovement.Move(currentLocation * Time.deltaTime);
        currentLocation = transform.TransformDirection(currentLocation);

        if (charMovement.isGrounded) {
            vertVelocity = -gameOptions.gravity * Time.deltaTime;
        } else {
            vertVelocity -= gameOptions.gravity * Time.deltaTime;
            currentLocation = new Vector3(currentLocation.x, vertVelocity, currentLocation.z);

        }

        if (gameOptions.isTalking == false) {

            float xPlayerRotation = Input.GetAxis("Mouse X") * Time.deltaTime * gameOptions.mouseLookSensitivity;
            transform.Rotate(zero, xPlayerRotation, zero);

            if (Input.GetButton("Forward")) {
                transform.position += transform.forward * Time.deltaTime * gameOptions.playerWalkingSpeed;
            }

            if (Input.GetButton("Backward")) {
                transform.position -= transform.forward * Time.deltaTime * gameOptions.playerWalkingSpeed;
            }
        }
    }
}
