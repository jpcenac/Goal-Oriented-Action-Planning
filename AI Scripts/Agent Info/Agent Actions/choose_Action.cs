using UnityEngine;
using System.Collections;

public class choose_Action : AI_Action {

    private bool choiceMade = false;

        public choose_Action()
        {
            cost = 2;
            addEffect("atVehicle", true);
        }

        public override void reset()
        {
            choiceMade = false;
            target = null;
        }

        public override bool requiresInRange()
        {
            return false;
        }

        public override bool isDone()
        {
            return choiceMade;
        }

        public override bool checkProceduralPreconditions(GameObject agent)
        {
            return true;
        }

        public override bool performAction(GameObject agent)
        {
            target = GameObject.Find("Car");
            choiceMade = true;
            return choiceMade;
        }
}
