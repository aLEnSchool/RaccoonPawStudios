using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //AudioSources
    [Header("Audio Source", order = 1)]
    [SerializeField] private AudioSource music;
    [SerializeField] private bool musicPlay = true;
    

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }

    public void toggleMusic() { 
        if (musicPlay)
        {
            music.Stop();
            musicPlay = false;

            UIController.instance.playIcon.SetActive(false);
            UIController.instance.dontPlayIcon.SetActive(true);
        }
        else
        {
            music.Play();
            musicPlay = true;

            UIController.instance.playIcon.SetActive(true);
            UIController.instance.dontPlayIcon.SetActive(false);
        }
    }

}
