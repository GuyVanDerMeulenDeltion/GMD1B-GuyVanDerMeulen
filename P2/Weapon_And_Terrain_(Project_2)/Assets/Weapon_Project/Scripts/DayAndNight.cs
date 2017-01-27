using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour {

    public float timeSpeedFormuleAssist;
    public float TimeY;
    public float slerpTimer;
    public float slerpTimerAssist;

    public Vector3 timePosition;
    public Vector3 activationFinalRotation;

    private Quaternion finalRot;

    public GameObject staffWeapon;
	
	// Update is called once per frame
	void Update () {

        slerpTimer = Time.deltaTime * slerpTimerAssist;
        WeaponAnim weaponAnimOptions = staffWeapon.GetComponent<WeaponAnim>();

        finalRot = Quaternion.Euler(timePosition.x, activationFinalRotation.y, timePosition.z);

        //This makes the directional light rotate with an specific set speed if the bool is false.
        if (weaponAnimOptions.weaponAfterEffect == false)
        {
        timePosition.y *= Time.deltaTime;
        timePosition.y = TimeY * Time.deltaTime;
        TimeY =+ timeSpeedFormuleAssist;
        transform.Rotate(timePosition);
        }

        //If this is activated, it forces the rotation to a endstadium and fixates it around that final set rotation.
        if (weaponAnimOptions.weaponAfterEffect == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, finalRot, Time.deltaTime);
        }
    }
}
