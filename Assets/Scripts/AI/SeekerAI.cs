using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerAI : EnemyAI
{
    public enum SeekerState
    {
        IDLE, 
        ATTACK, 
        DEATH
    };

    public SeekerState curState;

    public float proximityRadius;
    float defaultRadius; //Assign value
    float lightRadius; //Assign value

	// Use this for initialization
	void Start ()
    {
        curState = SeekerState.IDLE;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (curHealth <= 0)
        {
            curState = SeekerState.DEATH;
            Destroy(this);
        }

		if (curState == SeekerState.IDLE)
        {
            Wander();
        }
        if (curState == SeekerState.ATTACK)
        {
            Attack();
        }
        
	}

    void Wander()
    {
        //put navmesh to go from left to right
        //find distance between Player and enemy
        // if (dist <= proximity radius) then curState = SeekerState.ATTACK
    }

    void Attack()
    {
        //NavMesh
        // if (dist > proximity radius) then curState = SeekerState.IDLE
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Particle")
        {
            TakeDamage(5.0f/*other.gameObject.particleDamage*/);
        }
    }
}
