using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSister : MonoBehaviour {

    private Quaternion targetLookRotationAssist;

    private float walkTimer;
    private float zero = 0;

    private GameObject gameManager;
    private GameManager gameOptions = null;

    private bool idle;
    private bool idleTimer;

    private void start () {

        //PlayerTargetTransform is equal to the referenced transform position.
        gameOptions.playerPositionAndRotation = gameOptions.target.transform;

	}

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        gameOptions = gameManager.GetComponent<GameManager>();

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

        if(gameOptions.warmthTimer == zero)
        {
            Destroy(gameObject);
        }

        if (idleTimer == true)
        {
            walkTimer += Time.deltaTime;

        }

        if (walkTimer > gameOptions.npcWalkingTimerMaximum)
        {
            idleTimer = false;
            walkTimer = zero;

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
