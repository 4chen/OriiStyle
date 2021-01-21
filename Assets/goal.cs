using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public GameObject countdownTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {             
        if (collision.gameObject.name == "player")
        {
            countdownTimer.GetComponent<timer>().goal = true;
        }
    }
}
