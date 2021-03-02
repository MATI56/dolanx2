using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHit : MonoBehaviour
{
    Rigidbody2D rb;
    public static getHit instance;


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;
        while (knockbackDuration > timer)
        {
            timer +=Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }

}
