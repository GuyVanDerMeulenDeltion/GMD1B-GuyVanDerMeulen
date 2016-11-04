using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    // Deze int word gebruikt bij scoretext voor formule berekening, hens waarom het public is, verder is dit de core dus als je dit zet op een object,
    // dan kan je in inspector het aantal punten toepassen dat het moet geven als het collision detect
    public int points;

    // ScoreText is een reference naar de naam van een andere classfile om daar mee te verbinden
    public ScoreText scoreScript;

    // Deze functie word uitgevoerd upon collision
    void OnCollisionEnter()

    {

        // Hierdoor kan je de object vinden waar de orginele score script opstaat om veranderingen te maken, en refreshed het de text met de current int
        scoreScript.ChangeScore(points);

    }
}