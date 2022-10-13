using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputCheck : MonoBehaviour
{
    public GameObject pressE;
    public GameObject pressQ;
    public GameObject interactButton;


    void Start()
    {
        
        pressE.SetActive(false);
        pressQ.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            GameController.instance.Next_Level();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            pressQ.GetComponent<Animator>().SetTrigger("press_q");
            GameController.instance.QuitGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.layer == 9)
        {
            interactButton.SetActive(false);
            pressE.SetActive(true);
        }
        if (other.gameObject.layer == 10)
        {
            interactButton.SetActive(false);
            pressQ.SetActive(true);
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.layer == 9)
        {
            pressE.SetActive(true);
        }
        if (other.gameObject.layer == 10)
        {
            pressQ.SetActive(true);
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 9)
        {
            pressE.SetActive(false);
        }

        if (other.gameObject.layer == 10)
        {
            pressQ.SetActive(false);
        }
    }


}
