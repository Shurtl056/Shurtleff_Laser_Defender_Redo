using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int intHealth = 50;

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            //take damage
            TakeDamage(damageDealer.GetDamage());
            //tell damage dealer that it hit something 
            damageDealer.Hit(); 
        }

    }
    void TakeDamage(int intDamage)
    {
        intHealth -= intDamage;
        if(intHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
