using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationController : MonoBehaviour
{
    private SpriteRenderer sprite;

    public SpriteRenderer popupSprite;

    private bool inRange;
    private bool interact;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        popupSprite.enabled = false;

        inRange = false; interact = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            sprite.color = Color.red;
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
                setVisible();
            }
            else
            {
                interact = false;
                setInvisible();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") {
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
        }
    }
    protected void setVisible()
    {
        Debug.Log("Items are Visible");
        popupSprite.enabled = true;
    }
    protected void setInvisible()
    {
        Debug.Log("Items are Invisible");
        popupSprite.enabled = false;
    }
}
