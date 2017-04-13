using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharThirdPersonCamera : MonoBehaviour {

    private GameObject gameManager;

    private GameManager gameOptions;
    public Quaternion startPosition;

    private int zero = 0;

    private float transformZ;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameOptions = gameManager.GetComponent<GameManager>();

    }

    public void Update()
    {
        Clamping();

    }

    void Clamping()
    {
        if (gameOptions.isTalking == false) {

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transformZ);
            transformZ = Input.GetAxis("Mouse Y") * Time.deltaTime * gameOptions.mouseLookSensitivity;
            transformZ = Mathf.Clamp(transform.eulerAngles.z + transformZ, gameOptions.minClamp, gameOptions.maxClamp);
        }
    }
}
