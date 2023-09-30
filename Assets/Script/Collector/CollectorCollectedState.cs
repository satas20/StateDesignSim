using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectorCollectedState : CollectorState
{
    public CollectorCollectedState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _guard, Transform _collectable)
     : base(_npc, _agent, _anim, _guard, _collectable)
    {
        name = STATE.COLLECTED;
        agent.speed = 3;
        agent.isStopped = true;
        guard.GetComponent<NavMeshAgent>().isStopped = true;

    }
    public override void Enter()
    {
        
        agent.isStopped = true;

        npc.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        Debug.Log("entered collectED ");
        base.Enter();

    }
    public override void Update()
    {
       


    }
    public override void Exit()
    {
        base.Exit();
    }
}
