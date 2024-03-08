using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoom : MonoBehaviour
{
    [SerializeField] private GameObject lantern;
    [SerializeField] private GameObject alleyDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.tag == "Lit Lantern")
        //{
        //    gameObject.SetActive(false);
        //    alleyDoor.SetActive(true);
        //}
    }
}
