using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    // For shooting purposes
    public GameObject particleShot;
    public float shotDistance = 100;
    
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
    }

    void Shoot()
    {
        GameObject newParticleShot = GameObject.Instantiate(particleShot, Camera.main.transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
        ParticleShotScript particleShotScript = newParticleShot.GetComponent<ParticleShotScript>();
        particleShotScript.direction = Camera.main.transform.forward;
    }
}
