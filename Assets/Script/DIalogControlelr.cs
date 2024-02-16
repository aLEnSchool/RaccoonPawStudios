using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [Header("DialogUI")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI displayText;

    private Story currentStory;
    private bool dialogInProgress;

    /*-- Instance --*/
    private static DialogController instance;
    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("Found multiple Dialog Managers in scene");
        }
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        dialogInProgress = false;
        dialogPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogInProgress)
        {
            return;
        }
        if (dialogInProgress )
        {
            ContinueStory();
        }
    }

    public void DisplayDialog(TextAsset inkJSON)
    {
        //currentStory = new Story(inkJSON.text);  
        dialogInProgress = true;
        dialogPanel.SetActive(true);

        ContinueStory();
    }
    public void ContinueStory()
    {
        //if (currentStory.canContinue)
       // {
        //    dialogPanel.text = currentStory.Continue();
       // }
       // else
       // {
       //     DialogClose();
       // }
    }

    public void DialogClose() 
    {
        dialogInProgress = false;
        dialogPanel.SetActive(false);
        displayText.text = "";
    }

    //Get instance of DialogController so other scripts can grab it
    public static DialogController GetInstance()
    {
        return instance;
    }
}
