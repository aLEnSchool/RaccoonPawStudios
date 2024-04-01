using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterKitchen : MonoBehaviour
{
    public bool tomEnter;
    private bool inRange;

    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;

    // Start is called before the first frame update
    void Start()
    {
        tomEnter = false;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && !DialogueManager.GetInstance().dialogueIsPlaying) // if player is in range of the door
        {
            if (!tomEnter)
            {
                DialogueManager.GetInstance().EnterDialogueMode(dialogFile1);
                // display "cannot enter" message
                Debug.Log("we shouting at the players");

                tomEnter = true;
                PlayerDataController.instance.tomKitchen = true;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
