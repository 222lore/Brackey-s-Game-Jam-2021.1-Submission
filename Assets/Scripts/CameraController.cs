using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject objectToFollow;

    private Vector3 initialPos;
    
    // Start is called before the first frame update
    void Start() {
        initialPos = transform.position;
        initialPos.x = 0;
    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.position = Vector3.right * objectToFollow.transform.position.x + initialPos;
    }
}
