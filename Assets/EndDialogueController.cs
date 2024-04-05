using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndDialogueController : MonoBehaviour
{
    private static EndDialogueController instance;

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

    public static EndDialogueController GetInstance()
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

        //Sound
        //typeWriteSound.Stop();
    }

    private void Update()
    {
        /*if (!dialogueIsPlaying)
        {
            PlayerController.instance.canMove = true;
            return;
        }*/

        //if (Input.GetKeyDown(KeyCode.E) && !inLine && NotepadController.instance.notepadShown)
        /*if (Input.GetKeyDown(KeyCode.E) && !inLine && NotepadController.instance.notepadShown)
        {
            //Debug.Log("this e");
            ContinueStory();
        }
        if (Input.GetKeyDown(KeyCode.E) && inLine && NotepadController.instance.notepadShown)
        {
            skipTypeWriting = true;
        }*/

        if (Input.GetKeyDown(KeyCode.E) && !inLine)
        {
            ContinueStory();
        }
        if (Input.GetKeyDown(KeyCode.E) && inLine)
        {
            skipTypeWriting = true;
        }
        
        
        if (transition)
        {
            StopCoroutine(displayLineCoroutine);
            SceneManager.LoadScene("Fin");
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
        dialogueText.text = "";
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

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than can take");
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        //dialoguePanel.SetActive(true);
        //yield return new WaitUntil(() => { return choiceSelected != null; });

        //AdvanceFromDecision();
        //StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        //HideChoices();

        canContinueToNextLine = false;
        //inLine = false;

        inLine = true;
        foreach (char letter in line.ToCharArray())
        {
            if (skipTypeWriting)
            {
                dialogueText.text = line;
                skipTypeWriting = false;
                inLine = false;
                break;
            }
            dialogueText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }

        typeWriteSound.Stop();
        //DisplayChoices();
        canContinueToNextLine = true;
        //skipTypeWriting = false;
        inLine = false;
    }
}
