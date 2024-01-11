using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CodeLockController : MonoBehaviour
{
    public TMP_Text codeOutput; 
    private string sequence = "";

    private bool sequenceRight;

    // Start is called before the first frame update
    void Start()
    {
        sequenceRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        codeOutput.SetText(sequence);
        
        if (sequence == "263")
        {
            sequenceRight = true;
        }
        else if (sequence.Length > 3)
        {
            sequence = "";
        }
        
        if (sequenceRight)
        {
            Debug.Log("You is right");
        }
    }

    public void AddDigit(string digit)
    {
        sequence += digit;
    }
}
