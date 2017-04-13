using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour {

    public List<Conversation> conversationFiles = new List<Conversation>();
    public List<string> npcYouAreTalkingTo = new List<string>();
    public List<int> questionNumbers = new List<int>();

    public state personTalkingTo;

    public enum state {person1, person2}

    public int addUp;
    public int addUpNo;
    public int addUpYes;
    public int currentLineNpcOne;
    public int currentLineNpcTwo;

    public bool canMakeChoices;
    public bool questionArrived;
    public bool npcTwoNoSkip;
    public bool canUseOtherNpc = false;

    public GameObject yesButton;
    public GameObject noButton;

    public Text currentVisibleLine;

    public void Update() {
        
        //Changes button colours depending on wether you can make a choice or not.
        if (canMakeChoices == true) {
            noButton.GetComponent<Image>().color = Color.green;
            yesButton.GetComponent<Image>().color = Color.green;
        } else if (canMakeChoices == false) {
            noButton.GetComponent<Image>().color = Color.red;
            yesButton.GetComponent<Image>().color = Color.red;
        }

        if(personTalkingTo == state.person1) {
            noButton.GetComponent<Image>().color = Color.red;
            yesButton.GetComponent<Image>().color = Color.red;
        }

        if (personTalkingTo == state.person1) {
            currentVisibleLine.text = conversationFiles[0].npcText[currentLineNpcOne];
        }

        if (personTalkingTo == state.person2) {
            currentVisibleLine.text = conversationFiles[1].npcText[currentLineNpcTwo];
        }

        QuestionsCheck();

    }

    //Sets the currentline on a whole other Array Route.
    public void AnswerNo() {
        currentLineNpcOne = currentLineNpcTwo;
        currentLineNpcOne += addUpNo;
        currentLineNpcTwo += addUpNo;
        npcTwoNoSkip = true;

    }

    public void AnswerYes() {
        currentLineNpcOne = currentLineNpcTwo;
        currentLineNpcOne += addUpYes;
        currentLineNpcTwo += addUpYes;
        npcTwoNoSkip = true;

    }

    //Skips to the next lines in the string list.
    public void Next() {
        if(questionArrived == false) {
        if (personTalkingTo == state.person1) {
            currentLineNpcOne = currentLineNpcOne + addUp;
        }

            if (personTalkingTo == state.person2 && npcTwoNoSkip == false) {
                currentLineNpcTwo = currentLineNpcTwo + addUp;
            }
        }
    }

    //Checks which lines are considered questions
    public void QuestionsCheck() {
        switch (currentLineNpcTwo) {
            case 2:
            case 10:
                canMakeChoices = true;
                npcTwoNoSkip = true;
                questionArrived = true;
                break;

            default:
                questionArrived = false;
                npcTwoNoSkip = false;
                canMakeChoices = false;
                break;
        }
    }
}
