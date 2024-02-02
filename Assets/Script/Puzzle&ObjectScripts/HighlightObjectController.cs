using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObjectController : MonoBehaviour
{
    public GameObject highlight_border;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        highlight_border.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        highlight_border.SetActive(inRange);
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
