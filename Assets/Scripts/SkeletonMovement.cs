using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    //Variables
    bool onground = false;
    float speed = 0.5f;
    public float EnemyHealth = 3f;
    //other stuff for things to work
    Helper helper;
    SpriteRenderer sr;
    LayerMask AttackLayerMask;

    void Start()
    {
        helper = gameObject.AddComponent<Helper>();
        sr = GetComponent<SpriteRenderer>();
        AttackLayerMask = LayerMask.GetMask("Attack");

    }

    void Update()
    {
        //Edge Check
        if (helper.GroundCheck(-0.03f, -0.1f))
        {
            speed = speed * -1;
        }
        if (helper.GroundCheck(0.03f, -0.1f))
        {
            speed = speed * -1;
        }
        //Wall Check
        if (helper.GroundCheck(0.06f, 0.05f))
        {
            speed = speed * -1;
        }
        if (helper.GroundCheck(-0.06f, 0.05f))
        {
            speed = speed * -1;
        }





        transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        if (speed > 0f)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
        if (EnemyHealth <= 0f)
        {
        gameObject.SetActive(false);
            AudioManager.instance.Play("EnemyDeath");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            float collisionspeed = speed * -1.5f;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * collisionspeed, ForceMode2D.Impulse);
        }
        if (collision != null && collision.gameObject.layer == 6)
        {
            EnemyHealth--;
            print(EnemyHealth);
            AudioManager.instance.Play("EnemyHit");
        }
        if (collision != null && collision.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
}
