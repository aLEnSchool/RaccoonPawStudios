using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookThroughController : MonoBehaviour
{
    private bool inRange;

    public GameObject LookThrough;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            LookThrough.SetActive(true);
        }
        else
        {
            LookThrough.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inRange = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        inRange = false;
    }
}
