using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PerformActionState : State {

    private AI_Agent myAgent;

    public PerformActionState(AI_Agent agent)
    {
        myAgent = agent;
    }

    public void UpdateState()
    {
        functionality();
    }

    public void functionality()
    {
        if (!myAgent.hasActionQueue()) {

				Debug.Log("ACTION STATE:: No actions to Perform!! -> PlanState");
                
				myAgent.dataProvider.actionsFinished();
                toPlan();
			}

			AI_Action action = myAgent.currentActions.Peek();
			if ( action.isDone() ) {
				
				myAgent.currentActions.Dequeue();
			}

			if (myAgent.hasActionQueue()) {
                //Debug.Log("Still have Actions to DO!");
				action = myAgent.currentActions.Peek();
				bool inRange = action.requiresInRange() ? action.isInRange() : true;

				if ( inRange ) {

					bool success = action.performAction(myAgent.gameObject);

					if (!success) {

						myAgent.dataProvider.planAborted(action);
				        Debug.Log("ACTION STATE:: Plan Failed!! -> PlanState");

                        toPlan();
					}
				} else {
                    Debug.Log("ACTION STATE:: Received moveTo!! -> MoveToState");
             
                    toMoveTo();
				}

			} else {
                Debug.Log("ACTION STATE:: Action Queue Finished!! -> PlanState");
				myAgent.dataProvider.actionsFinished();
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
