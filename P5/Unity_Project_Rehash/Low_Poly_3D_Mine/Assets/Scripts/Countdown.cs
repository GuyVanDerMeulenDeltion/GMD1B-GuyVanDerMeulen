using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {

    public float seconds = 30;
	
	void Update () {
        seconds -= Time.deltaTime;
        if(seconds == 0 || seconds < 0) {
            print("30 seconds passed...");
        }	
	}
}
