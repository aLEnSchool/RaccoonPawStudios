using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class escapeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI escText;

    // Start is called before the first frame update
    void Start()
    {
        escText.enabled = false;

        StartCoroutine(dale());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator dale()
    {
        yield return new WaitForSeconds(95);
        escText.enabled = true;
        Debug.Log("escape");

    }
}
