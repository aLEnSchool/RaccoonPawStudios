using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataController : MonoBehaviour
{
    public static PlayerDataController instance;

    /*[Header("CaseFile1 Variables", order = 0)]
    static GameObject[] CaseFile1;
    //Characters
    //static string[] character_Casefile1;
    static bool ClayeDiscovered = false;
    static bool SadieDiscovered = false;
    static bool FrannieDiscovered = false;
    static bool RosaDiscovered = false;
    static bool JohnDiscovered = false;
    //character_Casefile1 = [ClayeDiscovered, SadieDiscovered, FrannieDiscovered, RosaDiscovered, JohnDiscovered];

    //Methods
    //static string[] methods_Casefile1;
    static bool lighterDiscovered = false;
    static bool knifeDiscovered = false;
    static bool mercuryDiscovered = false;
    static bool glassesDiscovered = false;*/

    public static int sceneIndex;
    public bool itemTest;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance.gameObject);
        sceneIndex = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        itemTest = false;
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
