using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShotScript : MonoBehaviour {

    public Vector3 direction = new Vector3(0,0,1);
    public float force = 100;
    public float lifeTimeInSeconds = 5.0f;

    float gravitation = 9.8f;
    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();

        // Push in the first
        rigidBody.AddForce(direction * force, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        lifeTimeInSeconds -= Time.deltaTime;
        if(lifeTimeInSeconds < 0.0f)
        {
            DestroyObject(gameObject);
        }

    }
}
