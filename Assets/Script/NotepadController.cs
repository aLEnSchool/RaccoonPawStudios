using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadController : MonoBehaviour
{
    [SerializeField] private GameObject notepad_Background;
    public bool notepadShown;

    public bool notepadHidden; 

    // Start is called before the first frame update
    void Start()
    {
        notepadShown = false;
        notepad_Background.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        notepad_Background.gameObject.SetActive(notepadShown);
    }

    public void showingNotepad()
    {
        Debug.Log(notepadShown);

        if (notepadShown)
        {
            notepadShown=false;
        }
        else
        {
            notepadShown = true;
        }
    }
}
