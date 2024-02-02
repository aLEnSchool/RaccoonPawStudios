using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadController : MonoBehaviour
{   
    private bool notepadShown;

    // Start is called before the first frame update
    void Start()
    {
        notepadShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.gameObject.SetActive(notepadShown);
    }

    private void showingNotepad()
    {
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
