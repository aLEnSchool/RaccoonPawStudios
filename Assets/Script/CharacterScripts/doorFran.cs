using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorFran : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;
    [SerializeField] private TextAsset dialogFile2;
    [SerializeField] private TextAsset dialogFile3;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                DialogueManager.GetInstance().EnterDialogueMode(dialogFile1);

                if (PlayerDataController.instance.hallSadie)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile2); 
                }

                if (PlayerDataController.instance.frannieInvest)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile3);
                }

                if (PlayerDataController.instance.sadieBusy)
                {
                    //DialogueManager.GetInstance().EnterDialogueMode(dialogFile2);
                    Debug.Log("please don't play");

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
