using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //variables
    float Health = 5f;
    float speed = 1f;
    float jumpAmount = 2f;
    bool onground = false;
    bool Movement = true;
    //other stuff for things to work
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Helper helper;
    LayerMask enemyLayerMask;
    public GameObject BulletLeft;
    public GameObject BulletRight;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<Helper>();
        enemyLayerMask = LayerMask.GetMask("Enemy");
    }


    void Update()
    {
        speed = 1f;
        movement();

    }

    void movement()
    {
        //reset all anims
        anim.SetBool("Walk", false);
        anim.SetBool("falling", false);
        anim.SetBool("Shooting", false);

        //Left
        if ((Input.GetKey("left") && Movement == true || Input.GetKey("a")) == true)
        {
            anim.SetBool("Walk", true);
            sr.flipX = true;
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
        }
        //Right
        else if ((Input.GetKey("right") || Input.GetKey("d")) == true)
        {
            anim.SetBool("Walk", true);
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            sr.flipX = false;
        }
        //Jump
        onground = false;
        if ((helper.GroundCheck(-0.03f, -0.085f) != false) || (helper.GroundCheck(0, -0.085f) != false) || (helper.GroundCheck(0.03f, -0.085f) != false)) //Get Spited Bitch - from AM :3
        {
            onground = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && onground == true)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            AudioManager.instance.Play("Jump");
        }

        //fall check
        if (onground == false)
        {
            anim.SetBool("falling", true);

        }

        //Health
        if (Health <= 0)
        {
            gameObject.transform.position = new Vector3(-1.127f, -1.826f, 0);
            Health = 5;
            AudioManager.instance.Play("Fail");
        }

        //Shooting
        if (Input.GetKeyDown(KeyCode.LeftShift) && onground != false)
        {
            anim.SetBool("Shooting", true);
            AudioManager.instance.Play("Shoot");
            if (sr.flipX == true)
            {
                Instantiate(BulletLeft, transform.position, Quaternion.identity);
            }
            if (sr.flipX == false)
            {
                Instantiate(BulletRight, transform.position, Quaternion.identity);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Respawn")
        {
            gameObject.transform.position = new Vector3(-1.127f, -1.826f, 0);
            Health--;
            AudioManager.instance.Play("Fail");
        }
        if (collision != null && collision.gameObject.tag == "Enemy")
        {
            Health--;
            AudioManager.instance.Play("Hurt");
            anim.SetInteger("Health", 5 );
            
        }
    }

}