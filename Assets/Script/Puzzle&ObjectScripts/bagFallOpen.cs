using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagFallOpen : MonoBehaviour
{
    public bool inRange;
    private Vector3 position;
    public GameObject LookThrough;
    public bool itemfound = false;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        LookThrough.SetActive(false);
        position = new Vector3(transform.localPosition.x + 1.5f, transform.localPosition.y - 3f, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDataController.instance.clayeBagFall) //if claye bag is triggered to fall
        {
            if (!DialogueManager.GetInstance().dialogueIsPlaying) //if dialogue is done
            {
                transform.localPosition = position; //drop bag 
            }

            if (inRange) //if in range
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    LookThrough.SetActive(true);
                    PlayerDataController.instance.clayeBagOpen = true;
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
