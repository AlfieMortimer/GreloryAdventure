using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (2 * Time.deltaTime), transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision != null && collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            print("hitwall");
        }
    }

}
