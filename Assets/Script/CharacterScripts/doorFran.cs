using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorFran : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;
    [SerializeField] private TextAsset dialogFile2;
    [SerializeField] private TextAsset dialogFile3;
    [SerializeField] private TextAsset dialogFile4;
    [SerializeField] private TextAsset dialogFile5;
    [SerializeField] private TextAsset dialogLighter;

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
                if (PlayerDataController.instance.frannieLighterFound)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogLighter);

                }
                if (PlayerDataController.instance.frannieInvest)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile3);
                }

                if (PlayerDataController.instance.sadieBusy)
                {
                    //DialogueManager.GetInstance().EnterDialogueMode(dialogFile2);
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile4);
                    Debug.Log("please don't play");
                    PlayerDataController.instance.wentIntoKitchen = true;

                }
                if (PlayerDataController.instance.wentIntoKitchen)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile5);

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
