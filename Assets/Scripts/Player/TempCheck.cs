using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCheck : MonoBehaviour
{
    public double t = 10;
    public Vector3 firstPos;
    public Vector3 secondPos;
    private Transform player;
    public float dist;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (t == 10)
        {
            firstPos = player.position;
            Debug.Log(firstPos);
        }
        t -= Time.deltaTime;
        if (t <= 10)
        {
            secondPos = player.position;
            Debug.Log("Second position" + secondPos);

        }
        Debug.Log("Time: " + t);


        dist = Vector3.Distance(firstPos,secondPos);
        Debug.Log("Distance: " + dist);

        if (t < 0 && dist < 15)
        {
            tempAdjust();
        }
        if (t < 0 && dist > 15)
        {
            tempReset();
            t = 10;
        }


    }
    private void tempAdjust()
    {
        Debug.Log(dist);
        if (dist > 15)
        {
            t = 10;
        }
        else
        {
            var gm = player.gameObject.GetComponent<GameManager>();
            gm.tempCheck += Time.deltaTime; // one degree per second i think ??
            Debug.Log("Temperature: " + gm.tempCheck);
            if (gm.tempCheck > 30)
            {
                endGame();
            }
        }
        
       
  
    }
    private void tempReset()
    {
        if (dist > 15)
        {
            var gm = player.gameObject.GetComponent<GameManager>();
            gm.tempCheck = 20;
            Debug.Log("Temperature: " + gm.tempCheck);
           
        }
    
    }
    private void endGame()
    {
        Debug.Log("End the Game");
    }


}
