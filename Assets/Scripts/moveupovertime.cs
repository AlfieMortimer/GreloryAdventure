using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveupovertime : MonoBehaviour
{
    public float Speed;
    float cooldownTimer = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (Speed * Time.deltaTime));
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
            {
               Destroy(gameObject);
         }
        
    }

}
