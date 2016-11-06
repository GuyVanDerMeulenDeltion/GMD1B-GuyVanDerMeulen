using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour
{

    // Een int die in bijv. Deathzone een functie heeft en in LivesText en LivesGUI
    public int lives;

    // Een custom made void dat openbaar is voor andere files, wanneer het uit word gevoerd word de int lives met één verhoogd.
    public void GiveLife() {
    
        lives = lives + 1;

    }

    //  Een custom made void met niet echt bepaald een funcie... Het word gebruikt in een andere script om de LivesText te refreshen upon collision met de banana
    public void MinusLife()

    {

        lives = lives + 0;

    }
}
