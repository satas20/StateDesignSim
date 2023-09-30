using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectorState
{

    public enum STATE
    {
        PATROL,FLEE, CHASE, Collect, COLLECTED
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
    protected Transform guard;
    protected Transform collectable;
    protected CollectorState nextState;

    float visDist = 8;
    float visAngle = 90;
    float catchDist = 1.0f;
    float freeDist = 15f;


    public CollectorState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _guard,Transform _collectable)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        guard = _guard;
        collectable = _collectable;
    }
    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public CollectorState Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
    public bool CanSeeGuard()
    {
        Vector3 direction = guard.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < visDist && angle < visAngle)
        {
            return true;
        }
        else { return false; }

    }
    public bool CanSeeCollectable()
    {
        Vector3 direction = collectable.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < visDist && angle < visAngle)
        {
            return true;
        }
        else { return false; }

    }
    public bool isFreeToPatrol(){
        Vector3 direction = guard.position - npc.transform.position;
        if (direction.magnitude > freeDist)
        {
            return true;
        }
        else { return false; }
    }
    public bool CanCollect()
    {
        Vector3 direction = guard.position - npc.transform.position;
        if (direction.magnitude < catchDist)
        {
            return true;
        }
        else { return false; }
    }
    //Returns a random Vector3 near Guard
    public Vector3 findDestination()
    {
        Vector3 destination = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        //Debug.Log("new Destinaiton :"+destination);
        return destination;
    }
    public Vector3 findFleeDestination()
    {
        Vector3 direction = (guard.position - npc.transform.position).normalized *-1;
        Vector3 destination = npc.transform.position+ direction;
        
        //Debug.Log("new Destinaiton :"+destination);
        return destination;
    }
}
