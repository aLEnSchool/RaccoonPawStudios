using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffRoomController : MonoBehaviour
{
    private SpriteRenderer sprite;

    public GameObject lockerPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        lockerPuzzle.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Lantern With Glue")
        {
            Debug.Log("Show Insides of Room");

            //Show Puzzle
            lockerPuzzle.SetActive(true);

            sprite.color = new Color(161, 161, 161);
        }
    }
}
