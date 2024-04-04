using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookThroughController : MonoBehaviour
{
    public bool inRange;

    public GameObject LookThrough;

    public bool itemfound = false;
    public bool interact;

    //public Button doorknob;

    // Start is called before the first frame update
    void Start()
    {
        LookThrough.SetActive(false);
        inRange = false;
        interact = false;
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerDataController.instance.rosaBagOpened = true;

        if (PlayerDataController.instance.rosaCanOpen)
        {
            if (inRange)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!interact)
                    {
                        LookThrough.SetActive(true);
                        PlayerDataController.instance.rosaBagOpened = true;
                    }
                    else
                    {
                        interact = false;
                        LookThrough.SetActive(false);
                    }
                    
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
