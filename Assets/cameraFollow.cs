using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        transform.position = new Vector2(target.transform.position.x,transform.position.y); 
    }
}
