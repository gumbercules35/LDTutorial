using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 7.5f;
    [SerializeField] private float projectileLifetime = 2.5f;
    [SerializeField] private float rateOfFire = 0.5f;
    [SerializeField] private bool isEnemy = false;
    

    private Coroutine firingCoroutine;

    //Get and Set 
    private bool isFiring = false;
    public bool IsFiring {
        get {return isFiring;}
        set {isFiring = value;}
    }

    
    void Start()
    {
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
         if (isFiring && firingCoroutine == null){
           firingCoroutine = StartCoroutine(FireContinuously());
           
        }else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously(){

        
        while (true) {
        GameObject proj1 = Instantiate(projectilePrefab, new Vector3(transform.position.x - 0.07f, transform.position.y, 0), Quaternion.identity);
        GameObject proj2 = Instantiate(projectilePrefab, new Vector3(transform.position.x + 0.09f, transform.position.y, 0), Quaternion.identity);

        Rigidbody2D proj1RB = proj1.GetComponent<Rigidbody2D>();
        if (proj1RB != null) {
            proj1RB.velocity = transform.up * projectileSpeed;
        }
        Rigidbody2D proj2RB = proj2.GetComponent<Rigidbody2D>();
        if (proj2RB != null) {
            proj2RB.velocity = transform.up * projectileSpeed;
        }
        Destroy(proj1, projectileLifetime);
        Destroy(proj2, projectileLifetime);
        yield return new WaitForSecondsRealtime(rateOfFire);
        }
        
    }
}
