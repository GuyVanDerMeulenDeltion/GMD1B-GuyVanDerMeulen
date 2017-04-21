using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCamZoom : MonoBehaviour
{

    private GameObject gameManager;

    private GameManager gameOptions;

    private float mouseWheelValue;

    public float camRangeCheck;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameOptions = gameManager.GetComponent<GameManager>();

    }

    void Update()
    {
        if (gameOptions.isTalking == false) {

            mouseWheelValue = Input.GetAxis("Mouse ScrollWheel") * gameOptions.cameraZoomSpeed * Time.deltaTime;
            camRangeCheck = camRangeCheck + Input.GetAxis("Mouse ScrollWheel") * gameOptions.cameraZoomSpeed * Time.deltaTime;

            if (camRangeCheck > gameOptions.minZoom && camRangeCheck < gameOptions.maxZoom) {
                transform.position += transform.forward * mouseWheelValue;
            }

            if (camRangeCheck < gameOptions.minZoom) {
                camRangeCheck = gameOptions.minZoom;
            }

            if (camRangeCheck > gameOptions.maxZoom) {
                camRangeCheck = gameOptions.maxZoom;
            }
        }
    }
}
