using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashObject : MonoBehaviour {

    public AnimationCurve curve;
    public float lifetime;

    private float _time;
    private Vector3 initScale;

    public int flashDamage;
    
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

        var pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(pos.x + GameObject.Find("PLatform (Size 3)").GetComponent<Rigidbody>().velocity.x * Time.deltaTime, pos.y, pos.z);
        
        gameObject.transform.localScale = initScale * curve.Evaluate(_time / lifetime);
        var distFromPlayer = Vector3.Distance(gameObject.transform.position,
            GameObject.FindWithTag("Player").transform.position);
        // Debug.Log(distFromPlayer + " scale" + gameObject.transform.localScale.x / 2);
        if (distFromPlayer <
            gameObject.transform.localScale.x / 2) {
            // Handle flash logic (subtract pts or something)
            // Debug.Log("flashed!");
            GameObject.FindWithTag("Player").GetComponent<GameManager>().ghostEnergy -= flashDamage;
            Destroy(gameObject);
        }
    }
}
