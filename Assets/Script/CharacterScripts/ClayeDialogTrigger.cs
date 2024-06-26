using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayeDialogueTrigger : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;
    [SerializeField] private TextAsset dialogFile2;
    [SerializeField] private TextAsset dialogFile3;
    [SerializeField] private TextAsset dialogFile4;
    [SerializeField] private TextAsset dialogFile5;
    [SerializeField] private TextAsset dialogLighter;
    [SerializeField] private TextAsset dialogLanternOn;
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
                

                if (PlayerDataController.instance.hallSadie)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile2);
                    
                }
                if (PlayerDataController.instance.clayLighterFound)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogLighter);
                    
                }
                if (PlayerDataController.instance.lanternOn)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogLanternOn);

                }
                if (PlayerDataController.instance.clayInvest)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile3);
                    PlayerDataController.instance.sadieBusy = true;

                }
                if (PlayerDataController.instance.clayeFoodB)
                {
                    PlayerDataController.instance.clayeBagFall = true;
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile4);

                }
                if (PlayerDataController.instance.clayeBagOpen)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile5);

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
