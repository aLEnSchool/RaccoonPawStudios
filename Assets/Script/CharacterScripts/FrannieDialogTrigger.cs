using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrannieDialogueTrigger : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;
    [SerializeField] private TextAsset dialogFile2;
    [SerializeField] private TextAsset dialogEnd;

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
                DialogueManager.GetInstance().EnterDialogueMode(dialogFile1);

                if (PlayerDataController.instance.drugsFound)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile2);
                    PlayerDataController.instance.franDrugTalk = true;

                }
                if (PlayerDataController.instance.drugs == true && PlayerDataController.instance.knobInTheDoor == true && PlayerDataController.instance.sadieDrugTalk == true && PlayerDataController.instance.franDrugTalk)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogEnd);

                }
            }
        }

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
