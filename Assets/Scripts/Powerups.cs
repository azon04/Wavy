using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerups : MonoBehaviour {

	protected virtual void Awake()
    {

    }

    protected abstract void OnCollisionEnter(Collision Collide);

}
