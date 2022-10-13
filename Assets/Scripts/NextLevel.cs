using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(SceneManager.GetSceneByBuildIndex(4).buildIndex != SceneManager.GetActiveScene().buildIndex)
            {
                StartCoroutine(LoadNextScene());
            }

            else
                GameController.instance.GameFinished();
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1.5f);
        GameController.instance.Next_Level();
    }

}
