using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] int entityHealthValue = 100;
    [SerializeField] ParticleSystem hitEffect;
    
    [SerializeField] private bool enableCameraShake = false;
    private CameraShake cameraShake;

    private void Start() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    
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
            //Create Explosion Effect
            HitEffect();
            //Call CameraShake
            ShakeCamera();
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

    private void HitEffect(){
        if(hitEffect != null){
            ParticleSystem fxInstance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(fxInstance.gameObject, fxInstance.main.duration + fxInstance.main.startLifetime.constantMax);
        }
    }

    private void ShakeCamera(){
        if (cameraShake != null && enableCameraShake){
            cameraShake.Play();
        }
    }
}
