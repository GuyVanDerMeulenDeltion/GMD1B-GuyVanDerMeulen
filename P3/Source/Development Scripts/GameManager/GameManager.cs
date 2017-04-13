using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float zero = 0;

    public static GameManager gameManagerCheck = null;

    [Header("GUI Settings:")]

    [Tooltip("Once this is true, buttons on the selectionscreen can be clicked")]
    public bool buttonAccess;

    public GameDeveloperAccess debugOptions;
    public CanvasGroup canvasSelection;

    [Header("StoryLine Decisions Made:")]
    [Tooltip("This defines the choice you made in the game.")]
    public state storyLineDecisions;

    [Header("AI Settings:")]

    [Tooltip("This defines the speed the NPC rotates at.")]
    [Range(0, 10f)]
    public float npcRotationSpeed = 5;

    [Tooltip("This is the movement speed of this NPC.")]
    [Range(0, 50f)]
    public float npcWalkingSpeed = 5;

    [Tooltip("This is the max amount of seconds the NPC will wait after collision with the Player.")]
    [Range(0, 5f)]
    public float npcWalkingTimerMaximum = 2;

    [Tooltip("The NPC will follow this specific GameObject.")]
    public GameObject target;

    [Header("Overall Settings:")]

    [Tooltip("Current Fallingspeed.")]
    public float verticalVelocity;

    [Range(0f, 100f)]
    public float gravity;

    [Header("Camera Settings:")]

    [Tooltip("This defines how fast the camera can zoom in/out.")]
    [Range(1, 100f)]
    public float cameraZoomSpeed;

    [Tooltip("This defines the max zoom from nearby.")]
    [Range(0f, 10f)]
    public float maxZoom;

    [Tooltip("This defines the max zoom from far away.")]
    [Range(-5f, 10f)]
    public float minZoom;

    [Tooltip("Defines the speed which the Camera turns around with.")]
    [Range(1, 100f)]
    public float mouseLookSensitivity;

    [Tooltip("Defines the max amount that the camera can turn with.")]
    [Range(-360, 360f)]
    public float maxClamp;

    [Tooltip("Defines the minimum amount that the camera can turn with.")]
    [Range(-360, 360f)]
    public float minClamp;

    [Header("Player Settings:")]

    [Tooltip("This is the walking speed of the Player.")]
    [Range(0f, 50f)]
    public float playerWalkingSpeed;

    [Tooltip("This is the Position of the Player.")]
    public Transform playerPositionAndRotation;

    [Header("Game Settings:")]

    [Tooltip("This is the countdown thats based on warmth, when the counter hits the minWarmt variable, the NPC gets knocked out.")]
    [Range(1, 100)]
    public float warmthTimer;

    [Tooltip("The maximum that the warmthTimer can reach.")]
    [Range(1, 100)]
    public float maxWarmth = 100;

    [Tooltip("The minimal that the warmthTimer can reach.")]
    [Range(-50, 0)]
    public float minWarmt = 0;

    [Tooltip("This detects if the player is near a heated spot.")]
    public bool warmingUp;

    [Header("Dialogue Settings:")]

    [Tooltip("This checks if you are talking or not.")]
    public bool canTalk;

    [Tooltip("This checks if you are talking or not.")]
    public bool hasTalked;

    [Tooltip("This checks if you are talking or not.")]
    public bool isTalking;

    public enum state
    {
        neutral,
        declineMilitair,
        acceptedMilitair
    }

    public void Awake()
    {
        Cursor.visible = false;

        if (gameManagerCheck == null) {
        gameManagerCheck = this;
        }
        
        else if(gameManagerCheck != this) {
        Destroy(gameObject);
        }

        debugOptions = gameObject.GetComponent<GameDeveloperAccess>();
        canvasSelection = debugOptions.selectionInterface.GetComponent<CanvasGroup>();
    }

    public void TaskOnClickDecline()
    {
        if (buttonAccess == true)
        {
            storyLineDecisions = state.declineMilitair;
            print("You declined the Offer");
            buttonAccess = false;
            canvasSelection.alpha = zero;
        }
    }

    public void TaskOnClickAccept()
    {
        if (buttonAccess == true)
        {
            storyLineDecisions = state.acceptedMilitair;
            print("You accepted the Offer");
            buttonAccess = false;
            canvasSelection.alpha = zero;
        }
    }


    public void Update()
    {

        if(warmingUp == false && isTalking == false)
        {
        warmthTimer -= Time.deltaTime;
        }
        else if(warmingUp == true && isTalking == false)
        {
            warmthTimer += Time.deltaTime;
        }

        if (warmthTimer < minWarmt)
        {
            warmthTimer = minWarmt;
        }

        if (warmthTimer > maxWarmth)
        {
            warmthTimer = maxWarmth;
        }
    }
}
