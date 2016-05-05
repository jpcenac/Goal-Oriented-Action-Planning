using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_Agent : MonoBehaviour
{
    public State currentState;
    public PlanState planState;
    public PerformActionState performActionState;
    public MoveToState moveToState;

    public HashSet<AI_Action> availableActions;
    public Queue<AI_Action> currentActions;

    public IGOAP dataProvider;

    [HideInInspector]
    public AI_Planner planner;

    private void Awake()
    {
        planState = new PlanState(this);
        performActionState = new PerformActionState(this);
        moveToState = new MoveToState(this);
    }

    void Start()
    {
        currentState = planState;
        availableActions = new HashSet<AI_Action>();
        currentActions = new Queue<AI_Action>();
        planner = new AI_Planner();
        DataProvider();
        loadActions();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void addAction(AI_Action action)
    {
        availableActions.Add(action);
    }

    public bool hasActionQueue()
    {
        if(currentActions.Count > 0)
        {
            return true;
        }
        return false;
    }
    private void DataProvider()
    {
        foreach (Component comp in gameObject.GetComponents(typeof(Component)))
        {
            if (typeof(IGOAP).IsAssignableFrom(comp.GetType()))
            {
                dataProvider = (IGOAP)comp;
                return;
            }
        }
    }

    private void loadActions()
    {
        AI_Action[] actions = gameObject.GetComponents<AI_Action>();
        foreach (AI_Action a in actions)
        {
            availableActions.Add(a);
        }
        Debug.Log("Action Pool: ");
            foreach(AI_Action aa in actions)
            {
                //Debug.Log(aa.GetType());
            }
    }
}
