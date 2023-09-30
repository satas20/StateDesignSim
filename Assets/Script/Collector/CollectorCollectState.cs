using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectorCollectState : CollectorState
{
    public CollectorCollectState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _guard, Transform _collectable)
      : base(_npc, _agent, _anim, _guard,_collectable)
    {
        name = STATE.FLEE;
        agent.speed = 3;
        agent.isStopped = false;
    }
    public override void Enter()
    {
        agent.speed = 3;
        agent.isStopped = true;
        agent.isStopped = false;

        agent.SetDestination(collectable.position);
        Debug.Log("entered collect state");
        base.Enter();

    }
    public override void Update()
    {
        if (agent.remainingDistance < 1)
        {

            nextState = new CollectorCollectedState(npc, agent, anim, guard, collectable);
            stage = EVENT.EXIT;
            

        }
        else if (CanSeeGuard())
        {
            nextState = new CollectorFleeState(npc, agent, anim, guard, collectable);
            stage = EVENT.EXIT;
        }
        
        
    }
    public override void Exit()
    {
        base.Exit();
    }
}
