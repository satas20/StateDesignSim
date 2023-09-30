using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : GuardState
{
    public ChaseState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _collector)
        : base(_npc, _agent, _anim, _collector)
    {
        name = STATE.CHASE;
        agent.speed = 3;
        agent.isStopped = false;
    }
    public override void Enter()
    {
        base.Enter();
        
    }
    public override void Update()
    {
        agent.SetDestination(collector.transform.position);
        if (agent.hasPath){

            if (CanCatchCollector())
            {
                nextState = new CatchState(npc,agent,anim,collector);
                stage = EVENT.EXIT;
            }
            else if (!CanSeeCollector()) {
                nextState = new IdleState(npc, agent, anim, collector);
                stage = EVENT.EXIT;
            }
        }

    }
    public override void Exit()
    {
        base.Exit();
    }


}
