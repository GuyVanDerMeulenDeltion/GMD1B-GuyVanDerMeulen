using UnityEngine;
using System.Collections;

public class Deathzone : MonoBehaviour
{

    // Functie word uitgevoerd upon colission
    void OnCollisionEnter(Collision c)
    {

        // Hierdoor dankzij de reference bij OnCollisionEnter, word de object vernietigd als het met een object met deze script in aanraking komt
        Destroy(c.gameObject);

        // Dit is pathfinding naar de int *lives* om daar een custom made void uit te voeren
        GameObject.Find("GameManager").GetComponent<Lives>().MinusLife();

    }
}
