using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnplatform : MonoBehaviour
{
    public GameObject PlatformUp;
    float cooldownTimer = 2f;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            Instantiate(PlatformUp, transform.position, Quaternion.identity);
            cooldownTimer = 0.75f;
        }
    }
}
