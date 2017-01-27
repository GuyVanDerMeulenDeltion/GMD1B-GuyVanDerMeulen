using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDoor : MonoBehaviour
{

    public Vector3 doorPosition;
    public float doorPositionY;
    public float yDoorDecreaseSpeed;
    public float maxHeight = 8.18f;
    public int voidActivation;
    public bool activationVoid;
    private int voidActivationMax = 0;
    public float yDoorDecreaseSpeedAssist;

    public void Update()
    {
        transform.position = doorPosition;
        doorPosition.y = doorPositionY;

        //This function describes the speed that the door animation plays.
        yDoorDecreaseSpeed = Time.deltaTime * yDoorDecreaseSpeedAssist;

        if (voidActivation > voidActivationMax)
        {
            activationVoid = true;
        }

        if (activationVoid == true)
        {
            AnimationStart();
        }

        if (voidActivation < voidActivationMax)
        {
            activationVoid = false;
        }

    }

    public void AnimationStart()
    {
        //This makes the door go down into the ground.
        doorPositionY = doorPositionY - yDoorDecreaseSpeed;
        if (doorPositionY < maxHeight)
        {
            doorPositionY = maxHeight;
            voidActivation = voidActivationMax;
        }
    }
}

