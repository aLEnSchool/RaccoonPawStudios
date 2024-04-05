using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainMenu : MonoBehaviour
{
    public GameObject playertemp;
    private void Awake()
    {
        playertemp = GameObject.FindGameObjectWithTag("DontDestroy");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToMain()
    {
        PlayerDataController.instance.mainMenu();
    }
}
