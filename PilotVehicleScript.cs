using UnityEngine;
using System.Collections;

public class PilotVehicleScript : MonoBehaviour {

    public float moveSpeed = 100f;
    private Rigidbody thisRigidBody;
    private bool goVehicle = false;

    private Transform childTransform;
	// Use this for initialization
	void Start () {
        thisRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (goVehicle == true )
        {
            thisRigidBody.AddForce(transform.forward * moveSpeed);
            
            //Debug.Log("AGENT IS CURRENTLY DRIVING::::: " + this.gameObject.name);
           // 
            if(transform.childCount > 0)
            {
                //Debug.Log(GetComponentInChildren<GameObject>().name);
                childTransform = transform.FindChild("Test Monkey");
                //Debug.Log(childTransform.GetComponent<BoxCollider>().enabled);
            }
        }

        //GetComponentInChildren<Transform>().position = transform.position;
        
        //Debug.Log(GetComponentInChildren<Transform>().position);

	}

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Vehicle has triggered with: " + col.name);
        if (col.name == "Test Monkey")
        {
            goVehicle = true;
        }
        else if(col.name == "EndZone")
        { 
        }
    }

    void OnCollisionEnter(Collision col)
    {
       // Debug.Log("Vehicle has collided with: " + col.collider.name);
        if (col.collider.name == "Test Monkey")
        {
            //goVehicle = true;

        }
        else if (col.collider.name == "EndZone")
        {
           // Debug.Log("Vehicle has Hit EndZone!!!!!");
            foreach(BoxCollider BC in GetComponents<BoxCollider>())
            {
                BC.enabled = false;
            }

            //GetComponent<BoxCollider>().enabled = false;
            this.transform.DetachChildren();
            //childTransform.parent = null;
            //childTransform.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            // Destroy(thisRigidB true;
        }
    }
}
