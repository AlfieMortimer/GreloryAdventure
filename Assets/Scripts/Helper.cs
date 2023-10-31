using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{

    LayerMask groundLayerMask;
    public GameObject player;

    private void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    public bool GroundCheck(float xo, float yo)
    {
        Color hitColor = Color.white;
        float laserLength = 0.01f;
        bool groundHit = false;

        Vector3 rayOffset = new Vector3(xo, yo, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.down, laserLength, groundLayerMask);
        if (hit.collider != null)
        {
            hitColor = Color.red;
            groundHit = true;
        }

        Debug.DrawRay(transform.position + rayOffset, Vector2.down * laserLength, hitColor);

        return groundHit;

    }

}