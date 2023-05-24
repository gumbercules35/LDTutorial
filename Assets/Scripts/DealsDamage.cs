using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealsDamage : MonoBehaviour
{
   [SerializeField] int damageValue = 10;


   public int GetDamageValue() {
    return damageValue;
   }

   public void Hit(){
      //Called on collision, damaged dealers are destroyed once damage has been dealt
      //BE WARY OF WHAT IS DEFINED AS A DAMAGE DEALER DUE TO THIS
    Destroy(gameObject);
   }
}
