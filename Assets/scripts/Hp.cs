using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{

    public int health;
    public GameObject effect;


   private void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.tag == "fists")
        {
            health -= 1;
        }
        if (col.gameObject.tag == "fists" && health == 0)
        {
            Instantiate(effect, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
                  
    }
}
