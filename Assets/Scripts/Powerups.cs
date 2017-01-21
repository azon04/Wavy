using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerups : MonoBehaviour {
<<<<<<< HEAD

    protected abstract void Awake();

    protected abstract void OnTriggerEnter(Collider Collide);

=======
    // Use this for initialization
    protected abstract void Awake();

    protected abstract void OnTriggerEnter(Collider other);
>>>>>>> origin/AI_branch
}
