using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public GameObject head;
    public GameObject body;
    public Rigidbody2D rb; 
    public GameObject player;
    public GameObject Fist_R;
    public GameObject Fist_L;
    public GameObject effect;
    
    Movment2D Movment_script;
    atack atack_script_R;
    atack atack_script_L;
    
    public Animator animator;

    public int health = 3;
    public bool immortal = false;
    public float KnockbackX = 10;
    public float KnockbackY = 10;

    void Start()
    {
        Movment_script = player.GetComponent<Movment2D>();
        atack_script_R =  Fist_R.GetComponent<atack>();
        atack_script_L =  Fist_L.GetComponent<atack>();
         
    }
 
   private void OnCollisionEnter2D(Collision2D col)
    {
        Vector3 direction = (body.transform.position - col.transform.position).normalized;
        direction.x *= KnockbackX;
        direction.y *= KnockbackY;
        if(col.gameObject.tag == "enemy" && immortal == false && health == 0)
        {
            Movment_script.updateOn = false;
            atack_script_R.updateOn = false;
            atack_script_L.updateOn = false;
            atack_script_R.rb.velocity = new Vector2(0,-3);
            atack_script_L.rb.velocity = new Vector2(0,-3);
            Instantiate(effect, head.transform.position,Quaternion.identity);
            Destroy(head);
            animator.SetTrigger("dead");
            Destroy(this);
            rb.velocity = new Vector2(0,0);
        } 
        else if(col.gameObject.tag == "enemy" && immortal == false)
        {
            var head_render = head.GetComponent<Renderer>();
            head_render.material.SetColor("_Color",Color.red);
            immortal = true;
            Movment_script.updateOn = false;
            StartCoroutine (Movment_script.updateOff());
            StartCoroutine (immortalOff());
            rb.velocity = direction;
            health -= 1; 
        } 
        
        
    }

    public IEnumerator immortalOff ()
    {
        var head_render = head.GetComponent<Renderer>();
        yield return new WaitForSeconds (1.0f);
        head_render.material.SetColor("_Color",Color.white);
        immortal = false;
    }
}
