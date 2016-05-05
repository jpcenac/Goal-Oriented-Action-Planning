using UnityEngine;
using System.Collections;


public interface State{

    void UpdateState();

    void toMoveTo();

    void toDoAction();

    void toPlan();

}

