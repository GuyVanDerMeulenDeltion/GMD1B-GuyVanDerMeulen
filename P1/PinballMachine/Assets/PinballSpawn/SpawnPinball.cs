using UnityEngine;
using System.Collections;

public class SpawnPinball : MonoBehaviour {

    // Deze file is een beetje een aanhang van de Deathzone SpawnUponDeath script

    // Dit is het uiteindelijke kracht waarop de ball word afgeschoten
    public float power;
    // Dit is de spawnplek van de pinball
    public GameObject prefab;

    // Dit is de object dat uiteindelijk de richting bepaald
    public GameObject pinballspawn;

    // Dit zijn de vars waarbij je in inspector een audiofile kan kiezen, ze hebben wel nog een trigger nodig
    public AudioClip bananacollision;
    public AudioClip spawntwo;

    // Dit is een shortut naar de audiosource component
    private AudioSource audioSource;

    void Start()
    {

        // Dit is de formule waar de pinball uiteindelijk spawned, de force die erachter zit, en welke kant het op moet. Merendeel van dit is pathfinding
        GameObject pinball = (GameObject)Instantiate(prefab, pinballspawn.GetComponent<Transform>().position, pinballspawn.GetComponent<Transform>().rotation);
        pinball.GetComponent<Rigidbody>().velocity = transform.forward * power;

        // Hier word de shortcut gedefineerd
        audioSource = GetComponent<AudioSource>();

        // De sound clip die geselecteerd word
        audioSource.clip = spawntwo;

        // De trigger
        audioSource.Play();

    }

    void OnCollisionEnter() {

        //Ongeveer hetzelfde als hierboven alleen word het getriggerd upon collision
        GameObject pinball = (GameObject)Instantiate(prefab, pinballspawn.GetComponent<Transform>().position, pinballspawn.GetComponent<Transform>().rotation);
        pinball.GetComponent<Rigidbody>().velocity = transform.forward * power;
        audioSource.clip = bananacollision;
        audioSource.Play();

    }
}
