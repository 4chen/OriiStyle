using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashIdicator : MonoBehaviour
{
    public GameObject player;
    public RectTransform rt, indicator;
    public float lenght;
    public LayerMask GroundLayer;


    void Update()
    {
        rt.position = Camera.main.WorldToScreenPoint(player.transform.position);

        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(player.transform.position), Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Hit.collider != null)
        {        
            Debug.DrawLine(Camera.main.ScreenToWorldPoint(transform.position), Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.magenta);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = new Vector2(mousePos.x - player.transform.position.x, mousePos.y - player.transform.position.y);
            indicator.transform.up = dir;

            lenght = Vector2.Distance(player.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (lenght > 3)
            {
                lenght = 3;
            }

            indicator.sizeDelta = new Vector2(2.5f, lenght * 10);
        }
    }

}
