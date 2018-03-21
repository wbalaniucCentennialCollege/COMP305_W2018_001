using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/State")]
public class State : ScriptableObject {
    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(EnemyStateController controller)
    {
        // Evaluate our actions and decisions/transitions
    }

    private void DoActions(EnemyStateController controller)
    {
        // Loop through all actions associated with this state.
        for (int i = 0; i < actions.Length; i++)
        {
            // Do actions.
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(EnemyStateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            // Determine whether we have decided to transition into another state
        }
    }
}
