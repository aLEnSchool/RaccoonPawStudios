using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayeFoodLock : MonoBehaviour
{
    private SpriteRenderer sprite; // For Testing

    public bool objectPickedUp;
    private bool inRange;
    private bool doorRange;
    private Vector3 positionOnTable;
    private bool click;
    //private Vector3 positionOnTable;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        objectPickedUp = false;
        inRange = false;
        doorRange = false;
        positionOnTable = new Vector2(-6.04f, 24.55f);
        click = false;
        //positionOnTable = new Vector3(16.55f, -0.31f, -0.04410756f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inRange && !objectPickedUp)
            {
                //if (!objectPickedUp)
                //{
                pickUp();
                //}
            }
            else if (objectPickedUp && !doorRange && !PlayerController.instance.doorRange)
            {
                dropItem();
            }
        }

        if (click)
        {
            clickItem();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
        if (collision.gameObject.tag == "Door")
        {
            doorRange = true;
        }

        if (collision.gameObject.tag == "ClayeFood")
        {
            //inRange = true;
            //objectPickedUp = false;
            //transform.localPosition = positionOnTable;
            click = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
        if (collision.gameObject.tag == "Door")
        {
            doorRange = false;
        }
    }

    private void pickUp()
    {
        Debug.Log("Object Picked Up");
        objectPickedUp = true;
        inRange = true;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.SetParent(player.transform);
        transform.position = new Vector2(player.transform.position.x + 1.5f, player.transform.position.y);

        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void dropItem()
    {
        Debug.Log("Dropping Item");
        objectPickedUp = false;
        inRange = false;

        GameObject restingPlace = GameObject.FindGameObjectWithTag("Rest");
        transform.SetParent(restingPlace.transform);

        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void clickItem()
    {
        Debug.Log("Click Item");
        objectPickedUp = false;
        inRange = false;

        GameObject clayeClick = GameObject.FindGameObjectWithTag("ClayeFood");
        transform.SetParent(clayeClick.transform);
        transform.position = new Vector2(clayeClick.transform.position.x - 2.5f, clayeClick.transform.position.y - 0.3f);


        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
