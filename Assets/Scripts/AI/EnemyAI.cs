using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float contactDamage = 5.0f;
    public float curHealth = 100f;

    public void TakeDamage(float damageValue)
    {
        print("OH FUCK!!!!!!!");
        curHealth -= damageValue;
    }

}
