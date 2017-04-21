using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonFireEventTrigger : MonoBehaviour {

    private GameObject gameManager;
    private GameManager gameOptions;

    private bool sisterIsActive;
    private bool brotherIsActive;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        gameOptions = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Sister")
        {
            sisterIsActive = true;
        }

        if (other.transform.tag == "Player")
        {
            brotherIsActive = true;
        }

        if (brotherIsActive == true && sisterIsActive == true)
        {
            Debug.Log("Both are in the heating zone");
            gameOptions.warmingUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Sister")
        {
            sisterIsActive = false;
        }

        if (other.transform.tag == "Player")
        {
            brotherIsActive = false;
        }

        if(brotherIsActive == false && sisterIsActive == false)
        {
            Debug.Log("Both has left the heating zone");
            gameOptions.warmingUp = false;
        }
    }
}
