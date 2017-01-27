using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GameManager : MonoBehaviour {

    [Header("Player Settings:")]

    [Range(1.0f, 50f)]
    [Tooltip("Changes the speed to look around with")]
    public float mouseSensitivity;

    [Range(1.0f, 50f)]
    [Tooltip("Changes the speed that you use while running")]
    public float sprintingSpeed;

    [Range(1.0f, 25f)]
    [Tooltip("Changes the speed when ur player is walking")]
    public float walkingSpeed;

    [Range(1.0f, 100f)]
    [Tooltip("The speed your character is falling at")]
    public float gravity;

    [Range(1.0f, 100f)]
    [Tooltip("As the name implies, its used as a force to get off the ground with")]
    public float jumpForce;

    [Tooltip("Sets the max amount of Jumps before u need to be grounded again")]
    public int maxJumps;

    [Tooltip("Shows which Statues are activated")]
    public List<bool> statueTrigger = new List<bool>();

    [Header("Statue Settings:")]

    [Tooltip("Shows the Rotation Sequence of the Gems that are floating above the Statue")]
    public Vector3 statueGemRotation;

    [Tooltip("Shows the Rotation speed of the gems that are untop of the Statues")]
    public float rotationSpeed;

    [Tooltip("This defines the Z Axis of the Statue Crystals, dont attempt to change this to maintain regular Gameplay")]
    public float zGemAxisRotation;

    [Tooltip("This defines the first Crystal Statue")]
    public GameObject statueCrystalOne;

    [Tooltip("This defines the first Crystal Statue")]
    public GameObject statueCrystalTwo;

    [Tooltip("This defines the first Crystal Statue")]
    public GameObject statueCrystalThree;

    [Header("Door Settings:")]

    [Tooltip("This bool triggers once the three statuetriggers are on true")]
    public bool doorActionReady;

    [Tooltip("Changes the speed that the door lerps at")]
    public float doorAnimationTime;

    [Tooltip("This adds a int value to an door activation mechanic in another script named: AnimationDoor")]
    public int voidActivationValueIncrease;

    private void Start()
    {
        TextContainer textOptions = gameObject.GetComponent<TextContainer>();
        print(textOptions.startGame);
    }

    public void Update()
    {
        // Checks every frame if all elements included in the list are true, if the requirements matches
        // it will activate a boolean.
        for (int i = 0; i < statueTrigger.Count; i++)
        {
            if (statueTrigger[i] == true)
            {
                doorActionReady = true;
            }
        }
            

        statueGemRotation.z = zGemAxisRotation + rotationSpeed;

        //Makes the gems on the statues rotate.
        if (statueTrigger[0] == true)
        {
            statueCrystalOne.transform.Rotate(statueGemRotation);
        }

        if (statueTrigger[1] == true)
        {
            statueCrystalTwo.transform.Rotate(statueGemRotation);
        }

        if (statueTrigger[2] == true)
        {
            statueCrystalThree.transform.Rotate(statueGemRotation);
        }
    }

    public void DoorOpening()
    {
        //Increases the int from another script to activate the door animation.
        GameObject.Find("Door").GetComponent<AnimationDoor>().voidActivation = +voidActivationValueIncrease;;
    }
}