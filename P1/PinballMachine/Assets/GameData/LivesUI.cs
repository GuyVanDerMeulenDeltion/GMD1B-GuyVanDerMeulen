using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    // Basically hetzelfde principé als in ScoreUI
    public int points;
    public LivesText livesScript;

    // Refreshed Score
    void OnCollisionEnter()
    {
        livesScript.ChangeScore(points);
    }
}