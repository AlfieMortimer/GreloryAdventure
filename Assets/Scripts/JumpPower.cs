using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPower : MonoBehaviour
{
    public GameObject Barrier;
    Helper helper;
    Vector3 position = new Vector3(3.00441f, -1.75916f, 0);

    // Start is called before the first frame update
    void Start()
    {
        helper = new Helper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            Instantiate(Barrier, position, Quaternion.identity);
        }
    }
}
