using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

    public float pushPower;
    public float maxRange;
    public AnimationCurve powerFalloff;

    public float xDistanceMax;

    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        var distVec = _player.transform.position - gameObject.transform.position;
        if (Mathf.Abs(distVec.x) < xDistanceMax && distVec.y < maxRange && distVec.y > 0) { // in range!
            var appliedPower = pushPower * powerFalloff.Evaluate(distVec.y / maxRange);
            _player.GetComponent<Rigidbody>().velocity += Vector3.up * appliedPower;
        }
    }
}
