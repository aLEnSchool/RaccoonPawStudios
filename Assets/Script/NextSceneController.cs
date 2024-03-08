using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class NextSceneController : MonoBehaviour
{
    private bool inRange;
    public GameObject playertemp;


    private void Awake()
    {
        playertemp = GameObject.FindGameObjectWithTag("DontDestroy");
    }

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Go to next Scene");
                playertemp.GetComponent<PlayerDataController>().nextScene();
                
                //playerDataController.nextScene();
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
        }
    }
}
