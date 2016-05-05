using UnityEngine;
using System.Collections;

public class driveCarAction : AI_Action {

    private bool drivenCar = false;
    private bool driverEnter = false;
    private bool doOnce = false;


    public driveCarAction()
    {
        
        addPrecondition("atVehicle", true);
        addPrecondition("hasKeys", true);
        addEffect("atGoal", true);
        //addEffect("atPosition", true);
    }

    public override void reset()
    {
        drivenCar = false;
        
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone()
    {
        return drivenCar;
    }

    public override bool checkProceduralPreconditions(GameObject agent)
    {
        return true;
    }

    public override bool performAction(GameObject agent)
    {
        Debug.Log("Performing" + this.GetType());
        

        if(driverEnter == true && this.transform.parent == null && doOnce == false)
        {

            //Debug.Log("Driver has Entered Car Door");
            agent.GetComponent<BoxCollider>().enabled = false;
            agent.transform.SetParent(target.transform);
            doOnce = true;
            return true;
        }
        else if(this.transform.parent != null && doOnce == true)
        {
            agent.transform.position = target.transform.position;
            return true;
        }
        else if (this.transform.parent == null && doOnce == true && agent.GetComponent<BoxCollider>().enabled == false)
        {
            //Debug.Log("REENABLING BOX COLLIDER");
            agent.GetComponent<BoxCollider>().enabled = true;
            agent.GetComponent<Rigidbody>().mass = 100;
            agent.GetComponent<Rigidbody>().useGravity = true;
            return true;
        }
        
        if(drivenCar == false)
        {
            return true;
        }
        
        
        return drivenCar;
    }

    public void OnTriggerEnter(Collider col)
    {
        //Debug.Log("AGENT Triggering with:::::::" + col.name);
        if (col.name == "EndZone")
        {
            drivenCar = true;
        }

        if (col.name == "Car")
        {
            driverEnter = true;
        }

    }

    public void OnCollisionEnter(Collision col)
    {
        //Debug.Log("AGENT Triggering with:::::::" + col.collider.name);

        if (col.collider.name == "EndZone")
        {
            drivenCar = true;
        }

        if (col.collider.name == "Car")
        {
           // Debug.Log("Collided with Car, entering Car");
            driverEnter = true;
        }

    }
}