using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanState : State{

    private AI_Agent myAgent;

    public HashSet<KeyValuePair<string, object>> worldState;
    public HashSet<KeyValuePair<string, object>> goal;

    private Queue<AI_Action> plan;

    public PlanState(AI_Agent agent)
    {
        myAgent = agent;   
    }

    public void UpdateState()
    {
        functionality();
    }

    public void functionality()
    {
        HashSet<KeyValuePair<string, object>> worldState = myAgent.dataProvider.retrieveWorldState();
        HashSet<KeyValuePair<string, object>> goal = myAgent.dataProvider.createGoalState();

        // Plan
        Queue<AI_Action> plan = myAgent.planner.plan(myAgent.gameObject, myAgent.availableActions, worldState, goal);
        if (plan != null)
        {
            // we have a plan, hooray!
            myAgent.currentActions = plan;
            myAgent.dataProvider.planFound(goal, plan);

            toDoAction();

        }
        else
        {
            myAgent.dataProvider.planFailed(goal);
            toPlan();
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

