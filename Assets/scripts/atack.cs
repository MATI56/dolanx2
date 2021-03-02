using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atack : MonoBehaviour
{
    public Transform tr;
    private Vector3 mousePosition;
    public Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 mousePos;

    public bool updateOn = true;

    public float moveSpeed = 100f;
    private int fist;

    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        if(this.gameObject.name == "Fist_L")
        {
            fist = 1;
        }
        else fist = 0;
    }

    // MOVMENT

    void Update()
    {
    if (updateOn == true)
    {
        if (Input.GetMouseButton(fist))
         {
             mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             direction = (mousePosition - transform.position).normalized;
             rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

            if(fist == 1)
            {
             Vector2 lookDir =  mousePos - rb.position;
             float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg -195f;
             rb.rotation = angle;
            }
            else
            {
             Vector2 lookDir =  mousePos - rb.position;
             float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg + 10f;
             rb.rotation = angle;  
            }

         }   
         else {
             rb.velocity = Vector2.zero;
             if(fist == 1)
             {
             this.transform.position = Vector3.MoveTowards(transform.position,tr.position + new Vector3(0.4f,0.05f,0),Time.deltaTime * moveSpeed * 2);
             this.transform.rotation =  new Quaternion(-30,190,20,1); 
             }
             else{
             this.transform.position = Vector3.MoveTowards(transform.position,tr.position - new Vector3(0.4f,-0.05f,0),Time.deltaTime * moveSpeed * 2);    
             this.transform.rotation =  new Quaternion(30,190,20,1);
             }
         }
    }

    }
} 
