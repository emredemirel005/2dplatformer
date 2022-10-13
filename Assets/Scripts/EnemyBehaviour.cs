using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsFacingRight())
            rb.velocity = new Vector2(moveSpeed, 0f);
        else
            rb.velocity = new Vector2(-moveSpeed, 0f);
    }

    private bool IsFacingRight() { return transform.localScale.x > Mathf.Epsilon; }

    private void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2(-Mathf.Sign(rb.velocity.x), transform.localScale.y);
    }
}
