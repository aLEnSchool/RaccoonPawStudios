using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffRoomController : MonoBehaviour
{
    private SpriteRenderer sprite;

    public GameObject darkness;

    public GameObject doorToAlley;
    public GameObject lockerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        darkness.SetActive(true);

        // hide interactions that are in the darkness
        doorToAlley.SetActive(false);
        lockerInteraction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Lit Lantern")
        {

            //Show Puzzle
            doorToAlley.SetActive(true);
            lockerInteraction.SetActive(true);

            darkness.SetActive(false);

            //sprite.color = Color.blue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Lit Lantern")
        {

            //Show Puzzle
            doorToAlley.SetActive(true);
            lockerInteraction.SetActive(true);

            darkness.SetActive(false);

            //sprite.color = Color.blue;
        }
    }
}
