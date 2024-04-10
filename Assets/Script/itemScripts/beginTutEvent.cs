using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginTutEvent : MonoBehaviour
{
    public bool tomBegin;
    private bool inRange;
    public GameObject popUp;


    // Start is called before the first frame update
    void Start()
    {
        tomBegin = false;
        inRange = false;
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange) // if player is in range of the door
        {
            if (!tomBegin)
            {

                popUp.SetActive(true);
                //tomBegin = true;
            }
            else
            {
                popUp.SetActive(false);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
            tomBegin = true;
            popUp.SetActive(false);
        }
    }
}
