using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempCheck : MonoBehaviour
{
    public double t = 8;
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
        if (t == 8)
        {
            firstPos = player.position;
            // Debug.Log(firstPos);
        }
        t -= Time.deltaTime;
        if (t <= 8)
        {
            secondPos = player.position;
            // Debug.Log("Second position" + secondPos);

        }
        // Debug.Log("Time: " + t);


        dist = Vector3.Distance(firstPos,secondPos);
       // Debug.Log("Distance: " + dist);

        if (t < 0 && dist < 8)
        {
            tempAdjust();
        }
        if (t < 0 && dist > 8)
        {
            tempReset();
            t = 8;
        }


    }
    private void tempAdjust()
    {
        // Debug.Log(dist);
        if (dist > 8)
        {
            t = 8;
        }
        else
        {
            var gm = player.gameObject.GetComponent<GameManager>();
            gm.tempCheck += 10*Time.deltaTime; 
            /*
            allows 10 seconds to move once temp warning has been triggered
            not sure if too easy but adjust after play test
            */
            // Debug.Log("Temperature: " + gm.tempCheck);
            PlayerPrefs.SetInt("Temp", (int)gm.tempCheck);
            if (gm.tempCheck > 100)
            {
                endGame();
            }
        }
        
       
  
    }
    private void tempReset()
    {
        if (dist > 8)
        {
            var gm = player.gameObject.GetComponent<GameManager>();
            gm.tempCheck = 20;
            Debug.Log("Temperature: " + gm.tempCheck);
            PlayerPrefs.SetInt("Temp", (int)gm.tempCheck);
           
        }
    
    }
    private void endGame()
    {
        // Debug.Log("End the Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
