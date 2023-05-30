using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
   [SerializeField] AudioClip playerFires;
   [SerializeField] [Range(0f,1f)] float playerShootingVolume = 1f;
   [SerializeField] AudioClip enemyFires;
   [SerializeField] [Range(0f,1f)] float enemyShootingVolume = 1f;
   [SerializeField] AudioClip entityDestroyed;
   [SerializeField] [Range(0f,1f)] float entityDestroyedVolume = 1f;
   [SerializeField] AudioClip damageTaken;
   [SerializeField] [Range(0f,1f)] float damageTakenVolume = 1f;

   public void PlayShootingClip(string tag){
    if(playerFires != null && enemyFires != null){   
        Vector3 cameraPos = Camera.main.transform.position;     
        switch (tag){
            case "Player":
                AudioSource.PlayClipAtPoint(playerFires, cameraPos, playerShootingVolume);
                break;
            case "Enemy":
                AudioSource.PlayClipAtPoint(enemyFires, cameraPos, enemyShootingVolume);
                break;
            default:
                break;
            }
        }
   }

    private void PlayAudio(AudioClip clip, float volume = 1f){
        if (clip != null){
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
   public void PlayExplosionClip() {
        PlayAudio(entityDestroyed, entityDestroyedVolume);
   }

   public void PlayDamageClip(){
        PlayAudio(damageTaken, damageTakenVolume);
   }
}
