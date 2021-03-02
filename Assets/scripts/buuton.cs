using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buuton : MonoBehaviour
{   
    private Animator animator;
    public GameObject objectToMove;
    move object_script;

    private bool press;
    public int x;
    public int y;

   

    void Start()
    {
        object_script = objectToMove.GetComponent<move>();
        animator = this.GetComponent<Animator>();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "fists")
        {
            if(press == false)
            {
                animator.SetBool("pressed",true); 
                object_script.moveThis(x,y);
                press = true; 
            }
        }
        
    }

  
}
