using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadController : MonoBehaviour
{
    public static NotepadController instance;

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
        //notepad_Background.gameObject.SetActive(notepadShown);

        if (notepadShown)
        {
            notepad_Background.gameObject.SetActive(true);
            PlayerController.instance.canMove = false;
        }
        else
        {
            notepad_Background.gameObject.SetActive(false);
            PlayerController.instance.canMove = true;
        }
    }

    public void showingNotepad()
    {
        Debug.Log(notepadShown);

        if (notepadShown)
        {
            notepadShown = false;
        }
        else
        {
            notepadShown = true;
        }
    }
}
