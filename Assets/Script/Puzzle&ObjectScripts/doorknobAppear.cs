using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorknobAppear : MonoBehaviour
{
    private SpriteRenderer sprite;

    public GameObject knob;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        knob.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDataController.instance.clayeBagOpen)
        {
            knob.SetActive(true);
        }
        if (PlayerDataController.instance.knobInTheDoor)
        {
            knob.SetActive(false);
        }
    }
}
