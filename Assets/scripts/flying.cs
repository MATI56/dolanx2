using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flying : MonoBehaviour
{

  public Rigidbody2D rb;
    public float moveSpeed = 5f;
  

    Vector2 movement;
    private float timer;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer -= Time.fixedDeltaTime;
        if(timer < 0)
        {
        float x = Random.Range(-1, 2);
        //float y = Random.Range(-1, 2);
        movement.x = x;
        //movement.y = y;
        timer = 5;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
