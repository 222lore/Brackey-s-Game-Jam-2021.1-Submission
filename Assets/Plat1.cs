using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    // private BoxCollider collider;
    private float speed = -6f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // collider = gameObject.GetComponent<BoxCollider>();
        rb.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -20)
        {
            transform.position = transform.position = new Vector3(Random.Range(25,50), Random.Range(-7,7), 0);
            rb.velocity = new Vector3(-(Random.Range(4, 10)), 0, 0);
        }


    }
}
