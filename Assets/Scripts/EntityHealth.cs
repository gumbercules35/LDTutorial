using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] int entityHealthValue = 100;
    
    public int GetEntityHealthValue(){
        return entityHealthValue;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Check if the other object collided with has the DealsDamage Component
       
        DealsDamage damageDealer = other.GetComponent<DealsDamage>();
        //if it does
        if (damageDealer != null){
            //Process the damage to this object
            TakeDamage(damageDealer.GetDamageValue());
            //Call the Destruction of the damageDealer
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damageToDeal){
        entityHealthValue -= damageToDeal;
        if (entityHealthValue <= 0){
            Destroy(gameObject);
        }
    }
}
