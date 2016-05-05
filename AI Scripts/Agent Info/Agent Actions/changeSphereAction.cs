using UnityEngine;
using System.Collections;

public class changeSphereAction : AI_Action {

    private bool sphereChanged = false;


    public changeSphereAction()
    {
        cost = 1f;
        addPrecondition("sphereChange", false);
        addPrecondition("atSphere", true);
        addEffect("sphereChange", true);
    }

    public override void reset()
    {
        sphereChanged = false;
        target = null;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone()
    {
        return sphereChanged;
    }

    public override bool checkProceduralPreconditions(GameObject agent)
    {
        return true;
    }

    public override bool performAction(GameObject agent)
    {
        Debug.Log("Performing " + this.GetType());
        target = GameObject.Find("TargetSphere");
        if(target.name == "TargetSphere")
        {
            //target.AddComponent<Renderer>();
            target.GetComponent<MeshRenderer>().enabled = true;
            target.GetComponent<Renderer>().material.color = Color.red;
            sphereChanged = true;
            
        }
        return sphereChanged;
    }

}
