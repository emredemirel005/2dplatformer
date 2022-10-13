using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    public GameObject collectedEffect;
    public int score = 0;

    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();
            GameObject collected = Instantiate(collectedEffect, transform.position, Quaternion.identity);
            Player.instance.collectableSource.Play();
            Destroy(gameObject, .25f);
            Destroy(collected,.5f);
        }
    }
}
