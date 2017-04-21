using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour {

    private Quaternion targetLookRotationAssist;

    private float walkTimer;
    private float zero = 0;

    private GameObject gameManager;
    private GameManager gameOptions = null;

    private bool idle;
    private bool idleTimer;

    public void Awake()
    {
        //NpcTransform is equal to the Current Position.

    }

    private void start () {

        //PlayerTargetTransform is equal to the referenced transform position.
        gameOptions.playerPositionAndRotation = gameOptions.target.transform;

	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals ("NpcIdleTrigger"))
        {
            idle = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("NpcIdleTrigger"))
        {
            idle = false;
            idleTimer = true;

        }
    }

    public void Update()
    {
        gameManager = GameObject.Find("GameManager");
         GameManager gameOptions = gameManager.GetComponent<GameManager>();

        if (idleTimer == true)
        {
            walkTimer += Time.deltaTime;

        }

        if (walkTimer > gameOptions.npcWalkingTimerMaximum)
        {
            idleTimer = false;
            walkTimer = zero;
            print("Hey, don't walk away from me!");

        }

        //Makes the Npc rotate towards the Player.
        targetLookRotationAssist = Quaternion.LookRotation(gameOptions.playerPositionAndRotation.position - transform.position);

        //The speed it rotates with towards the Player.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetLookRotationAssist, gameOptions.npcRotationSpeed * Time.deltaTime);


        if (idleTimer == false && idle == false) {
            //Lets the Npc walk based on where it has rotated to.
            transform.position += transform.forward * gameOptions.npcWalkingSpeed * Time.deltaTime;

        } else if (idle == true || idleTimer == true )
        {
            IdleEvent();
        }
    }


    private void IdleEvent()
    {

    }
}
