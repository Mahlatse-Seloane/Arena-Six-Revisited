using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/State")]
public class State : ScriptableObject
{
    public Actions[] actions;
    public Transitions[] transitions;

    public void UpdateState(PlayerController controller)
    {
        DoActions(controller);
        checkTransitions(controller);
    }

    private void DoActions(PlayerController controller)
    {
        for (int i = 0; i < actions.Length; i++)
            actions[i].Act(controller);
    }

    private void checkTransitions(PlayerController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            if (transitions[i].decision.Decide(controller))
                controller.TransitionToState(transitions[i].trueState);
            else
                controller.TransitionToState(transitions[i].falseState);
        }
    }
}
