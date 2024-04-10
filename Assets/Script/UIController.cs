using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [Header("Audio Icons")]
    [SerializeField] public GameObject playIcon;
    [SerializeField] public GameObject dontPlayIcon;

    [Header("Menu Icons")]
    [SerializeField] public GameObject menuIcon;
    [SerializeField] private bool menuShow = false;

    public GameObject playertemp;
    private void Awake()
    {
        instance = this;
        playertemp = GameObject.FindGameObjectWithTag("DontDestroy");
    }

    // Start is called before the first frame update
    void Start()
    {
        playIcon.SetActive(true);
        dontPlayIcon.SetActive(false);
        menuIcon.SetActive(false);
    }

    public void toggleMenu()
    {
        if (menuShow)
        {
            menuIcon.SetActive(false);
            menuShow = false;
        }
        else
        {
            menuIcon.SetActive(true);
            menuShow = true;
        }
    }

    public void goMainMenu()
    {
        playertemp.GetComponent<PlayerDataController>().mainMenu();
    }

    public void QuitGame()
    {
        playertemp.GetComponent<PlayerDataController>().quitGame();
    }
}
