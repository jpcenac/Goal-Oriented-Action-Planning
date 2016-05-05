using UnityEngine;
using System.Collections;

public class makeAxe_Action : AI_Action {

    private bool axeMade = false;


    public makeAxe_Action()
    {

    }

    public override void reset()
    {
        axeMade = false;
        target = null;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone()
    {
        return axeMade;
    }

    public override bool checkProceduralPreconditions(GameObject agent)
    {
        return true;
    }

    public override bool performAction(GameObject agent)
    {
        Debug.Log("Performing " + this.GetType());

        Debug.Log(agent);
        return false;
    }
}
