using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bulletscript : MonoBehaviour
{
    Helper helper;
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision != null && collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
        if (collision != null && collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}
