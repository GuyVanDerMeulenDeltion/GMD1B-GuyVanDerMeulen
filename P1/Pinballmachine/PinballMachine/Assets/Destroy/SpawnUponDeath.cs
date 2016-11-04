using UnityEngine;
using System.Collections;

public class SpawnUponDeath : MonoBehaviour
{

    // Deze float word gebruikt in een formule om de kracht te bepalen waarop de ball afgeschoten word op spawn.
    public float power;

    // Hiermee word bepaald waar de ball word gespawned
    public GameObject prefab;

    // Dit word gebruikt als reference in welke richting de ball naartoe moet geschoten worden
    public GameObject pinballspawn;

    // Text dat je in inspector made kan veranderen
    public string gameover;

    // Hiermee kan je in inspector een audio clip selecteren die voor deze vars staan
    public AudioClip gameoversound;
    public AudioClip spawn;

    // Hierdoor kan het gebruikt worden
    private AudioSource audioSource;

    void OnCollisionEnter()
    {

        // Deze functie word uitgevoerd als het voldoet met de eisen en als er collision word gedetect
        if (GameObject.Find("GameManager").GetComponent<Lives>().lives > 0)

        {
            // Dit is de formule en pathfinding van welke coordinaten het gespawned moet worden of overgenomen, samen met de formule van snelheid en richting waar het naartoe moet
            GameObject pinball = (GameObject)Instantiate(prefab, pinballspawn.GetComponent<Transform>().position, pinballspawn.GetComponent<Transform>().rotation);

            // Hier word de kracht bepaalt
            pinball.GetComponent<Rigidbody>().velocity = transform.forward * power;

            // Dit is de pathfinding naar de audio componement
            audioSource = GetComponent<AudioSource>();

            // De audioclip die gebruikt moet worden, kan in inspector worden toegepast maar moet wel alvast op het object zitten naast dat je het geselecteerd hebt in inspector mode
            audioSource.clip = spawn;

            //H iermee word de soundfile uitgevoerd
            audioSource.Play();

        }

        // Dit gebeurt er als het niet voldoet aan de bovenste eisen
        else

        {

            // Tekst, reference naar gameover string
            print(gameover);

            // Dit is de pathfinding naar de audio componement
            audioSource = GetComponent<AudioSource>();

            // De audioclip die gebruikt moet worden, kan in inspector worden toegepast maar moet wel alvast op het object zitten naast dat je het geselecteerd hebt in inspector mode
            audioSource.clip = gameoversound;

            // Hiermee word de soundfile uitgevoerd
            audioSource.Play();

        }
    }
}
