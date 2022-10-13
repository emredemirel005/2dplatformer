using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isJumping;
    public bool doubleJump;

    public AudioSource audioSource;

    private float horzontalMove;
    [SerializeField]
    private bool isWalking;
    private Rigidbody2D rb;
    private Animator anim;

    MenuInputCheck MenuInputCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        MenuInputCheck = GetComponent<MenuInputCheck>();
        MenuInputCheck.enabled = false;

    }

    void Update()
    {
        Move();
        Jump();

        if (rb.velocity.y != Mathf.Epsilon)
            anim.SetFloat("yvelocity",rb.velocity.y);
        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                audioSource.Play();
                anim.SetBool("jump", !isJumping);
            }
            else
            {
                if (doubleJump)
                {
                    rb.AddForce(new Vector2(0f, jumpForce * .9f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }

        
    }

    private void Move()
    {
        horzontalMove = Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(horzontalMove, 0f, 0f);
        //transform.position += movement * Time.deltaTime * speed;
        rb.velocity = new Vector2(horzontalMove * speed,rb.velocity.y);

        if (horzontalMove > 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (horzontalMove < 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
            anim.SetBool("walk", false);


    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6 
             || other.gameObject.layer == 9
             || other.gameObject.layer == 10)
        {
            isJumping = false;
            anim.SetBool("jump", isJumping);
        }

        

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == 9
             || other.gameObject.layer == 10)
        {
            MenuInputCheck.enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 6
             || other.gameObject.layer == 9
             || other.gameObject.layer == 10)
        {
            isJumping = true;
        }

        if (other.gameObject.layer == 9
             || other.gameObject.layer == 10)
        {
            MenuInputCheck.enabled = false;
        }
    }
}
