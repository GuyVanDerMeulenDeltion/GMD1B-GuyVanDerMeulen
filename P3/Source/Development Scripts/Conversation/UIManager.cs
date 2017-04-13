using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private GameObject conversation;
    private ConversationManager conv;

    public void Awake() {
        conversation = GameObject.Find("ConversationManager");
        conv = conversation.GetComponent<ConversationManager>();
    }

    //Shows the correct textdump depending on which state the enum is in.
    public void Update() {
        if(conv.personTalkingTo == ConversationManager.state.person1) {
        conv.currentVisibleLine.text = conv.conversationFiles[0].npcText[conv.currentLineNpcOne];
        }

        if (conv.personTalkingTo == ConversationManager.state.person2) {
            conv.currentVisibleLine.text = conv.conversationFiles[0].npcText[conv.currentLineNpcTwo];

        }
    }

    //Activates the AwnserYes void in the ConvManager Class.
    public void Yes() {
        if(conv.canMakeChoices == true && conv.personTalkingTo == ConversationManager.state.person2) {
            Debug.Log("[You have responded with: YES]");
            conv.AnswerYes();

        }
    }

    //Activates the AwnserNo void in the ConvManager Class.
    public void No() {
        if (conv.canMakeChoices == true && conv.personTalkingTo == ConversationManager.state.person2) {
            Debug.Log("[You have responded with: NO]");
            conv.AnswerNo();
        }
    }

    //Changes the state which person you are talking to.
    public void PersonOne() {
            conv.personTalkingTo = ConversationManager.state.person1;

    }
    
    public void PersonTwo() {
        conv.personTalkingTo = ConversationManager.state.person2;

    }
}
