
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 7.5f;
    [SerializeField] private float projectileLifetime = 2.5f;
    [SerializeField] private float baseFiringRate = 0.2f;

    [Header("AI Settings")]
    [SerializeField] private bool isEnemy = false;
    //This must be set 0f for Player in the Inspector
    [SerializeField] private float firingRateVariance = 0f;
    [SerializeField] private float minFiringRate = 0.1f;
    

    private Coroutine firingCoroutine;

    //Get and Set 
    private bool isFiring = false;
    public bool IsFiring {
        get {return isFiring;}
        set {isFiring = value;}
    }

    
    void Start()
    {
        //Set isFiring true if isEnemy flag is ticked in Inspector
        if (isEnemy){
            isFiring = true;
        }
    }

   
    void Update()
    {
        Fire();
    }

    private void Fire()
    {  
        //Start the FireContinuously coroutine and assign it, firingCoroutine is no longer null so this is only called once when Fire key is held
         if (isFiring && firingCoroutine == null){
           firingCoroutine = StartCoroutine(FireContinuously());
           
        }else if (!isFiring && firingCoroutine != null) {
            //If we're no longer firing, and a coroutine has been assigned to firingCoroutine, stop the coroutine cached there and set it back to null
            //This allows us to start shooting again, and will only try and stop and clear the cached coroutine if it exists
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously(){
        //This coroutine needs to run indefinitely while the fire key is held, so a purposeful infinite while loop is used
        while (true) {
            //Create 2 projectiles at offsets from the center of the object
            GameObject proj1 = Instantiate(projectilePrefab, new Vector3(transform.position.x - 0.07f, transform.position.y, 0), Quaternion.identity);
            GameObject proj2 = Instantiate(projectilePrefab, new Vector3(transform.position.x + 0.09f, transform.position.y, 0), Quaternion.identity);

            //Grab the rigidbody2D component from the instanced object, and if they exist give them velocity
            Rigidbody2D proj1RB = proj1.GetComponent<Rigidbody2D>();
            if (proj1RB != null) {
                //transform.up relates the direction the object is "facing", the green arrow in the scene view when transforming
                //using this allows enemies to shoot downward, as they are rotated 180 on instantiation
                proj1RB.velocity = transform.up * projectileSpeed;
            }

            Rigidbody2D proj2RB = proj2.GetComponent<Rigidbody2D>();
            if (proj2RB != null) {
                proj2RB.velocity = transform.up * projectileSpeed;
            }
            //Set kill timers on the spawned projectiles so expire
            Destroy(proj1, projectileLifetime);
            Destroy(proj2, projectileLifetime);

            //Calculate the rateOfFire, as firingRateVariance is set to 0 in the inspector for the Player, this value will always equate to the baseFiringRate value
            //If firingRateVariance is not 0, firing pattern will become randomized
            float rateOfFire = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            rateOfFire = Mathf.Clamp(rateOfFire, minFiringRate, float.MaxValue);
            //Wait for rateOfFire amount of time before running the while loop again
            yield return new WaitForSecondsRealtime(rateOfFire);
            
        }
        
    }
}
