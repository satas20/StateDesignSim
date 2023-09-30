using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectorFleeState : CollectorState
{
    ParticleSystem effect;
    public CollectorFleeState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _guard, Transform _collectable)
       : base(_npc, _agent, _anim, _guard,_collectable)
    {
        name = STATE.FLEE;
        agent.speed = 4.5f;
        agent.isStopped = false;
    }
    public override void Enter()
    {
        //npc.GetComponent<Renderer>().sharedMaterial.color = Color.Lerp(Color.red, Color.yellow,3f);
        //npc.GetComponent<Material>().color =  Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(Time.time, 1));
       
        agent.speed = 4.5f;
        agent.isStopped = true;
        agent.isStopped = false;

        effect =npc.transform.GetChild(0).GetComponent<ParticleSystem>();
        
        effect.Play();

        agent.SetDestination(findFleeDestination());
        Debug.Log("entered flee state");
        base.Enter();
    }
    public override void Update()
    {
        
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(findFleeDestination());

        }
        if (isFreeToPatrol())
        {
            nextState = new CollectorPatrolState(npc, agent, anim, guard,collectable);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        ParticleSystem effect = npc.GetComponentInChildren<ParticleSystem>();
        effect.Stop();
        //npc.GetComponent<Renderer>().sharedMaterial.color = Color.Lerp(Color.yellow, Color.red, 1f);
        base.Exit();
    }
}
