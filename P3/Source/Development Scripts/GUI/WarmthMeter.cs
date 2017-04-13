using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarmthMeter : MonoBehaviour {

    public Slider warmthMeter;

    public GameObject gameManager;

    public GameManager gameOptions;

	// Use this for initialization
	void Awake () {

        gameOptions = gameManager.GetComponent<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {

        warmthMeter.value = gameOptions.warmthTimer;
    }
}
