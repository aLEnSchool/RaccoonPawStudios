using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset itemPickedUp;
    [SerializeField] private TextAsset itemNotPickedUp;
    
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                /*if (PlayerDataController.instance.itemTest)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(itemPickedUp);
                }
                else
                {
                    DialogueManager.GetInstance().EnterDialogueMode(itemNotPickedUp);
                }*/
            }          
        }
        
        /*if(!playerInRange && DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().ExitDialogueMode();
        }*/

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
