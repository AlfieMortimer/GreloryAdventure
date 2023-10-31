using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLava : MonoBehaviour
{
    public GameObject Blast;
    bool shooting = true;
    float cooldownTimer = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            Instantiate(Blast, transform.position, Quaternion.identity);
            cooldownTimer = 0.75f;
        }
    }
}
