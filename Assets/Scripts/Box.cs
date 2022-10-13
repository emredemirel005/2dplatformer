using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    public GameObject collectedEffect;

    public int hitIndex;
    public int boxBreakIndex = 3;
    void Start()
    {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hitIndex >= boxBreakIndex)
        {
            anim.Play("box_break");
            GameObject collected = Instantiate(collectedEffect, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject, .25f);
            Destroy(collected, .5f);
            hitIndex = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("hit");
            hitIndex++;
        }
    }
}
