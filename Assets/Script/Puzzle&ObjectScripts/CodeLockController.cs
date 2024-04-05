using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CodeLockController : MonoBehaviour
{
    public TMP_Text codeOutput; 
    private string sequence = "";

    public bool sequenceRight;

    public GameObject openLocker;
    public GameObject closeLocker;

    private void Awake()
    {
        sequenceRight = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        openLocker.SetActive(false);
        sequenceRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        codeOutput.SetText(sequence);
        
        if (sequence == "2635")
        {
            sequenceRight = true;
        }
        else if (sequence.Length > 3)
        {
            sequence = "";
        }

        if (sequenceRight)
        {
            openLocker.SetActive(true);
            closeLocker.SetActive(false);
            closeLocker.GetComponent<PuzzleShowController>().interact = true;
            PlayerDataController.instance.drugsFound = true;
            //Debug.Log("You is right");
        }
        else { openLocker.SetActive(false); }

    }

    public void AddDigit(string digit)
    {
        sequence += digit;
    }
}
