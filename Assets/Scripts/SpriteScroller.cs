using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 scrollSpeed;

    private Vector2 offset;
    private Material material;
    private void Awake() {
        material = GetComponent<SpriteRenderer>().material;
    }

    
    void Update()
    {
        offset = scrollSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
