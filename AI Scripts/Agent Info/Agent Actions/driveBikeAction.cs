using UnityEngine;
using System.Collections;

public class driveBikeAction : AI_Action {

    private bool drivenBike = false;
    private bool driverEnter = false;
    private bool doOnce = false;


    public driveBikeAction()
    {
        addPrecondition("hasRigidBody", true);
        addPrecondition("hasKeys", false);
        addPrecondition("atVehicle", true);
        addEffect("atGoal", true);
        
       
    }

    public override void reset()
    {
        drivenBike = false;
        target = GameObject.Find("Bike");

    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool isDone()
    {
        return drivenBike;
    }

    public override bool checkProceduralPreconditions(GameObject agent)
    {
        return true;
    }

    public override bool performAction(GameObject agent)
    {
       // Debug.Log("Hello");
        if (driverEnter == true && this.transform.parent == null && doOnce == false)
        {

            Debug.Log("Driver has Gotten on Bike");
            agent.GetComponent<BoxCollider>().enabled = false;
            agent.transform.SetParent(target.transform);
            doOnce = true;
            return true;
        }
        else if (this.transform.parent != null && doOnce == true)
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

        if (drivenBike == false)
        {
            return true;
        }


        return drivenBike;
    }

    public void OnTriggerEnter(Collider col)
    {
        //Debug.Log("AGENT Triggering with:::::::" + col.name);
        if (col.name == "EndZone")
        {
            drivenBike = true;
        }

        if (col.name == "Bike")
        {
            driverEnter = true;
        }

    }

    public void OnCollisionEnter(Collision col)
    {
        //Debug.Log("AGENT Triggering with:::::::" + col.collider.name);

        if (col.collider.name == "EndZone")
        {
            drivenBike = true;
        }

        if (col.collider.name == "Bike")
        {
            // Debug.Log("Collided with Car, entering Car");
            driverEnter = true;
        }

    }

}
