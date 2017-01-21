using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
    
	// Use this for initialization
	protected virtual void Awake ()
    {
		
	}

    protected abstract void OnCollisionEnter(Collision collision);
}
