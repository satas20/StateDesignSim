using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardState 
{
      
    public enum STATE
    {
        IDLE, PATROL, CHASE, CATCH, SLEEP
    };
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };
    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected NavMeshAgent agent;
    protected Animator anim;
    protected Transform collector;
    protected GuardState nextState;

    float visDist = 9f;
    float visAngle = 30.0f;
    float catchDist = 2.0f;

    public GuardState(GameObject _npc, NavMeshAgent _agent, Animator _anim,Transform _collector)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        collector = _collector;
    }
    public virtual void Enter(){    stage = EVENT.UPDATE;   }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public GuardState Process(){
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
    public bool CanSeeCollector(){
        Vector3 direction = collector.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < visDist && angle<visAngle) 
        {
            return true;
        }
        else { return false; }

    }

    public bool CanCatchCollector(){
        Vector3 direction = collector.position - npc.transform.position;
        if (direction.magnitude < catchDist)
        {
            return true;
        }
        else { return false; }
    }
    //Returns a random Vector3 near Guard
    public Vector3 findDestination()
    {
        Vector3 destination =   new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        //Debug.Log("new Destinaiton :"+destination);
        return destination;
    }
}
