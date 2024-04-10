using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosaDialogueTrigger : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;
    [SerializeField] private TextAsset dialogFile2;
    [SerializeField] private TextAsset dialogFile3;
    [SerializeField] private TextAsset dialogFile4;
    [SerializeField] private TextAsset dialogLighter;
    [SerializeField] private TextAsset dialogLanternOn;

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
                    PlayerDataController.instance.rosaLAppear = true;

                    //PlayerDataController.instance.rosaLighterFound = true;
                    PlayerDataController.instance.johnLighterFound = true;
                    PlayerDataController.instance.sadieLighterFound = true;
                    PlayerDataController.instance.clayLighterFound = true;
                    PlayerDataController.instance.frannieLighterFound = true;

                }
                if (PlayerDataController.instance.rosaLighterFound)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogLighter);

                }
                if (PlayerDataController.instance.lanternOn)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogLanternOn);

                }
                if (PlayerDataController.instance.rosaInvest)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile3);
                    PlayerDataController.instance.rosaCanOpen = true;

                }
                if (PlayerDataController.instance.rosaBagOpened)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile4);

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
