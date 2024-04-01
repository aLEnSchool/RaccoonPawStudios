using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookThroughController : MonoBehaviour
{
    public bool inRange;

    public GameObject LookThrough;

    public bool itemfound = false;

    //public Button doorknob;

    // Start is called before the first frame update
    void Start()
    {
        LookThrough.SetActive(false);
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.F)) { 
                LookThrough.SetActive(true);
            }
        }
        else
        {
            LookThrough.SetActive(false);
        }
        if (itemfound)
        {
            Debug.Log("STOP");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered");
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Exit");
            inRange = false;
        }
    }

    public void itemFound()
    {
        itemfound = true;
    }
}