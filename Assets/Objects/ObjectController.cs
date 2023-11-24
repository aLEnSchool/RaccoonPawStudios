using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor.UIElements;

public class ObjectController : MonoBehaviour
{
    private bool popUpAppear;

    // Start is called before the first frame update
    void Start()
    {
        popUpAppear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (popUpAppear)
        {
            Debug.Log("HAHAHAHAHA");
        }
        else
        {
            Debug.Log("Booo");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("Player Enters");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Popup Appears");
                if (popUpAppear)
                {
                    popUpAppear = false;
                }
                else
                {
                    popUpAppear = true;
                }
            }
        }
    }
}
