using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour {

    public float timeSpeedFormuleAssist;
    public float TimeY;
    public Vector3 timePosition;
	
	// Update is called once per frame
	void Update () {

        timePosition.y *= Time.deltaTime;
        timePosition.y = TimeY * Time.deltaTime;
        TimeY =+ timeSpeedFormuleAssist;
        transform.Rotate(timePosition);
	}
}
