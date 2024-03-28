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
