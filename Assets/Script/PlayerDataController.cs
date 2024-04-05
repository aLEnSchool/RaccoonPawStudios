using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataController : MonoBehaviour
{
    public static PlayerDataController instance;

    public static int sceneIndex;
   
    //CaseFile1 Events
    public bool talkedToClaye = false;
    public bool talkedToSaide = false;
    public bool hallSadie = false;

    //lighter text
    public bool clayLighter = false;
    public bool frannieLighter = false;
    public bool johnLighter = false;
    public bool rosaLighter = false;
    public bool rosaLAppear = false;

    //after finding crime scene
    public bool clayInvest = false;
    public bool frannieInvest = false;
    public bool johnInvest = false;
    public bool rosaInvest = false;
    public bool sadieInvest = false;

    //tom in the kitchen
    public bool tomKitchen = false;

    //sadie busy with claye
    public bool sadieBusy = false;
    public bool wentIntoKitchen = false;

    //rosa go into bag
    public bool rosaCanOpen = false;
    public bool rosaBagOpened = false;

    //drugs found
    public bool drugsFound = false;

    //claye's food brought over
    public bool clayeFoodB = false;
    public bool clayeBagFall = false;
    public bool clayeBagOpen = false;
    public bool knobInTheDoor = false;

    

    public int characterSelected;
    public int weaponSelected;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance.gameObject);
        sceneIndex = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void nextScene()
    {
        Debug.Log("Loading next scene");
        sceneIndex++;
        if (sceneIndex == 1)
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (sceneIndex == 2)
        {
            SceneManager.LoadScene("Transition");
        }
        if (sceneIndex == 3)
        {
            SceneManager.LoadScene("L01_scene");
        }
        if (sceneIndex == 4)
        {
            SceneManager.LoadScene("CaseFileScreen");
        }
    }
}
