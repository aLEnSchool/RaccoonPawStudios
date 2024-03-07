using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RosaController : MonoBehaviour
{
    //Voice Lines Variables
    public string[] voiceLines;
    private int voiceLineIndex;

    //Dialog Box Variables
    [Header("Dialog Variables", order = 1)]
    public GameObject dialogBox;
    public TMP_Text dialogOutput;
    public GameObject dialogButton;

    [Header("Typewriter Variables", order = 2)]
    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
    int i = 0;

    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;

        dialogBox.SetActive(false);

        EndCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Debug.Log(voiceLines[voiceLineIndex]);
                dialogBox.SetActive(true);

                //Voice Line Output
                dialogOutput.text = voiceLines[voiceLineIndex];
                EndCheck();
            }
        }
    }

    /*-- Trigger Events --*/
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
            dialogBox.SetActive(false);
        }
    }

    //When button clicked, next dialog will show
    public void ContinueDialog()
    {
        voiceLineIndex++;
        
        if (voiceLineIndex == 1)
        {
            dialogButton.SetActive(false);
        }

        //Voice Line Output
        EndCheck();
        dialogOutput.text = voiceLines[voiceLineIndex];
    }
    public void EndCheck()
    {
        if (i <= voiceLineIndex)
        {
            dialogOutput.text = voiceLines[voiceLineIndex];
            StartCoroutine(TextVisible());
        }
    }

    //Typewriter effect for dialog shown
    private IEnumerator TextVisible()
    {
        //dialogOutput = voiceLines[voiceLineIndex];
        dialogOutput.ForceMeshUpdate();
        int totalVisibleCharacters = dialogOutput.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            dialogOutput.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                i += 1;
                Invoke("EndCheck", timeBtwnWords);
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBtwnChars);
        }
    }
}
