using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isJumping;
    public bool doubleJump;
    public AudioSource jumpSource;
    public AudioSource playerDeathSource;
    public AudioSource collectableSource;

    private float horzontalMove;
    [SerializeField]
    private bool isWalking;
    private bool isBlowing;
    private Rigidbody2D rb;
    private Animator anim;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        if (rb.velocity.y != Mathf.Epsilon)
            anim.SetFloat("yvelocity", rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBlowing)
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                jumpSource.Play();
                anim.SetBool("jump", !isJumping);
            }
            else
            {
                if (doubleJump)
                {
                    rb.AddForce(new Vector2(0f, jumpForce * 1.1f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    private void Move()
    {
        horzontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horzontalMove * speed, rb.velocity.y);

        if (horzontalMove > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (horzontalMove < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
            anim.SetBool("walk", false);


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 8)
        {
            isBlowing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            isBlowing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", isJumping);
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            playerDeathSource.Play();
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
}
