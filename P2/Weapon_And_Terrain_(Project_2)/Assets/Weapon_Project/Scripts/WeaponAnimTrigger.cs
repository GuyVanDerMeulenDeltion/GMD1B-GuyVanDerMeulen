using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimTrigger : MonoBehaviour
{

    public float rayCastDistance;
    public bool rayCastDetected;
    Ray rayBasics;
    RaycastHit hit;

    void Update()   {
        GameObject staff = GameObject.Find("Staff_Weapon");
        WeaponAnim staffWeaponAnim = staff.GetComponent<WeaponAnim>();


        rayBasics = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green, rayCastDistance, true);

        if (Physics.Raycast(rayBasics, out hit, rayCastDistance))
        {
                if (hit.transform.tag == ("Staff"))
                {
                    print("Press Enter to Activate Weapon Animation");
                    rayCastDetected = true;
                }
                else
                {
                    rayCastDetected = false;
                }
            }

        if (rayCastDetected == true)    {
            if (Input.GetButtonDown("Fire1"))    {

                staffWeaponAnim.wepAnim = WeaponAnim.state.animTriggerOne;
            }
        }
    }
}