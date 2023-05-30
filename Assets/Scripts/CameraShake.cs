using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeMagnitude;

    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    
    public void Play(){
        StartCoroutine(Shake());
    }

    private IEnumerator Shake(){
        float shakeTimer = 0f;
        while (shakeTimer < shakeDuration){
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            shakeTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();            
        }
        transform.position = initialPosition;
    }
}