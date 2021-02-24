using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Coin : MonoBehaviour {

    public float collectionDist;
    public int value;
    private int collectedCoins;
    private float time = 0;
    public GameObject coin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        time += Time.deltaTime;
        if (time > Random.Range(3,7))
        {
            Instantiate(coin, new Vector3(Random.Range(-17,17), Random.Range(-7,7), 0), Quaternion.identity);
            time = 0;
        }
       

        gameObject.transform.eulerAngles = Vector3.up * Time.time * 50f;
        var player = GameObject.FindWithTag("Player");
        if (Vector3.Distance(transform.position, player.transform.position) < collectionDist)
        {
            player.GetComponent<GameManager>().ghostEnergy += (int) (value * player.GetComponent<GameManager>().energyMultiplier);
            Destroy(gameObject);
        }
    }

    public void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, collectionDist);
    }
}
