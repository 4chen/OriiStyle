using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    public float bestTime;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DataManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    /*   
       World record any% OriiStyle V2
        👑 (1th) steffen - 2:19
           (2nd)    emil - 2:25    
           (3st)   brage - 2:28  
           (4rd)   robin - 2:45
     */
}
