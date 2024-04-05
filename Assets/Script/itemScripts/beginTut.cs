using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginTut : MonoBehaviour
{

    public bool tomStart;
    private bool inRange;

    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;

    // Start is called before the first frame update
    void Start()
    {
        tomStart = false;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && !DialogueManager.GetInstance().dialogueIsPlaying) // if player is in range of the door
        {
            if (!tomStart)
            {
                DialogueManager.GetInstance().EnterDialogueMode(dialogFile1);
                // display "cannot enter" message
                Debug.Log("we shouting at the players");

                tomStart = true;
                //PlayerDataController.instance.hallSadie = true;
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
