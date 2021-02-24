using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroud : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider _collider;
    private Rigidbody rb;
    private float width;
    private float speed = -2f;
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        width = _collider.size.x;
        rb.velocity = new Vector3(speed, 0f, 0f);
        _collider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < -width)
        {
            Vector3 reset = new Vector3((width * 2f), 0, 0);
            transform.position = transform.position + reset;
        }
        
       
    }
    
 
}
