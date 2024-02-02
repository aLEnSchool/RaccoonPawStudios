using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadController : MonoBehaviour
{
    public bool notepadShown;

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
