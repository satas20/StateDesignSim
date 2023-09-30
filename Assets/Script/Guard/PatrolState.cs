using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : GuardState
{
    public PatrolState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _collector)
        : base(_npc, _agent, _anim, _collector)
    {
        name = STATE.PATROL;
        agent.speed = 2;
        agent.isStopped = false;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        if (agent.remainingDistance<1)
        {
            agent.SetDestination(findDestination());
            
        }
        if (CanSeeCollector()){
            nextState = new ChaseState(npc, agent,anim,collector);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }

    
    
     
}
