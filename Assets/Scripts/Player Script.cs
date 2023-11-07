using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //variables
    public float speed = 1f;
    float jumpAmount = 2f;
    bool onground = false;
    bool Movement = true;
    Vector3 offsetL = new Vector3(-0.1f, -0.03f, 0);
    Vector3 offsetR = new Vector3(0.1f, -0.03f, 0);
    Vector3 Checkpoint = new Vector3(-1.127f, -1.826f, 0);
    //other stuff for things to work
    Rigidbody2D rb;
    float dirX;
    Animator anim;
    SpriteRenderer sr;
    Helper helper;
    LayerMask enemyLayerMask;
    public GameObject BulletLeft;
    public GameObject BulletRight;
    public Image healthBar;
    public Image haveBoots;
    public Text Coins;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<Helper>();
        enemyLayerMask = LayerMask.GetMask("Enemy");
        healthBar.fillAmount = VariableStore.Health;
        Coins.text = "coins: " + VariableStore.CoinCount;
    }


    void Update()
    {

        //movement();
        newmovement();
    }

    void newmovement()
    {
        //reset all anims
        anim.SetBool("Walk", false);
        anim.SetBool("falling", false);
        anim.SetBool("Shooting", false);

        rb.velocity = new Vector2(0, rb.velocity.y);

        if ((Input.GetKey("left") && Movement == true || Input.GetKey("a")) == true)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            anim.SetBool("Walk", true);
            sr.flipX = true;
        }
        else if ((Input.GetKey("right") || Input.GetKey("d")) == true)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetBool("Walk", true);
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
        if (VariableStore.Health <= 0.1)
        {
            gameObject.transform.position = VariableStore.Checkpoint;
            VariableStore.Health = 1f;
            AudioManager.instance.Play("Fail");
            healthBar.fillAmount = 1;
        }

        //Shooting
        if (Input.GetKeyDown(KeyCode.LeftShift) && onground != false)
        {
            anim.SetBool("Shooting", true);
            AudioManager.instance.Play("Shoot");
            if (sr.flipX == true)
            {
                Instantiate(BulletLeft, transform.position + offsetL, Quaternion.identity);
            }
            if (sr.flipX == false)
            {
                Instantiate(BulletRight, transform.position + offsetR, Quaternion.identity);
            }
        }

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
        if (VariableStore.Health <= 0.1)
        {
            gameObject.transform.position = VariableStore.Checkpoint;
            VariableStore.Health = 1f;
            AudioManager.instance.Play("Fail");
            healthBar.fillAmount = 1;
        }

        //Shooting
        if (Input.GetKeyDown(KeyCode.LeftShift) && onground != false)
        {
            anim.SetBool("Shooting", true);
            AudioManager.instance.Play("Shoot");
            if (sr.flipX == true)
            {
                Instantiate(BulletLeft, transform.position + offsetL, Quaternion.identity);
            }
            if (sr.flipX == false)
            {
                Instantiate(BulletRight, transform.position + offsetR, Quaternion.identity);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Respawn")
        {
            gameObject.transform.position = VariableStore.Checkpoint;
            VariableStore.Health = VariableStore.Health - 0.2f;
            AudioManager.instance.Play("Fail");
            healthBar.fillAmount = VariableStore.Health;
        }
        
        if (collision != null && collision.gameObject.tag == "Enemy")
        {
            VariableStore.Health = VariableStore.Health - 0.2f;
            AudioManager.instance.Play("Hurt");
            healthBar.fillAmount = VariableStore.Health;
        }
        
        if (collision != null && collision.gameObject.tag == "Heal")
        {
            VariableStore.Health = VariableStore.Health + 0.2f;
            AudioManager.instance.Play("Hurt");
            healthBar.fillAmount = VariableStore.Health;
            print(VariableStore.Health);
        }
        if (collision != null && collision.gameObject.tag == "Checkpoint")
        {
            VariableStore.Checkpoint = (collision.transform.position);
            print("hit");
        }



        //Reset Power
        if (collision != null && collision.gameObject.layer == 8)
        {
            jumpAmount = 2;
            print("Reset");
            haveBoots.fillAmount = 0;
        }
        //Jump Power
        if (collision != null && collision.gameObject.tag == "Power" && collision.gameObject.name == "BootsPower")
        {
            jumpAmount = 3;
            haveBoots.fillAmount = 1;
            AudioManager.instance.Play("PowerUp");
        }

        //Coin Collection
        if (collision != null && collision.gameObject.layer == 10)
        {
            VariableStore.CoinCount++;
            string coin = VariableStore.CoinCount.ToString();
            Coins.text = "coins: " + VariableStore.CoinCount;
            AudioManager.instance.Play("Coin");

        }




    }

}
