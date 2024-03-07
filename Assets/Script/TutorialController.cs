using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    //Voice Line Variables
    [Header("Voice Lines", order = 1)]
    public string[] voiceLines;
    private int voiceLineIndex;
    public GameObject dialogBox;
    public TMP_Text dialogOutput;
    //public GameObject dialogButton;

    [Header("Typewriter Variables", order = 2)]
    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    public void ContinueDialog(int index)
    {
        EndCheck();
        dialogOutput.text = voiceLines[index];
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
