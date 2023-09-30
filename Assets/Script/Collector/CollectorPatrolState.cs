using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectorPatrolState : CollectorState
{
    public CollectorPatrolState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _guard, Transform _collectable)
       : base(_npc, _agent, _anim, _guard,_collectable)
    {
        name = STATE.PATROL;
        agent.speed = 3;
        agent.isStopped = false;
    }
    public override void Enter()
    {
        npc.GetComponent<Renderer>().sharedMaterial.color = Color.Lerp(Color.yellow, Color.red, 1f);
        agent.ResetPath();
        agent.speed = 2.5f;
        agent.SetDestination(findDestination());
        base.Enter();
    }
    public override void Update()
    {
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(findDestination());

        }
        if (CanSeeGuard())
        {
            nextState = new CollectorFleeState(npc, agent, anim, guard, collectable);
            stage = EVENT.EXIT;
        }
        if (CanSeeCollectable())
        {
            nextState = new CollectorCollectState(npc, agent, anim, guard, collectable);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }

}
