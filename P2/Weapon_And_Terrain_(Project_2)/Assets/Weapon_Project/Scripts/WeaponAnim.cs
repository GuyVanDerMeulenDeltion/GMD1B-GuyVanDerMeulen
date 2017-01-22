using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class WeaponAnim : MonoBehaviour {

    public state wepAnim;

    public float yAssist;
    public float yMax;
    public float yPositionAddUp;
    public float xRotationFinal;
    public float rotationSpeed;
    public float heightAssist;
    public float timer;
    public float timerEnd;
    public float hoverAnimationAssistance;

    public Vector3 weaponCurrentRotation;
    public Vector3 weaponPosition;

    public bool exitReady;

    private Quaternion targetSequenceRotation;

    public enum state   {
    neutral,
    animTriggerOne,
    pickupTransform
    }

    public void Update()  {

        transform.position = weaponPosition;
        weaponPosition.y = yAssist;

        //Announces what to do when which state is activated.
        if (wepAnim == state.animTriggerOne) {
            AnimationStart();
        }

        if (wepAnim == state.pickupTransform)    {
            PickUpReadyAnimation();
        }
    }

    //Weapon Animation Functions.
    public void AnimationStart() {
        timer -= Time.deltaTime;
        yAssist += yPositionAddUp;

        if (timer < timerEnd)  {
            wepAnim = state.pickupTransform;
        }

        targetSequenceRotation = Quaternion.Euler(xRotationFinal, weaponCurrentRotation.y, weaponCurrentRotation.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetSequenceRotation, Time.deltaTime);


        if (yAssist > yMax) {
            yAssist = yMax;
        }
}

    public void PickUpReadyAnimation()  {

        //weaponPosition = new Vector3(weaponPosition.x, Mathf.PingPong(Time.time, hoverAnimationAssistance) + yAssist - heightAssist , weaponPosition.z);
        transform.Rotate(weaponCurrentRotation);
        weaponCurrentRotation.z = +rotationSpeed;
        exitReady = true;
    }
}
