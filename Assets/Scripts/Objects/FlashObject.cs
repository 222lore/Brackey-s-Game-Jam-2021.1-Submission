using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashObject : MonoBehaviour {

    public AnimationCurve curve;
    public float lifetime;

    private float _time;
    private Vector3 initScale;
    
    // Start is called before the first frame update
    void Start() {
        _time = 0;
        initScale = gameObject.transform.localScale;
        gameObject.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate() {
        _time += Time.deltaTime;
        if(_time > lifetime) Destroy(gameObject);
        
        gameObject.transform.localScale = initScale * curve.Evaluate(_time / lifetime);
        if (Vector3.Distance(gameObject.transform.position, GameObject.FindWithTag("Player").transform.position) <
            gameObject.transform.localScale.x) {
            // Handle flash logic (subtract pts or something)
            Debug.Log("flashed!");
        }
    }
}
