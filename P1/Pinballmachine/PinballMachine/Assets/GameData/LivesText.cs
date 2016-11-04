using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{

    //Ongeveer hetzelfde systeem als ScoreText, maar alleen heeft de lives int een heel andere functie
    public Text livestext;

    public void ChangeScore(int points)
    {

        GameObject.Find("GameManager").GetComponent<Lives>().lives += points;
        livestext.text = GameObject.Find("GameManager").GetComponent<Lives>().lives.ToString();
    }
}
