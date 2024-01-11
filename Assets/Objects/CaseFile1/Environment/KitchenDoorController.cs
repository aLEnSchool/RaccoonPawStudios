using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KitchenDoorController : MonoBehaviour
{
    public WaitressController sadie;

    public GameObject dialogBox;
    public TMP_Text dialogOutput;
    private string voiceLine;

    // Start is called before the first frame update
    void Start()
    {
        voiceLine = "Can't come in here, it's restricted";
    }

    // Update is called once per frame
    void Update()
    {
        if (sadie.cookBusy)
        {
            //TP TO KITCHEN
        }
        else
        {

        }
    }
}
