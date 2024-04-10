using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterAppear : MonoBehaviour
{
    private SpriteRenderer sprite;

    public GameObject lighter;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        lighter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDataController.instance.rosaLAppear)
        {
            if (!DialogueManager.GetInstance().dialogueIsPlaying)
            {
                lighter.SetActive(true);
                PlayerDataController.instance.rosaLighterFound = true;
            }       
        }
    }
}
