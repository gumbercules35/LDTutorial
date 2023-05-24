using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 minBounds;
    private Vector2 maxBounds;
    private Vector2 rawInput;

    private void Start() {
        //Define the world bounds on start
        InitialiseBounds();
    }
    void Update()
    {
        Move();
    }

    private void OnMove(InputValue value) {
        //Store the vector2 from input
        rawInput = value.Get<Vector2>();
        
    }

    private void Move(){
        //Constrain move amount regardless of Frame Rate
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        //Take your current position and add on the change in position, if this value is above or below the bounds, the value is clamped to the bound
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x, maxBounds.x);
        //If Bounds have been set to full viewport, padding variables can be added/subtracted where relevant on the bounds here
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y, maxBounds.y);
        //After clamping update the transform to the new position
        transform.position = newPosition;
    }

    private void InitialiseBounds() {
        //Cache a reference to the camera for cleaner code
        Camera mainCamera = Camera.main;
        //Convert bounds of the viewport to x,y in the world
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0.05f,0.05f));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(0.95f,0.3f));
        //Rather than defining specific bounds here, padding variables can be created and added to the bounds when clamping
    }
}
