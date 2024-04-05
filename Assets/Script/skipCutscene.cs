using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipCutscene : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Go to next Scene");
            playertemp.GetComponent<PlayerDataController>().nextScene();
        }    
    }

}
