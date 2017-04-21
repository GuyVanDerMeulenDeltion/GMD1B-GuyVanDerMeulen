using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    [Header("Managers:")]

    [Tooltip("This is the GameManager that should be instantiated every Level.")]
    public GameObject gameManagerObject;


	void Awake () {
        if(GameManager.gameManagerCheck == null)
        {
            Instantiate(gameManagerObject);
        }
    }
}
