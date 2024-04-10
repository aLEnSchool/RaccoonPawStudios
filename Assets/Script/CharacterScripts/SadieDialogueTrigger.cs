using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadieDialogueTrigger : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;
    [SerializeField] private TextAsset dialogFile2;
    [SerializeField] private TextAsset dialogFile3;
    [SerializeField] private TextAsset dialogFile4;
    [SerializeField] private TextAsset dialogLighter;
    [SerializeField] private TextAsset dialogLighterFound;
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
                    PlayerDataController.instance.clayLighter = true;
                    PlayerDataController.instance.frannieLighter = true;
                    PlayerDataController.instance.johnLighter = true;
                    PlayerDataController.instance.rosaLighter = true;
                    //PlayerDataController.instance.sadieLighter = true;
                }
                if (PlayerDataController.instance.sadieLighter)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogLighter);

                }
                if (PlayerDataController.instance.sadieLighterFound)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogLighterFound);

                }
                if (PlayerDataController.instance.lanternOn)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogLanternOn);

                }
                if (PlayerDataController.instance.sadieInvest)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile3);
                    PlayerDataController.instance.sadieBusy = true;

                }
                if (PlayerDataController.instance.drugsFound)
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
