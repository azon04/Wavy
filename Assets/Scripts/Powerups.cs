using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerups : MonoBehaviour {

    // Use this for initialization
    protected abstract void Awake();

    protected abstract void OnTriggerEnter(Collider other);
}
