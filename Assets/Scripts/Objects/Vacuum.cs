using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour {

    public float maxRange;
    public float maxWidth;
    public AnimationCurve suckFalloff; // heh
    public float suckStrength;

    private GameManager _gm;
    
    // Start is called before the first frame update
    void Start() {
        _gm = GameObject.FindWithTag("Player").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        if (!(Vector3.Distance(_gm.transform.position, transform.position) < maxRange + _gm.spawnRange.magnitude)) return;
        // optimization
        foreach (var baby in _gm.babies) {
            var distVec = baby.transform.position - transform.position;
            if (!(Mathf.Abs(distVec.x) < maxWidth) || !(distVec.y < maxRange)) continue; // if within horiz and vert.
            var appliedPower = suckStrength * suckFalloff.Evaluate(distVec.y / maxRange);
            baby.gameObject.transform.position += Vector3.down * appliedPower;
            
            // Debug.Log("sucking!");
        }
    }

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position + new Vector3(0, maxRange / 2), new Vector3(maxWidth * 2, maxRange, 1));
    }
}
