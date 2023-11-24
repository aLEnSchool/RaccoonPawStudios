using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationController : MonoBehaviour
{
    private SpriteRenderer sprite;

    private bool inRange;
    private bool interact;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false; interact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
