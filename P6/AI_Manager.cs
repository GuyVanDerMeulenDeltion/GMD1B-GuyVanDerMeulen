using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Manager : MonoBehaviour {

    public static AI_Manager aiManager;

    [Header("Stat Decrease Rate:")]
    public float decreaseRate = 0.5f;
    
    [Header("Interactable Objects:")]
    public List<NeedFulfillingObject> interactableObjects; 

    //Singleton principe...
    public void Awake() {
        if(aiManager == null) {
            aiManager = this;
        } else {
            Destroy(gameObject);
        }
    } 
}
