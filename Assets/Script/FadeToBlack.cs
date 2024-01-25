using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{

    //[SerializeField] private Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(fadeOut());
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(fadeIn());
        }
    }

    // fade out: screen turns to black
    public IEnumerator fadeOut()
    {
        Color screenColor = gameObject.GetComponent<Image>().color;
        float fadeAmount;

        while(gameObject.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = screenColor.a + (2 * Time.deltaTime);

            screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
            gameObject.GetComponent<Image>().color = screenColor;
            yield return null;
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
            yield return null;
        }

    }
}

// https://turbofuture.com/graphic-design-video/How-to-Fade-to-Black-in-Unity
