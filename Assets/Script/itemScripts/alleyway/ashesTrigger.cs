using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ashesTrigger : MonoBehaviour
{
    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;

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
                PlayerDataController.instance.clayInvest = true;
                PlayerDataController.instance.frannieInvest = true;
                PlayerDataController.instance.johnInvest = true;
                PlayerDataController.instance.rosaInvest = true;
                PlayerDataController.instance.sadieInvest = true;
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
