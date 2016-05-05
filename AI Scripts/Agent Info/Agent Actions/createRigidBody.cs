using UnityEngine;
using System.Collections;

public class createRigidBody : AI_Action 
{
    private bool hasRigidBody = false;
    private float startTime = 0;
    public float creationComplete = .5f;

    
    public createRigidBody()
    {
        addEffect("hasRigidBody", true);
        addEffect("sphereChange", false);
        cost = 2f;
    }

    public override bool checkProceduralPreconditions(GameObject agent)
    {
        try
        {
            if (agent.GetComponent<Rigidbody>() == null)
            {
                return true;
            }
            return false;
        }
        catch(UnityException e)
        {
            Debug.Log(e);
        }
        return false;

    }
    public override bool isDone()
    {
        return hasRigidBody;
    }
    public override bool requiresInRange()
    {
        return false;
    }
    public override bool performAction(GameObject agent)
    {
        if (startTime == 0) startTime = Time.time;
        //Debug.Log("Performing " + this.GetType());

        if( Time.time - startTime > creationComplete)
        {
            
            this.gameObject.AddComponent<Rigidbody>();
            agent.GetComponent<Rigidbody>().useGravity = false;
            Debug.Log("Action has set " + this.gameObject.name + " to a RigidBody");
            agent.GetComponent<Renderer>().material.color = Color.blue;

            hasRigidBody = true;
            return true;
        }
        return true;
    }

    public override void reset()
    {
        hasRigidBody = false;
        startTime = 0;
    }

}
