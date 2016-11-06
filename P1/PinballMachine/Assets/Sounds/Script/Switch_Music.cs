using UnityEngine;
using System.Collections;

public class Switch_Music : MonoBehaviour
{

    //Dit zijn audiofiles die je in spectator kan toevoegen, één van de manieren om meerdere soundfiles toe te laten staan op 1 object
    public AudioClip mainsong1;
    public AudioClip mainsong2;
    
    //Hiermee kan je de audiofiles indelen.
    private AudioSource audio1;
    private AudioSource audio2;

    void Update()
    {
        audio1 = GetComponent<AudioSource>();
        audio2 = GetComponent<AudioSource>();

        // Trigger om void playmainone te activeren
        if (Input.GetKeyDown("o"))
        {
            playmainone();
        }

        // Trigger om void playmaintwo te activeren
        if (Input.GetKeyDown("p"))
        {
            playmaintwo();
        }
    }

    // Met deze void word audio 2 stop gezet, audio 1 geselecteerd en afgespeeld
    void playmainone()
    {
        audio2.Stop();
        audio1.clip = mainsong1;
        audio1.Play();

    }

    // Met deze void word audio 1 stop gezet, audio 2 geselecteerd en afgespeeld
    void playmaintwo() {
        audio1.Stop();
        audio2.clip = mainsong2;
        audio2.Play();
    }
}

