using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryFire : MonoBehaviour {
	public static PrimaryFire primFire;
	// public
	public GameObject particleShot;

	public float maxHeat;
	public float heating_speed;
	public float cooling_speed;
	public float cooldownTime;
	[HideInInspector]
	public float currentHeat = 0;

	// private
	bool isHeated;

	void Awake(){
		primFire = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHeat > 0) {
			currentHeat -= Time.deltaTime * cooling_speed;
			if (currentHeat < 0) {
				currentHeat = 0;
			}
		}
	}

	public void Fire(){
		if (currentHeat < maxHeat && !isHeated) {
			GameObject newParticleShot = GameObject.Instantiate (particleShot, Camera.main.transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
			ParticleShotScript particleShotScript = newParticleShot.GetComponent<ParticleShotScript> ();
			particleShotScript.direction = Camera.main.transform.forward;

			currentHeat += heating_speed;
			if (currentHeat >= maxHeat) {
				isHeated = true;
				StartCoroutine ("coolingDown");
			}
		}
		Debug.Log ("Primary Fire -- currentHeat = " + currentHeat);
	}

	IEnumerator coolingDown(){
		
		yield return new WaitForSeconds (cooldownTime);

		isHeated = false;
	}
}
