using UnityEngine;
using System.Collections;

public class MoveToState : State {
    private AI_Agent myAgent;
    private float distance;
	public MoveToState(AI_Agent agent)
    {
        myAgent = agent;
    }

    public void UpdateState()
    {
        functionality();
    }

    public void functionality()
    {
        AI_Action action = myAgent.currentActions.Peek();
        if (action.requiresInRange() && action.target == null)
        {
            Debug.Log("toPlan");

            toPlan();
        }
        else
        {
            //Debug.Log("Moving State");
            //myAgent.transform.position = action.target.transform.position - myAgent.transform.position * Time.deltaTime;
            Debug.Log("IN MOVE STATE");
            myAgent.transform.position = Vector3.Lerp(myAgent.transform.position, action.target.transform.position, .01f);
            distance = Vector3.Distance(myAgent.transform.position, action.target.transform.position);
            //Debug.Log(distance);
            //Debug.Log(distance);
            if(distance < 10)
            {
                //Debug.Log("Distance < 10");
                action.setInRange(true);
                
            }
            if(action.isInRange())
            {
                Debug.Log("MoveTo STATE:: -> PerformActionState");
                toDoAction();
            }
        }

    }

    public void toMoveTo()
    {
        myAgent.currentState = myAgent.moveToState;
    }

    public void toDoAction()
    {
        myAgent.currentState = myAgent.performActionState;
    }

    public void toPlan()
    {
        myAgent.currentState = myAgent.planState;
    }
}
