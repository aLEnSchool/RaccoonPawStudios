using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private static TransitionManager instance;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Animator portraitAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Typewriter Effect")]
    [SerializeField] private float typingSpeed = 0.5f;
    private Coroutine displayLineCoroutine;

    [Header("Audio Source")]
    [SerializeField] private AudioSource typeWriteSound;
    //[SerializeField] private AudioSource typewriter1;
    //[SerializeField] private AudioSource typewriter2;
    //[SerializeField] private AudioSource typewriter3;

    public Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    private bool canContinueToNextLine = false;
    //static Choice choiceSelected;

    private const string portrait = "portrait";

    private bool inLine = false;
    private bool skipTypeWriting = false;

    private bool transition = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static TransitionManager GetInstance()
    {
        return instance;
    }


    private void Start()
    {
        //Dialogue
        //dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        //choiceSelected = null;

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        EnterDialogueMode(loadGlobalsJSON);
        //Sound
        //typeWriteSound.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !inLine)
        {
            ContinueStory();
        }
        if (Input.GetKeyDown(KeyCode.Space) && inLine)
        {
            skipTypeWriting = true;
        }


        if (transition)
        {
            StopCoroutine(displayLineCoroutine);
            SceneManager.LoadScene("L01_Scene");
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Debug.Log("StartingScript");
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        //PlayerController.instance.canMove = false;
        ContinueStory();
    }

    public IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text += "";
        transition = true;
    }

    private void changeProfilePic(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case portrait:
                    portraitAnimator.Play(tagValue);
                    break;
            }
        }
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
                inLine = false;
            }
            //inLine = true;
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            //PlayerController.instance.canMove = false;
            typeWriteSound.Play();

            changeProfilePic(currentStory.currentTags);

        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }


    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text += "\n";

        canContinueToNextLine = false;
        //inLine = false;

        inLine = true;
        foreach (char letter in line.ToCharArray())
        {
            if (skipTypeWriting)
            {
                dialogueText.text += line;
                canContinueToNextLine = true;
                skipTypeWriting = false;
                inLine = false;
                break;
            }

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        typeWriteSound.Stop();
        canContinueToNextLine = true;
        inLine = false;
    }
}
