using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class transitionScript : MonoBehaviour
{
    public string[] voiceLines;
    private int voiceLineIndex = 0;

    [Header("Texts", order = 0)]
    [SerializeField] TextMeshProUGUI caseText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI continueText;
    private TextMeshProUGUI[] allTexts;


    [Header("Typewriter Variables", order = 1)]
    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        allTexts = new TextMeshProUGUI[3]{ caseText, descriptionText, continueText};

        descriptionText.gameObject.SetActive(false);
        continueText.gameObject.SetActive(false);

        goThroughTexts();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            voiceLineIndex++;
            EndCheck(allTexts[voiceLineIndex]);
        }


    }

    //Function to go through texts type writer affect
    private void goThroughTexts()
    {
        EndCheck(caseText);
        //voiceLineIndex++;
        //EndCheck(descriptionText);
        //voiceLineIndex++;
       // EndCheck(continueText);
    }


    //Restart Couroutine of typewriter, only for 1 variable
    public void EndCheck(TextMeshProUGUI nextdialog)
    {
        if (i <= voiceLineIndex)
        {
            nextdialog.text = voiceLines[voiceLineIndex];
            StartCoroutine(TextVisible(nextdialog));
        }
    }

    //Typewriter effect for dialog shown
    private IEnumerator TextVisible(TextMeshProUGUI nextdialog)
    {
        //dialogOutput = voiceLines[voiceLineIndex];
        nextdialog.gameObject.SetActive(true);
        nextdialog.ForceMeshUpdate();
        int totalVisibleCharacters = nextdialog.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            nextdialog.maxVisibleCharacters = visibleCount;

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
