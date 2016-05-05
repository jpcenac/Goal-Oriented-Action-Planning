using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class moveToSphere : AI_Action {

    private bool atSphere = false;
    private GameObject targetSphere;

    private float distance;

    public moveToSphere()
    {
        addPrecondition("hasRigidBody", true);
        addPrecondition("atSphere", false);
        addEffect("atSphere", true);

        cost = 5f;
    }

    public override void reset()
    {
        atSphere = false;
        targetSphere = null;
    }

    public override bool isDone()
    {
        return atSphere;
    }

    public override bool checkProceduralPreconditions(GameObject agent)
    {
        try
        {
            targetSphere = UnityEngine.GameObject.Find("TargetSphere");

            return true;

        }
        catch(UnityException e)
        {
            Debug.Log(e);
        }
        return false;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool performAction(GameObject agent)
    {
        //Debug.Log("Performing " + this.GetType());

        //distance = (agent.transform.position - target.transform.position).magnitude;
        //Debug.Log(distance);
        //Debug.Log(isInRange());
        if(isInRange())
        {
           
           atSphere = true;
           return true;
        }
        
        return false;
    }
}
