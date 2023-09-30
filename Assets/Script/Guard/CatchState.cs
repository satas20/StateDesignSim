using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatchState : GuardState
{
    public CatchState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _collector)
        : base(_npc, _agent, _anim, _collector)
    {
        name = STATE.CATCH;
        agent.speed = 0;
        
    }
    public override void Enter()
    {
        ParticleSystem effect = npc.GetComponentInChildren<ParticleSystem>();
        effect.Play();
        collector.GetComponent<NavMeshAgent>().isStopped = true;
        agent.isStopped = true;
        Debug.Log("Catched");
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
