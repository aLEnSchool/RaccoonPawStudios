using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [Header("Audio Icons")]
    [SerializeField] public GameObject playIcon;
    [SerializeField] public GameObject dontPlayIcon;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playIcon.SetActive(true);
        dontPlayIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
