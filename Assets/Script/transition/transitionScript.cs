using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class transitionScript : MonoBehaviour
{
    public GameObject playertemp;
    public string[] voiceLines;
    private int voiceLineIndex = 0;

    [Header("Texts", order = 0)]
    [SerializeField] TextMeshProUGUI caseText;
    [SerializeField] TextMeshProUGUI descriptionText1;
    [SerializeField] TextMeshProUGUI descriptionText2;
    [SerializeField] TextMeshProUGUI descriptionText3;
    [SerializeField] TextMeshProUGUI descriptionText4;
    [SerializeField] TextMeshProUGUI descriptionText5;
    [SerializeField] TextMeshProUGUI descriptionText6;
    [SerializeField] TextMeshProUGUI descriptionText7;
    [SerializeField] TextMeshProUGUI descriptionText8;
    [SerializeField] TextMeshProUGUI continueText;
    private TextMeshProUGUI[] allTexts;


    [Header("Typewriter Variables", order = 1)]
    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
    int i = 0;
    private void Awake()
    {
        playertemp = GameObject.FindGameObjectWithTag("DontDestroy");
    }

    // Start is called before the first frame update
    void Start()
    {
        allTexts = new TextMeshProUGUI[10]{ caseText, descriptionText1, descriptionText2, descriptionText3, descriptionText4, descriptionText5, descriptionText6, descriptionText7, descriptionText8, continueText };

        descriptionText1.gameObject.SetActive(false);
        descriptionText2.gameObject.SetActive(false);
        descriptionText3.gameObject.SetActive(false);
        descriptionText4.gameObject.SetActive(false);
        descriptionText5.gameObject.SetActive(false);
        descriptionText6.gameObject.SetActive(false);
        descriptionText7.gameObject.SetActive(false);
        descriptionText8.gameObject.SetActive(false);   
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

        if (voiceLineIndex > 9)
        {
            Debug.Log("Go to next Scene");
            playertemp.GetComponent<PlayerDataController>().nextScene();
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
