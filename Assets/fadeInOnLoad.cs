using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeInOnLoad : MonoBehaviour
{
    [SerializeField] FadeToBlack fadeScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeScreen.fadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
