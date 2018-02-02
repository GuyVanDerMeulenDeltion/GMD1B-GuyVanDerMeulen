using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_ResourceBased : MonoBehaviour {

    [Header("IsInteracting:")]
    public bool isInteracting = false;

    [Header("Current Goal Settings:")]
    public NeedFulfillingObject target;

    public enum currentAction { GetSleep, GetFood, GetDrink, GetToilet };
    public currentAction state;

    [Header("NavMeshAgent:")]
    public NavMeshAgent thisAgent;

    [Header("Happiness Settings:")]
    public float happiness;

    [Header("Need Settings:")]
    public float[] needs = { 50, 30, 40, 20 };
    public float maxPerNeed = 100;
    public int[] weightCalc = { 3, 1, 2, 2 };

    #region Contains Functions not connected to other functions...

    public void OnTriggerStay(Collider c) {
        InstantNeedObject tempInstant = null;
        NeedOvertimeObject overtimeTempObject = null;

        if (target != null) {
            if (c.transform == target.transform) {
                if (target.gameObject.GetComponent<NeedFulfillingObject>().GetType() == typeof(InstantNeedObject)) {
                    tempInstant = (InstantNeedObject)target.gameObject.GetComponent<NeedFulfillingObject>();
                    if (isInteracting == false) {
                        isInteracting = true;
                        print("woah");
                        StartCoroutine(tempInstant.NeedTimer(this));
                    }

                } else if (target.gameObject.GetComponent<NeedFulfillingObject>().GetType() == typeof(NeedOvertimeObject)) {
                    overtimeTempObject = (NeedOvertimeObject)target.gameObject.GetComponent<NeedFulfillingObject>();
                    overtimeTempObject.GiveNeeds(this);
                }
            }
        }
    }

    //Decreases all *needs* its numbers over time...
    public void DecreaseNeeds() {
        //Goes through all the needs its indexes and lowers it by an static rate...
        for(int i = 0; i < needs.Length; i++) {
            if(needs[i] > 0) {
                needs[i] -= AI_Manager.aiManager.decreaseRate * Time.deltaTime;
            } else {
                needs[i] = 0;
            }
        }
    }
    #endregion

    //Sets up the NavMeshAgent before the first frame initiates...
    public void Awake() {
        thisAgent = GetComponent<NavMeshAgent>();
    }

    //Starts up calculating the current need...
    private void Start() {
        CalculateCurrentNeed();
    }

    //Contains functions that renews the happiness meter and all the stats...
    public void Update() {
        happiness = CalculateCurrentHappiness(needs);

    }

    /*This function checks all the *Need* its indexes and checks
     * based on the weight and current amount which stat should be
     * currently focussed on... */
    public void CalculateCurrentNeed() {

        float[] needsAdditionToHappiness = new float[] {0, 0, 0, 0};

        int indexWithHighestNeed = 0;
        float lowestAmount = Mathf.Infinity;

        for(int i = 0; i < needs.Length; i++) {
            needsAdditionToHappiness[i] = HappinessCalc(needs[i], i);
        }

        for(int o = 0; o < needsAdditionToHappiness.Length; o++) {
            if(needsAdditionToHappiness[o] < lowestAmount) {
                indexWithHighestNeed = o;
                lowestAmount = needsAdditionToHappiness[o];
                
            }
        }

        switch(indexWithHighestNeed) {
            case 0:
                state = currentAction.GetSleep;
                break;

            case 1:
                state = currentAction.GetFood;
                break;

            case 2:
                state = currentAction.GetDrink;
                break;

            case 3:
                state = currentAction.GetToilet;
                break;
        }

        StateMachine();
    }

    /*Calculates the total amount of happiness by multiplying each stat
     based on the weight. The indexes of both arrays represent eachother...*/
    public float CalculateCurrentHappiness(float[] stats) {
        float happiness = 0;

        for(int i = 0; i < stats.Length; i++) {
            happiness += stats[i] * weightCalc[i];
        }

        return happiness;
    }

    /*StateMachine triggers the ObjectTypeOfChoice function following an index that represents the need that
     this AI is going for.*/
    public void StateMachine() {
        switch(state) {
            case currentAction.GetSleep:
                ObjectTypeChoice(0);
                break;

            case currentAction.GetFood:
                ObjectTypeChoice(1);
                break;

            case currentAction.GetDrink:
                ObjectTypeChoice(2);
                break;

            case currentAction.GetToilet:
                ObjectTypeChoice(3);
                break;
        }
    }

    //Compares objects using the ObjectEfficiencyComparison function...
    public void ObjectTypeChoice(int needIndex) {
        float currentNeed = needs[needIndex];
        NeedFulfillingObject current = null;

        if(needs[needIndex] <= (maxPerNeed/2)) {
            for(int i = 0; i < AI_Manager.aiManager.interactableObjects.Count; i++) {
                if(AI_Manager.aiManager.interactableObjects[i].GetType() == typeof(InstantNeedObject)) {
                    if (AI_Manager.aiManager.interactableObjects[i].index == needIndex) {
                        if (current == null) {
                            current = AI_Manager.aiManager.interactableObjects[i];
                        } else {
                            current = ObjectEfficiencyComparison(current, AI_Manager.aiManager.interactableObjects[i], false);
                        }
                    }
                } else if (AI_Manager.aiManager.interactableObjects[i].GetType() == typeof(NeedOvertimeObject)) {
                    if (current == null) {
                        current = AI_Manager.aiManager.interactableObjects[i];
                    } else {
                        current = ObjectEfficiencyComparison(current, AI_Manager.aiManager.interactableObjects[i], true);
                    }
                }
            }
        }

        target = current;

        if (target != null) {
            thisAgent.SetDestination(target.transform.position);
        } 
    }

    //Compares two objects based on distance, the amount given for a need, and how long it takes to receive it...
    public NeedFulfillingObject ObjectEfficiencyComparison(NeedFulfillingObject current, NeedFulfillingObject toCompare, bool chargeObject) {
        NeedFulfillingObject bestOne = current;

        InstantNeedObject currentInstantNeed = null;
        NeedOvertimeObject currentOvertimeNeed = null;
        
        InstantNeedObject compareInstantNeed = null;
        NeedOvertimeObject compareOvertimeNeed = null;

        float efficiencyCurrentNumber = 0;
        float efficiencyNewNumber = 0;

        if(!chargeObject) {
            currentInstantNeed = (InstantNeedObject)current;
            compareInstantNeed = (InstantNeedObject)toCompare;

            efficiencyCurrentNumber = (Vector3.Distance(transform.position, current.gameObject.transform.position) - currentInstantNeed.fulfillAmount + currentInstantNeed.timer);

            efficiencyNewNumber = (Vector3.Distance(transform.position, toCompare.gameObject.transform.position) - compareInstantNeed.fulfillAmount + compareInstantNeed.timer);

        } else {
            currentOvertimeNeed = (NeedOvertimeObject)current;
            compareOvertimeNeed = (NeedOvertimeObject)toCompare;

            efficiencyCurrentNumber = (Vector3.Distance(transform.position, current.gameObject.transform.position) * 2 / currentOvertimeNeed.fulfillAmount);

            efficiencyNewNumber = (Vector3.Distance(transform.position, toCompare.gameObject.transform.position) * 2 / compareOvertimeNeed.fulfillAmount);
        }

        print("Efficiency is: "+ efficiencyCurrentNumber);
        print("Other Target efficiency is: "+efficiencyNewNumber);

        if (efficiencyCurrentNumber > efficiencyNewNumber) {
            print(toCompare);
            bestOne = toCompare;
        }


        return bestOne;
    }

    /*Multiplies the needs by the weight based on the weighindex for the
     * true value of a need...*/
    public float HappinessCalc(float needs, int weightIndex) {
        float needCalc = needs * weightCalc[weightIndex];

        return needCalc;
    }

    
}
