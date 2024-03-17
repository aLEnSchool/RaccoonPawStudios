using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class TestObject : MonoBehaviour
{
    private bool inRange;

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
                pickUp();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player ENter");
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player Exit");
            inRange = false;
        }
    }

    private void pickUp()
    {
        //Debug.Log("Item Picked Up"); 
        PlayerDataController.instance.itemTest = true;

        // Accessing DialogueManager instance
        //DialogueManager dialogueManager = DialogueManager.GetInstance();

        // Checking if currentStory is not null
        if (DialogueManager.GetInstance().currentStory != null)
        {
            // Modifying the variable "itemPickedUp" to false        
            //DialogueManager.GetInstance().currentStory.EvaluateFunction("changeItemPickedUp", true);
            //DialogueManager.GetInstance().currentStory.variablesState["itemPickedUp"] = true;
            //DialogueManager.GetInstance().changeItemPickedUp();
           // DialogueManager.GetInstance().dialogueVariables.VariableChanged("itemPickedUp", Ink.Runtime.BoolValue.Equals(true));

            Debug.Log("Item Picked Up");
        }
        else
        {
            Debug.LogWarning("Current story is null. Make sure it's set properly.");
        }
    }


}
