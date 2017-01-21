using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : Powerups {
    protected override void Awake()
    {

    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") SecondaryFire.secFire.addEnergy();
        Destroy(gameObject);
    }
}
