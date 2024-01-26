using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{

    public bool isSwitchingRooms;

    // Start is called before the first frame update
    void Start()
    {
        isSwitchingRooms = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // fade out: screen turns to black
    public IEnumerator fadeOut()
    {
        isSwitchingRooms = true; // started to fade out

        Color screenColor = gameObject.GetComponent<Image>().color;
        float fadeAmount;

        while(gameObject.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = screenColor.a + (2 * Time.deltaTime);

            screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
            gameObject.GetComponent<Image>().color = screenColor;
            //yield return null;
            yield return new WaitForSeconds(0.001f);
        }
        Debug.Log("fade out pls");

    }

    // fade in: remove black screen
    public IEnumerator fadeIn()
    {
        Color screenColor = gameObject.GetComponent<Image>().color;
        float fadeAmount;

        while (gameObject.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = screenColor.a - (2 * Time.deltaTime);

            screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
            gameObject.GetComponent<Image>().color = screenColor;
            //yield return null;
            yield return new WaitForSeconds(0.001f);
        }

        isSwitchingRooms = false; // finished fading back in
    }
}

// https://turbofuture.com/graphic-design-video/How-to-Fade-to-Black-in-Unity
