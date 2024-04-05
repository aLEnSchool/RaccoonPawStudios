using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
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
    static Choice choiceSelected;

    private const string portrait = "portrait";

    private bool inLine = false;
    private bool skipTypeWriting = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }


    private void Start()
    {
        //Dialogue
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choiceSelected = null;

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
        if (!dialogueIsPlaying)
        {
            PlayerController.instance.canMove = true;
            return;
        }

        //if (Input.GetKeyDown(KeyCode.E) && !inLine && NotepadController.instance.notepadShown)
        if (Input.GetKeyDown(KeyCode.E) && !inLine && NotepadController.instance.notepadShown)
        {
            //Debug.Log("this e");
            ContinueStory();
        }
        if (Input.GetKeyDown(KeyCode.E) && inLine && NotepadController.instance.notepadShown)
        {
            skipTypeWriting = true;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        PlayerController.instance.canMove = false;
        ContinueStory();
    }

    public IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
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
            PlayerController.instance.canMove = false;
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

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than can take");
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
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
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        HideChoices();

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
        DisplayChoices();
        canContinueToNextLine = true;
        //skipTypeWriting = false;
        inLine = false;
    }

    private IEnumerator SelectFirstChoice() 
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine) 
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            // NOTE: The below two lines were added to fix a bug after the Youtube video was made
            //choices.GetInstance().RegisterSubmitPressed(); // this is specific to my InputManager script
            ContinueStory();
        }
    }

    private void HideChoices() 
    {
        foreach (GameObject choiceButton in choices) 
        {
            choiceButton.SetActive(false);
        }
    }
}


