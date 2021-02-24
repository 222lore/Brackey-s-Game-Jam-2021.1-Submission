using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlash : MonoBehaviour {

    public float flashCooldown;
    public GameObject flashPrefab;

    private float _t;
    
    // Start is called before the first frame update
    void Start() {
        _t = 0;
    }

    // Update is called once per frame
    void FixedUpdate() {
        _t += Time.deltaTime;
        if (_t > flashCooldown) {
            // flash!
            Instantiate(flashPrefab, transform.position, Quaternion.identity);
            _t = 0;
        }
    }
}
