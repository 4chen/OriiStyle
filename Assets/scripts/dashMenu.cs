using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System;

public class dashMenu : MonoBehaviour
{
    public GameObject DashMenu, player;

    public Transform[] laucher;
    public GameObject postEffect, timeManager, timeStampText;
    public float radius, actualTime;
    public string timeStamp, besttime, timePlayedString;
    public TimeSpan timePlaying;


    void Update()
    {
        for (int i = 0; i < laucher.Length; i++)
        {
            var mag = (laucher[i].position - player.transform.position).magnitude;
            if (mag < 2)
            {
                //fast
                player.GetComponent<playerMovment>().canLaunch = true;
                DashMenu.SetActive(true);
                Time.timeScale = .05f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                postEffect.GetComponent<Volume>().weight = Mathf.MoveTowards(postEffect.GetComponent<Volume>().weight, 1, 1 * Time.unscaledDeltaTime);
             
                //reset snapshot time
                timePlaying = new TimeSpan(0);
                actualTime = 0;

                return;
            }
        }

        //slow
        player.GetComponent<playerMovment>().canLaunch = false;
        DashMenu.SetActive(false);

        //take a snapshot of time 
        if(timeManager.GetComponent<timer>().activeGo == true)
        {
            actualTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(actualTime);
            timePlayedString = timePlaying.ToString("ss'.'ff");
            timeStampText.GetComponent<Text>().text = timePlayedString;
        }


        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        postEffect.GetComponent<Volume>().weight = Mathf.MoveTowards(postEffect.GetComponent<Volume>().weight, 0, 1 * Time.unscaledDeltaTime);
        

    }
}
