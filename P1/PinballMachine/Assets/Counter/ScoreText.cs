using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    // Dit is een variable dat ervoor zorgt dat de text wordt gedisplayed
    public Text scoretext;

    // De integer voor score
    public int score;

    // Dit is een custom void dat word geactiveert in een andere script, om te zien ga naar ScoreUI, De int points ernaast is er ook voor de andere script om punten van objecten bij elkaar op te tellen
    public void ChangeScore(int points) {

        // Dit is de formule
        score += points;

        // Hier word het omgezet in string *text*
        scoretext.text = score.ToString();

    }
}
