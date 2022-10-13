using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D targetJoint;
    private BoxCollider2D boxCollider;
    void Start()
    {
        targetJoint = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Falling());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Falling()
    {
        yield return new WaitForSeconds(fallingTime);
        targetJoint.enabled = false;
        boxCollider.isTrigger = true;
    }
}
