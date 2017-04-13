using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour {

    public List<Conversation> conversationFiles = new List <Conversation>();

    [Tooltip("This is the line of text that gets send to the UI.")]
    public string currentTextLine;

}
