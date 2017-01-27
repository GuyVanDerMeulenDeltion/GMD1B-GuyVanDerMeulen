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

    public bool weaponAfterEffect;

    public Vector3 weaponCurrentRotation;
    public Vector3 weaponPosition;

    private Quaternion targetSequenceRotation;

    public enum state
    {
    neutral,
    animTriggerOne,
    pickupTransform
    }

    public void Update()
    {

        transform.position = weaponPosition;
        weaponPosition.y = yAssist;

        //Announces what to do when which state is activated.
        if (wepAnim == state.animTriggerOne)
        {
            AnimationStart();
        }

        if (wepAnim == state.pickupTransform)
        {
            PickUpReadyAnimation();
        }
    }

    //Weapon Animation Functions.
    public void AnimationStart()
    {
        timer -= Time.deltaTime;
        yAssist += yPositionAddUp;

        //Once the timer is done for, the next part of the animationsequence begins.
        if (timer < timerEnd)
        {
            wepAnim = state.pickupTransform;
        }
        //Rotates the weapon to a specific point.
        targetSequenceRotation = Quaternion.Euler(xRotationFinal, weaponCurrentRotation.y, weaponCurrentRotation.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetSequenceRotation, Time.deltaTime);

        if (yAssist > yMax)
        {
            yAssist = yMax;
        }
}

    public void PickUpReadyAnimation()
    {
        //Makes the weapon Hover above the pedestal.
        //weaponPosition = new Vector3(weaponPosition.x, Mathf.PingPong(Time.time, hoverAnimationAssistance) + yAssist - heightAssist , weaponPosition.z);
        transform.Rotate(weaponCurrentRotation);
        weaponCurrentRotation.z = +rotationSpeed;
        weaponAfterEffect = true;
    }
}
