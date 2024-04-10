using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleShowController : MonoBehaviour
{
    public GameObject puzzle;

    private SpriteRenderer sprite;

    private bool inRange;
    public bool interact;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        inRange = false; interact = false;

        puzzle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange)
        {
            sprite.color = Color.yellow;
        }
        else
        {
            sprite.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (!interact)
            {
                interact = true;
                puzzle.SetActive(true);
            }
            else
            {
                interact = false;
                puzzle.SetActive(false);
            }
        }
    }

    /*--  Trigger Events --*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player is in");
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player Out");
            inRange = false;
            interact = false;
            puzzle.SetActive(false);
        }
    }
}
