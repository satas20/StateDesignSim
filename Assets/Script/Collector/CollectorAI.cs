using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectorAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform guard;
    public Transform collectable;
    CollectorState currentState;
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new CollectorPatrolState(this.gameObject, agent, anim, guard, collectable);
    }
    private void Update()
    {
        currentState = currentState.Process();
    }
}
