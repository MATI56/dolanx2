using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
   
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void moveThis(int x,int y)
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.velocity = new Vector3(x,y,0);
        Invoke("frizz", 0.2f);
    }

   void frizz(){
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
   }
}


