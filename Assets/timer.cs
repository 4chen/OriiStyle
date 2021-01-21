using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class timer : MonoBehaviour
{
    public GameObject speedTimer, bestTimeEr;
    public float curentTime, actualTime;
    public bool goal;
    public GameObject rsButton;
    public TimeSpan timePlaying, bestTimeSpan;
    public float besttime;
    public bool activeGo;
    public string timePlayedString;

    private void Start()
    {
        //find the last time and display it as best time
        besttime = GameObject.Find("DataManager").GetComponent<DataManager>().bestTime;
        bestTimeSpan = TimeSpan.FromSeconds(besttime);      
        bestTimeEr.GetComponent<Text>().text = bestTimeSpan.ToString("ss'.'ff");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if(Input.anyKey)
        {
            activeGo = true;
        }

        if (!goal)
        {
            if (activeGo)
            {
                actualTime += Time.deltaTime;
                timePlaying = TimeSpan.FromSeconds(actualTime);
                timePlayedString = timePlaying.ToString("ss'.'ff");
                speedTimer.GetComponent<Text>().text = timePlayedString;
            }
        }
        else
        {
            if (besttime > actualTime || besttime == 0)
            {
                //look if its a new best time and update the DataManager
                Debug.Log(actualTime + " is the new best");
                GameObject DM = GameObject.FindGameObjectWithTag("DataManager");
                DM.GetComponent<DataManager>().bestTime = actualTime;
            }

            rsButton.SetActive(true);
        }


    }

    public void OnRSButton()
    {
        SceneManager.LoadScene(0);
    }
}

