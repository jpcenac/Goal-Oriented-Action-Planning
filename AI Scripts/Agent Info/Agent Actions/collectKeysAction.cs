using UnityEngine;
using System.Collections;

public class collectKeysAction : AI_Action {

    private bool collectKeys = false;
   
	// Use this for initialization
    public collectKeysAction()
    {
        cost = 6f;
        addPrecondition("atSphere", true);
        addPrecondition("sphereChange", true);
        
        addEffect("hasKeys", true);
    }

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override bool requiresInRange()
    {
        return true;
    }

    public override void reset()
    {
        collectKeys = false;
        target = null;
    }

    public override bool performAction(GameObject agent)
    {
        Debug.Log("Performing " + this.GetType());

        target = GameObject.Find("Keys");
        //Debug.Log("asidjfoasjidfoajisdfjias" + target);
        if(target.name == "Keys")
        {
            target.GetComponent<Renderer>().material.color = Color.green;
            collectKeys = true;
        }
        return collectKeys;
    }

    public override bool checkProceduralPreconditions(GameObject agent)
    {
        return true;
    }

    public override bool isDone()
    {
        return collectKeys;
    }
}
