using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 rawInput;
    void Update()
    {
        Vector3 delta = rawInput;
        transform.position += delta * moveSpeed * Time.deltaTime;
    }

    private void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
        
    }
}
