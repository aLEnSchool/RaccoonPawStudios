using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class ToCaseController : MonoBehaviour
{
    private bool inRange;
    public GameObject playertemp;

    public GameObject popUp;

    private void Awake()
    {
        playertemp = GameObject.FindGameObjectWithTag("DontDestroy");
    }

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                popUp.SetActive(true);

                //PlayerDataController.instance.nextScene();
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
            popUp.SetActive(false);
        }
    }

    public void toNextScene()
    {
        Debug.Log("Go to next Scene");
        playertemp.GetComponent<PlayerDataController>().nextScene();
    }

}
