using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryFire : MonoBehaviour {
    public static SecondaryFire secFire;

	// public
	public int maxShots;
	public GameObject LightWaveBullet;

	[HideInInspector]
	public int remainingShots;

	//private


    protected void Awake()
    {
        secFire = this;
    }

	// Use this for initialization
	void Start () {
		remainingShots = maxShots;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addEnergy(){
		if (remainingShots < maxShots) {
			remainingShots++;
		}
	}

	public void Fire(){
		if (remainingShots > 0) {
			GameObject.Instantiate (LightWaveBullet, transform.position + new Vector3(0.0f, 1.0f), transform.rotation);
			remainingShots--;

			if (remainingShots == 0) {
				StartCoroutine ("recharge");
			}
		}
	}

	IEnumerator recharge(){
		yield return new WaitForSeconds (2.0f);

		remainingShots++;
	}
}
