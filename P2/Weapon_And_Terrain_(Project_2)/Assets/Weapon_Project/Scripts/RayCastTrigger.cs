using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTrigger : MonoBehaviour
{

    public float rayCastDistance;

    public bool rayCastDetected;

    Ray rayBasics;

    RaycastHit hit;

    public GameObject teleportLocation;
    public GameObject player;

    void Update()
    {

        GameObject staff = GameObject.Find("Staff_Weapon");
        WeaponAnim staffWeaponAnim = staff.GetComponent<WeaponAnim>();

        GameObject manager = GameObject.Find("GameManager");
        GameManager gameOptions = manager.GetComponent<GameManager>();
        TextContainer textOptions = manager.GetComponent<TextContainer>();

        //Creates a raycast every frame.
        rayBasics = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green, rayCastDistance, true);

        if (Physics.Raycast(rayBasics, out hit, rayCastDistance))
        {
            //Checks if theres a object infront of you with a specific tag.
            if(gameOptions.statueTrigger[0] == false) { 
                if (hit.transform.tag == ("Statue_One"))
            {
                print(textOptions.statueActivation);
                if(Input.GetButtonDown("Fire1"))
                {
                        //Activates the first statue and activates one of the booleans required to open the door.
                    gameOptions.statueTrigger[0] = true;
                    print(textOptions.rayStatueOne);
                        if (gameOptions.statueTrigger[0] && gameOptions.statueTrigger[1] && gameOptions.statueTrigger[2] == true)
                        {
                            print(textOptions.doorActivationNote);
                        }
                    }
            }
        }

            if(hit.transform.tag == ("Teleporter"))
            {
                print(textOptions.teleportActivationNote);
                if(Input.GetButtonDown("Fire1"))
                {
                    //Teleports the player to the location of the teleportlocation.
                    player.transform.position = teleportLocation.transform.position;
                }
            }

            if (gameOptions.statueTrigger[1] == false)
            {
                if (hit.transform.tag == ("Statue_Two"))
                {
                    print(textOptions.statueActivation);
                    if (Input.GetButtonDown("Fire1"))
                    {
                        //Activates the second statue and activates one of the booleans required to open the door.
                        gameOptions.statueTrigger[1] = true;
                        print(textOptions.rayStatueTwo);
                        if (gameOptions.statueTrigger[0] && gameOptions.statueTrigger[1] && gameOptions.statueTrigger[2] == true)
                        {
                            print(textOptions.doorActivationNote);
                        }
                    }
                }
            }

            if (gameOptions.statueTrigger[2] == false)
            {
                if (hit.transform.tag == ("Statue_Three"))
                {
                    print(textOptions.statueActivation);
                    if (Input.GetButtonDown("Fire1"))
                    {
                        //Activates the third statue and activates one of the booleans required to open the door.
                        gameOptions.statueTrigger[2] = true;
                        print(textOptions.rayStatueThree);
                        if(gameOptions.statueTrigger[0] && gameOptions.statueTrigger[1] && gameOptions.statueTrigger[2] == true)
                        {
                            print(textOptions.doorActivationNote);
                        }
                    }
                }
            }

            //Activates a boolean upon having the staff insight.
            if (hit.transform.tag == ("Staff"))
                {
                    print(textOptions.weaponAnimActivationNote);
                    rayCastDetected = true;
                }
                else
                {
                    rayCastDetected = false;
                }

            if (hit.transform.tag == ("Door"))
            {
                //Checks if requirements are met.
                if (gameOptions.doorActionReady == false)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        print(textOptions.doorOpeningFalseNote);
                    }
                }

                if (gameOptions.doorActionReady == true)
                {
                    print(textOptions.doorActivationNote);
                    if(Input.GetButtonDown("Fire1"))
                    {
                        //Makes the door open.
                        gameOptions.DoorOpening();
                        print(textOptions.doorOpening);
                    } 
                }
            }
        }

        if (rayCastDetected == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //Activates the weapon animation sequence.
                staffWeaponAnim.wepAnim = WeaponAnim.state.animTriggerOne;
                print(textOptions.weaponActivation);
            }
        }
    }
}