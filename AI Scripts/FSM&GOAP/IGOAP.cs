using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//This interface must be inherited to any agent class for it to talk to the planner
public interface IGOAP
{
	HashSet<KeyValuePair<string,object>> retrieveWorldState ();
    
	HashSet<KeyValuePair<string,object>> createGoalState ();


	void planFailed (HashSet<KeyValuePair<string,object>> failedGoal);

	void planFound (HashSet<KeyValuePair<string,object>> goal, Queue<AI_Action> actions);

	void actionsFinished ();

	void planAborted (AI_Action aborter);

	bool moveAgent(AI_Action nextAction);
}

