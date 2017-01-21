using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    // For shooting purposes
    public GameObject particleShot;
    public float shotDistance = 100;

	private SecondaryFire _secondaryFire;
    
	// Use this for initialization
	void Start () {
		_secondaryFire = GetComponentInChildren<SecondaryFire> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}

		if (Input.GetButtonDown("Fire2"))
		{
			_secondaryFire.Fire();
			Debug.Log("secondary fire!");
		}
	}

    void Shoot()
    {
        GameObject newParticleShot = GameObject.Instantiate(particleShot, Camera.main.transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
        ParticleShotScript particleShotScript = newParticleShot.GetComponent<ParticleShotScript>();
        particleShotScript.direction = Camera.main.transform.forward;
    }
}
