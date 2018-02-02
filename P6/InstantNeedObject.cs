using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantNeedObject : NeedFulfillingObject {

    [Header("Timer Till Interaction:")]
    public float timer = 5;

    /*Timer based object. De AI kan niets anders doen als het bezig
     * is met dit */
    public IEnumerator NeedTimer(AI_ResourceBased ai) {
        yield return new WaitForSeconds(timer);
        ai.target = null;
        ai.needs[index] += fulfillAmount;
        ai.CalculateCurrentNeed();
        ai.isInteracting = false;
    }
}
