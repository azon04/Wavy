using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Stunner : Powerups {

    public GameObject player;

    protected override void Awake()
    {
    }

    IEnumerator Besiege()
    {
        FirstPersonController fpc = player.GetComponent<FirstPersonController>();
        fpc.Trapped = true;
        yield return new WaitForSeconds(2f);
        fpc.Trapped = false;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Besiege());
        }
    }


}
