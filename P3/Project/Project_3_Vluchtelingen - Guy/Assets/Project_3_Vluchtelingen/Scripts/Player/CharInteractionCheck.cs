using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInteractionCheck : MonoBehaviour {

    private GameObject gameManager;
    private GameManager gameOptions;

    private void Awake()    {
        gameManager = GameObject.Find("GameManager");
        gameOptions = gameManager.GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)  {
        if (other.transform.tag == "Militair")  {
            gameOptions.canTalk = true && gameOptions.hasTalked == false;
        }
    }

    public void OnTriggerExit(Collider other)   {
        if (other.transform.tag == "Militair")  {
            gameOptions.canTalk = false && gameOptions.hasTalked == false;
        }
    }
}
