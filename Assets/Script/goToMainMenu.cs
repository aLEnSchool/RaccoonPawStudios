using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToMainMenu : MonoBehaviour
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
    public void goMainMenu()
    {
        playertemp.GetComponent<PlayerDataController>().mainMenu();
    }
}
