using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class dashManager : MonoBehaviour
{
    public GameObject[] dashObjects;
    public GameObject player;
    public GameObject launchMenu;
    public float countdownTimer;
    public bool outOfTime;
    public GameObject postEffect;

    void Update()
    {       
        for (int i = 0; i < dashObjects.Length; i++)
        {

            if (player.GetComponent<playerMovment>().canLaunch == true && countdownTimer > 0)
            {
                doDash(true,player.transform.position);              
                break;              
            }
            else if(i + 1 == dashObjects.Length && player.GetComponent<playerMovment>().canLaunch == false)
            {
                doDash(false,Vector2.zero);
            }
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;       
    }

    public void doDash(bool pInRange, Vector2 pos)
    {
        if(pInRange)
        {
            player.GetComponent<playerMovment>().launcherPos = pos;
            launchMenu.SetActive(true);         
        }
        else
        {
            player.GetComponent<playerMovment>().launcherPos = new Vector2(0, 0);
            launchMenu.SetActive(false);            
            countdownTimer = .3f;
        }       
    }
}
