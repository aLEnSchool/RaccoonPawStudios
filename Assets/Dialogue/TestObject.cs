using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

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
                itemEvent();
                pickUp();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
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
        Debug.Log("Item PickedUp");
    }

    private void itemEvent()
    {
        PlayerDataController.instance.itemTest = true;

        string variableName = "your_boolean_variable"; // Change this to the name of your boolean variable
        bool newValue = true; // Change this to the new value you want to assign to the variable

        // Get the current value of the variable
        Ink.Runtime.Object variableValue = DialogueManager.GetInstance().GetVariableState(variableName);

        // Ensure the variable exists and is of type Bool
        if (variableValue != null && variableValue is Ink.Runtime.Bool)
        {
            // Modify the variable value
            ((Ink.Runtime.Bool)variableValue).value = newValue;

            // Update the variable in the DialogueVariables instance
            dialogueManager.dialogueVariables.variables[variableName] = variableValue;

            // Save the updated variables (optional)
            dialogueManager.dialogueVariables.SaveVariables();
        }
        else
        {
            Debug.LogError("Variable not found or not of type Bool: " + variableName);
        }
    }
}
