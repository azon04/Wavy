﻿using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter pc;
    public bool isLeftHandTutorial;
    public bool isRightHandTutorial;

    // For shooting purposes
    public GameObject particleShot;
    public float shotDistance = 100;

    // Data
    public int lifes = 5;
    public int maxLifes = 5;
	public float healthPoint = 100.0f;
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale < 1.0f)
                UnPauseGame();
            else
                PauseGame();

        }

        if (Time.timeScale == 0.0f) return;

        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();
            if (isLeftHandTutorial || ((!isRightHandTutorial) && (!isLeftHandTutorial)))
            {
                PrimaryFire.primaryFire.Fire();
            }
        }


        if (Input.GetButtonDown("Fire2"))
        {
            if (((isRightHandTutorial) && (!isLeftHandTutorial)) || ((!isRightHandTutorial) && (!isLeftHandTutorial)))
            {
                SecondaryFire.secondFire.Fire();
                //Debug.Log("secondary fire!");
            }
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

    void PauseGame()
    {
        Time.timeScale = 0.0f;
        GameUISystem.uiSystem.ChangeState(GameUISystem.UIState.PAUSE);
        GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void UnPauseGame()
    {
        Time.timeScale = 1.0f;
        GameUISystem.uiSystem.ChangeState(GameUISystem.UIState.HUD);
        GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

    public float getCurrentHealth()
    {
        return healthPoint;
    }

}
