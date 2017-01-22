using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : EnemyAI {

    // Use this for initialization
    public enum SeekerState
    {
        IDLE,
        ATTACK,
        DEATH
    };

    public SeekerState curState;
    bool following = false;
    float attackDamage = 20f;
    float proximityRadius = 15f;
    float defaultRadius = 5f; //Assign value
    float lightRadius; //Assign value
    float playerDist;

    Vector3 playerPosition;
    NavMeshAgent agent;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        curState = SeekerState.IDLE;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        playerDist = (playerPosition - transform.position).magnitude;

        if (curHealth <= 0)
        {
            curState = SeekerState.DEATH;//then play the death animation
            Destroy(this, 1f);
        }

        if (curState == SeekerState.IDLE)
        {
            Wander();
        }
        /*if (curState == SeekerState.ATTACK)
        {
            Attack();
        }*/

    }

    void Wander()
    {
        //put navmesh to go from left to right
        //find distance between Player and enemy
        GameObject[] particleshots = GameObject.FindGameObjectsWithTag("ParticleShot");
        if (Input.GetButtonDown("Fire2"))
        {

            if (Mathf.Abs(agent.destination.x - playerPosition.x) > 0.1 && Mathf.Abs(agent.destination.z - playerPosition.z) > 0.1)
            {
                following = true;
                agent.destination = playerPosition;
                
            }
            else
                following = false;
            
            return;
        }
        else if (particleshots.Length>0)
        {
            //curState = SeekerState.ATTACK;
            following = false;
            agent.destination = particleshots[particleshots.Length -1].transform.position;
           
           // following = true;
            return;
        }
        else if(following == false)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * defaultRadius;
            randomDirection += transform.position;

            NavMeshHit navHit;
            NavMesh.SamplePosition(randomDirection, out navHit, defaultRadius, NavMesh.AllAreas);
            agent.destination = navHit.position;
        }
    }

    IEnumerator Damage()
    {
        PlayerCharacter.pc.LoseHealthPoint(attackDamage * Time.deltaTime);
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            curState = SeekerState.ATTACK;//then play the attack animation
            StartCoroutine(Damage());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Particle")
        {
            TakeDamage(5.0f);//Or other.gameObject.particleDamage
        }
    }
}
