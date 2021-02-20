using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {

    public int ghostEnergy;
    public int totalScore;
    public float energyMultiplier = 1;
    public float tempCheck = 20;
    
    [Header("Babies")]
    public GameObject babyPrefab;
    public float spawnMinDist;
    
    public List<GameObject> babies;
    public Vector2 spawnRange;

    [Header("Costs")] public int splitCost;
    public int mergeCost;
    public float mergeScaleMultiplier;

    private Vector2 _btBounds;

    // Start is called before the first frame update
    void Start()
    {
        babies = new List<GameObject>();
        spawnRange = Vector2.one * 2;

        _btBounds = GameObject.FindWithTag("Player").GetComponent<PlayerController>().bottomTopBounds;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(energyMultiplier);
    }

    private void FixedUpdate() {
        List<GameObject> toDestroy = new List<GameObject>();
        try {
            foreach (var baby in babies.Where(baby => baby.transform.position.y < _btBounds.x)) {
                toDestroy.Add(baby);
            }
        }
        catch (Exception) {
            // ignored
        }

        foreach (var b in toDestroy) {
            babies.Remove(b);
            Destroy(b);
        }
    }

    public void OnSplit() {
        if (ghostEnergy >= splitCost) {
            ghostEnergy -= splitCost;
            // if scaling isnt uniform this will break but it shouldnt.
            var tf = transform.Find("Model");
            tf.localScale = Vector3.one * Mathf.Max(1, tf.localScale.x / mergeScaleMultiplier);
            
            var newBaby = Instantiate(babyPrefab, transform);
            float xo = 0, yo = 0;
            bool validAttempt = false;
            var attempts = 0;

            // in theory no duplicate spawnings
            while (!validAttempt) {
                xo = Random.Range(0.75f, spawnRange.x);
                yo = Random.Range(-spawnRange.y / 2, spawnRange.y / 2);

                if (babies.Count == 0) validAttempt = true;
                
                foreach (var b in babies) {
                    if (Vector3.Distance(transform.position - new Vector3(xo, yo, 0), b.transform.position) <
                        spawnMinDist) {
                        validAttempt = false;
                        break;
                    }
                    
                    validAttempt = true;
                }

                if (!validAttempt) {
                    spawnRange += Vector2.one * 1.05f;
                    attempts++;
                }
                
                if (attempts > 50) validAttempt = true;
            }
            
            // Debug.Log(attempts + " " + spawnRange);
            newBaby.transform.position += Vector3.left * xo;
            newBaby.transform.position += Vector3.up * yo;
            babies.Add(newBaby);
        }
    }

    public void OnMerge() {
        if (ghostEnergy >= mergeCost) {
            ghostEnergy -= mergeCost;
            
            var tf = transform.Find("Model");
            tf.localScale *= mergeScaleMultiplier;
        }
    }
    
}
