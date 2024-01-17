using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffRoomController : MonoBehaviour
{
    private SpriteRenderer sprite;

    public GameObject darkness;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        darkness.SetActive(true);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Lantern With Glue")
        {
            //Show Puzzle
            darkness.SetActive(false);

            //sprite.color = Color.blue;
        }
    }
}
