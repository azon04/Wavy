using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    // For shooting purposes
    public GameObject particleShot;
    public float shotDistance = 100;

    // Data
    int lifes = 5;
    public int maxLifes = 5;
    float healthPoint = 100.0f;
    public float maxHealthPoint = 100.0f; 

    // Wave
    int waveCount = 5;
    public int maxWaveCount = 5;
    public float waveCooldownInSeconds = 2.5f;
    float waveCooldown = 0.0f; 
    
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if(CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            ShootWave();
        }

        if(waveCount == 0)
        {
            waveCooldown -= Time.deltaTime;
            if(waveCooldown <= 0.0f)
            {
                waveCount++;
            }
        }
    }

    void Shoot()
    {
        GameObject newParticleShot = GameObject.Instantiate(particleShot, Camera.main.transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
        ParticleShotScript particleShotScript = newParticleShot.GetComponent<ParticleShotScript>();
        particleShotScript.direction = Camera.main.transform.forward;
    }

    void ShootWave()
    {
        waveCount--;

        // TODO Wave

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            // TODO Health life
        }
    }
}
