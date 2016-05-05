using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monkey : MonoBehaviour, IGOAP
{
    public float moveSpeed = 1f;

    void Start()
    {
        //nothing
    }
    void Update()
    {
        //nothing
    }


    public HashSet<KeyValuePair<string, object>> retrieveWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

        worldData.Add(new KeyValuePair<string, object>("atSphere", false));
        worldData.Add(new KeyValuePair<string, object>("boxRemoved", false));
        worldData.Add(new KeyValuePair<string, object>("hasKeys", false));
        worldData.Add(new KeyValuePair<string, object>("atVehicle", false));

        return worldData;
    }

    public HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> myGoal = new HashSet<KeyValuePair<string, object>>();

        //myGoal.Add(new KeyValuePair<string, object>("hasKeys", true));
        myGoal.Add(new KeyValuePair<string, object>("atGoal", true));

        return myGoal;
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<AI_Action> actions)
    {
        Debug.Log("Found a plan with " + actions.Count + " actions in Queue");
        foreach(AI_Action action in actions)
        {
            //Debug.Log(action.GetType());
        }
    }

    public void planAborted(AI_Action aborted)
    {
        Debug.Log("AI AGENT ABORTED PLAN ON :::" + aborted);
    }

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {
        //Doing nothing
    }

    public void actionsFinished()
    {
        Debug.Log("Actions finished! Plan Succeeded!");
    }

    public bool moveAgent(AI_Action nextAction)
    {
        float walk = moveSpeed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, walk);

        if (gameObject.transform.position.Equals(nextAction.target.transform.position))
        {
            nextAction.setInRange(true);
            return true;
        }
        else
            return false;
    }
}
