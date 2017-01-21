using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float contactDamage = 5.0f;

    public float curHealth; 

	// Use this for initialization
	void Start ()
    {
        curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
 
	}

    public void TakeDamage(float damageValue)
    {
        curHealth -= damageValue;
    }

}
