using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedOvertimeObject : NeedFulfillingObject {

    public virtual void GiveNeeds(AI_ResourceBased ai) {
        ai.needs[index] += fulfillAmount;
        ai.CalculateCurrentNeed();
    }
}
