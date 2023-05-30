using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] int entityHealthValue = 100;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private int scoreValue = 10;
    [SerializeField] ParticleSystem hitEffect;
    
    [SerializeField] private bool enableCameraShake = false;
    private CameraShake cameraShake;
    private AudioHandler audioHandler;
    private ScoreHandler scoreHandler;

    private void Start() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioHandler = FindObjectOfType<AudioHandler>();
        scoreHandler = FindObjectOfType<ScoreHandler>();
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
            //Play Damage Sound
            audioHandler.PlayDamageClip();
            //Call the Destruction of the damageDealer
            damageDealer.Hit();
            
        }
    }

    private void TakeDamage(int damageToDeal){
        entityHealthValue -= damageToDeal;
        if (entityHealthValue <= 0){
            EntityDefeated();
        }
    }

    private void EntityDefeated () {
        if(!isPlayer){
            scoreHandler.IncrementScore(scoreValue);
        }
        audioHandler.PlayExplosionClip();
        Destroy(gameObject);
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
