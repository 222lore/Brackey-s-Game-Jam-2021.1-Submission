using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float multiplier;
    private float t = 0;
    public bool multiplierOn = false;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            var dist = Vector3.Distance(player.position, transform.position);
            // Debug.Log(dist);  

            if (dist < 3 && !multiplierOn) 
            {         
                Activate();
                multiplierOn = true;
                t = 0;
            }
            
            if (multiplierOn)
            {
                t += Time.deltaTime;
            }
            
            if (t >= 10 && multiplierOn) 
            {
                    Reset();
                    multiplierOn = false;
            }
    }

    private void Activate()
    {
        var gm = player.gameObject.GetComponent<GameManager>();
        gm.energyMultiplier = multiplier;

        var fireParticles = gameObject.GetComponentInChildren<ParticleSystem>();
        fireParticles.Stop();
    }

    private void Reset()
    {
        var gm = player.gameObject.GetComponent<GameManager>();
        gm.energyMultiplier = 1;
        
        var fireParticles = gameObject.GetComponentInChildren<ParticleSystem>();
        fireParticles.Play();
    }
}
