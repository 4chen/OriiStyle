using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class playerMovment : MonoBehaviour
{
    public float moveSpeed, groundRadius;
    public LayerMask groundLayer, deathLayer;
    public Rigidbody2D rb;
    public Vector2 playerPos, launcherPos, launchForce, mousePos;
    public bool canLaunch;
    public GameObject dashSmoke;

    void Update()
    {
        playerPos.x = transform.position.x;
        playerPos.y = transform.position.y;

        //DeathPlain
        Collider2D[] isDeath = Physics2D.OverlapBoxAll(transform.position, new Vector2(groundRadius, groundRadius), 0, deathLayer);
        if (isDeath.Length > 0)
        {
            SceneManager.LoadScene(0);
        }

        //on ground check
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if(hit.collider != null)
        {

        }

        Debug.DrawRay(transform.position, -Vector2.up, Color.red);

        //dash
        if(Input.GetKeyDown(KeyCode.Space) && canLaunch)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.velocity = Vector2.ClampMagnitude(mousePos - launcherPos ,1) * launchForce;
            Camera.main.GetComponent<CameraEffects>().Shake();
            Instantiate(dashSmoke, transform.position, Quaternion.identity, null);  
            canLaunch = false;
        }

        //leftright movment
        if (Input.GetKey(KeyCode.A))
        {
            if (hit.collider != null)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (hit.collider != null)
            { 
                rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
            }             
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(groundRadius, groundRadius));
        
    }
    
}
