using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;

    public float dampingFactor;
    public Vector2 bottomTopBounds;
    public float xLeftBound;
    public float xRightBound;

    private Rigidbody _rb;
    private Vector2 _move1Vec, _move2Vec;

    private void Start() {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        var movement = new Vector3(_move1Vec.x, _move1Vec.y, 0f).normalized * movementSpeed;
        _rb.AddForce(movement);
        _rb.velocity /= dampingFactor;

        if (transform.position.y > bottomTopBounds.y) {
            transform.position = new Vector3(transform.position.x, bottomTopBounds.y, transform.position.z);
        }

        if (transform.position.y < bottomTopBounds.x) {
            transform.position = new Vector3(transform.position.x, bottomTopBounds.x, transform.position.z);
        }
        if (transform.position.x < xLeftBound)
        {
            transform.position = new Vector3(xLeftBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRightBound)
        {
            transform.position = new Vector3(xRightBound, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    public void OnMove_1(InputValue input) {
        /*
         *  Up: (0, 1)
            Down: (0, -1)
            Left: (-1, 0)
            Right: (1, 0)
         */
        _move1Vec = (Vector2) input.Get();
    }

    public void OnMove_2(InputValue input) {
        _move2Vec = (Vector2) input.Get();
    }
}
