using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCaseController : MonoBehaviour
{
    private bool inRange;
    public GameObject playertemp;

    public GameObject popUp;

    public GameObject notepadNotes;

    private void Awake()
    {
        playertemp = GameObject.FindGameObjectWithTag("DontDestroy");
        notepadNotes = GameObject.FindGameObjectWithTag("Notepad");
    }

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUp.SetActive(true);

                //PlayerDataController.instance.nextScene();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
            popUp.SetActive(false);
        }
    }

    public void toNextScene()
    {
        PlayerDataController.instance.notesTaken = notepadNotes.GetComponent<TMP_InputField>().text;
        Debug.Log(notepadNotes.GetComponent<TMP_InputField>().text);
        Debug.Log("Go to next Scene");
        SceneManager.LoadScene("CaseFileScreen");
    }

    public void cancel()
    {
        popUp.SetActive(false);
    }

}
