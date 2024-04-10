using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClayesFoodBrought : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;

    private bool inRange;
    private bool foodBrought;

    // Start is called before the first frame update
    void Start()
    {
        foodBrought = false;
        inRange = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && !DialogueManager.GetInstance().dialogueIsPlaying) // if player is in range of the door
        {
            if (!foodBrought)
            {
                DialogueManager.GetInstance().EnterDialogueMode(dialogFile1);
                // display "cannot enter" message
                //Debug.Log("we shouting at the players");

                foodBrought = true;
                
                PlayerDataController.instance.clayeFoodB = true;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "ClayeFood")
        {
            inRange = true;
        }

        
    }
}
