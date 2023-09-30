using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : GuardState
{
    public IdleState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _collector)
        : base(_npc, _agent, _anim, _collector)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        if(Random.Range(0,100)<10)
        {
            nextState = new PatrolState(npc, agent, anim, collector);
            stage = EVENT.EXIT;
        }
        
    }
    public override void Exit()
    {
        base.Exit();
    }
}
