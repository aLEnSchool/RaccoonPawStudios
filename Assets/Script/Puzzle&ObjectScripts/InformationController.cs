using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationController : MonoBehaviour
{
    private SpriteRenderer sprite;

    public SpriteRenderer popupSprite;

    private SpriteRenderer[] childrenPopUps;

    private bool inRange;
    private bool interact;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        getChildrenSprites();
        printChildrenSprites();

        setInvisible();
        
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

    /*--  Trigger Events --*/
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
            setInvisible();
        }
    }


    /*--  Popup Functions  --*/
    //Sets All popUp sprites visible
    protected void setVisible()
    {
        Debug.Log("Items are Visible");
        popupSprite.enabled = true;
        for (int i = 0; i < childrenPopUps.Length; i++)
        {
            if (i == 0)
            {
                i = i;
            }
            else
            {
                childrenPopUps[i].enabled = true;
            }
        }
    }
    //Sets All popUp sprites invisible
    protected void setInvisible()
    {
        Debug.Log("Items are Invisible");
        popupSprite.enabled = false;
        for (int i = 0; i < childrenPopUps.Length; i++)
        {
            if (i == 0)
            {
                i = i;
            }
            else
            {
                childrenPopUps[i].enabled = false;
            }
        }
    }

    //Gets all children Sprites
    protected void getChildrenSprites()
    {
        childrenPopUps = sprite.GetComponentsInChildren<SpriteRenderer>(true);
    }
    //Print all children Sprites collected
    protected void printChildrenSprites()
    {
        for (int i = 0;i < childrenPopUps.Length - 1; i++)
        {
            Debug.Log(childrenPopUps[i]);
        }
    }
}
