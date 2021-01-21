using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashEffect : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(player.transform.position.x - mousePos.x, player.transform.position.y - mousePos.y);
        transform.up = dir;
    }
}
