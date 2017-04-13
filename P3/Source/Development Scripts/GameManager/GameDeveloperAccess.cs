using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDeveloperAccess : MonoBehaviour {

    [Header("Debug Options:")]

    public bool debugActivate;

    private int choiceSelection = 0;
    private int zero = 0;
    private int one = 1;

    private GameManager gameOptions;
    private GameObject gameManager;

    public GameObject selectionInterface;
    public GameObject canvas;

    void Awake ()
    {
        gameManager = GameObject.Find("GameManager");
        gameOptions = gameManager.GetComponent<GameManager>();


        CanvasGroup canvasSelection = selectionInterface.GetComponent<CanvasGroup>();
        canvasSelection.alpha = zero;
    }

	void Update () {
        CanvasGroup canvasSelection = selectionInterface.GetComponent<CanvasGroup>();

        if (debugActivate ==  true)
        {
            if(Input.GetButtonDown("DebugTrigger") && choiceSelection == zero)
            {
                gameOptions.buttonAccess = true;
                canvasSelection.alpha = one;
                choiceSelection = one;
            }
        }	
	}
}
