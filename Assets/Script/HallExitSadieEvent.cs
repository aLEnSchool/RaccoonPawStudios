using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallExitSadieEvent : MonoBehaviour
{
    public bool sadieExitHall; // true when Sadie should exit the hall
    private bool inRange;

    public Animator sadieAnimator;

    // Start is called before the first frame update
    void Start()
    {
        sadieExitHall = false;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && !DialogueManager.GetInstance().dialogueIsPlaying) // if player is in range of the collider in the alley
        {
            if (!sadieExitHall)
            {
                sadieAnimator.SetBool("ExitHall", true); // play sadie exit hall animation

                sadieExitHall = true;
                //PlayerDataController.instance.sadieBusy = true;
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
