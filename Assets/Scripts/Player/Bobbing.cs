using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour {

    private float _bobOffset;
    
    // Start is called before the first frame update
    void Start() {
        _bobOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Model").gameObject.transform.position = gameObject.transform.position + (Vector3.up * Mathf.Cos(Time.time + _bobOffset) * 0.25f);
    }
}
