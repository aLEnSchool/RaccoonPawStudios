using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagFallOpen : MonoBehaviour
{
    public bool inRange;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        position = new Vector3(transform.localPosition.x + 1.5f, transform.localPosition.y - 3f, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDataController.instance.clayeBagFall)
        {
            if (!DialogueManager.GetInstance().dialogueIsPlaying)
            {
                transform.localPosition = position;
            }
            
        }
    }
}
