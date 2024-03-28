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

    private const string portrait = "portrait";



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

        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
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
        foreach (string tag in currentTags) { 
            string[] splitTag = tag.Split(':');
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey) {
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
            }
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

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            /* Failed Attempt
            int random_typeSound = Random.Range(1, 3);
            if (random_typeSound == 1)
            {
                typewriter1.Play();
            }
            if (random_typeSound == 2)
            {
                typewriter2.Play();
            }
            if (random_typeSound == 3)
            {
                typewriter3.Play();
            }*/

            yield return new WaitForSeconds(typingSpeed);
        }
        Debug.Log("Stop sound");
        typeWriteSound.Stop();
    }
}


