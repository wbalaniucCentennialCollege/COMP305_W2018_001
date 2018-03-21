using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour {

    public EnemyData enemyData;
    public State currentState;
    public Transform eyes; // Where my character is looking
    public List<Transform> waypoints;
    public LayerMask playerLayer;

    [HideInInspector] public int nextWaypoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentState.UpdateState(this);
	}

    public void TransitionToState(State nextState)
    {
        // Transition to new state if required
    }
}
