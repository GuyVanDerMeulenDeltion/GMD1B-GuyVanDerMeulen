using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour
{

    public AudioSource audiotrue;
    public AudioClip wakemeoop;
    public float power;
    public GameObject prefab;
    public GameObject pinballspawn;
    public bool trigger;

    // Update is called once per frame
    void Update()
    {

        if (trigger == true)
        {
            GameObject pinball = (GameObject)Instantiate(prefab, pinballspawn.GetComponent<Transform>().position, pinballspawn.GetComponent<Transform>().rotation);
            pinball.GetComponent<Rigidbody>().velocity = transform.forward * power;
        }

        if (Input.GetKeyDown("i"))
        {
            audiotrue = GetComponent<AudioSource>();
            audiotrue.clip = wakemeoop;
            audiotrue.Play();
            trigger = true;
        }

    }
}
