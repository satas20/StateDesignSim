using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform collector;
    GuardState currentState;
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new IdleState(this.gameObject, agent, anim, collector);
    }
    private void Update()
    {
        currentState = currentState.Process();
    }
}
