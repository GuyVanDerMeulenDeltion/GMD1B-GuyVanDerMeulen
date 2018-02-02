using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedFulfillingObject : MonoBehaviour {

    [Header("Need FulFill Amount:")]
    public float fulfillAmount;

    [Header("Need Index:")]
    public int index;

    //Add zichzelf aan alle beschikbare need objects...
    public void Start() {
        AI_Manager.aiManager.interactableObjects.Add(this);
    }
}
