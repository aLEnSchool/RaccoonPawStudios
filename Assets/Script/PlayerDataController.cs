using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataController : MonoBehaviour
{
    [Header("CaseFile1 Variables", order = 0)]
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
    static bool glassesDiscovered = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
