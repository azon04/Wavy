using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter pc;

    // For shooting purposes
    public GameObject particleShot;
    public float shotDistance = 100;

    // Data
    public int lifes = 5;
    public int maxLifes = 5;
    float healthPoint = 100.0f;
    public float maxHealthPoint = 100.0f;

    public float tempDeathAnimDuration;
    float deathAnimTime = 0.0f;
    bool isDead = false;
    
    // Use this for initialization
    void Start()
    {
        pc = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();
            PrimaryFire.primaryFire.Fire();
            LoseLife();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            SecondaryFire.secondFire.Fire();
            //Debug.Log("secondary fire!");
        }
        if (isDead)
        {
            if(deathAnimTime>0)
            {
                deathAnimTime -= Time.deltaTime;
                PlayDeathAnimation();
            }
        }
    }

    void Shoot()
    {
        GameObject newParticleShot = GameObject.Instantiate(particleShot, Camera.main.transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
        ParticleShotScript particleShotScript = newParticleShot.GetComponent<ParticleShotScript>();
        particleShotScript.direction = Camera.main.transform.forward;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // TODO Health life
        }
    }

    public void LoseLife()
    {
        lifes--;
        //if(lifes == 0) Play Death Animation && Call Score UI
        if(lifes <= 0)
        {
            isDead = true;
            GetComponent<CharacterController>().enabled = false;
            deathAnimTime = tempDeathAnimDuration;

        }
    }

    public void LoseHealthPoint(float healthLoss)
    {
        healthPoint -= healthLoss;
        if (healthPoint <= 0) LoseLife();
    }

    void PlayDeathAnimation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90f, transform.rotation.y,transform.rotation.z), (1 - deathAnimTime/tempDeathAnimDuration));
    }

}
