using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    private int pageIndex;
    private int maxPageCount;

    private GameObject[] book;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;

    // Start is called before the first frame update
    void Start()
    {
        pageIndex = 0;
        maxPageCount = 6;

        bookSetup();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxPageCount; i++)
        {
            if (i == pageIndex)
            {
                //book[pageIndex].SetActive(true);
            }
            else
            {
                //book[pageIndex].SetActive(false);
            }
        }
    }

    private void leftButton() 
    {
        pageIndex--;
        if (pageIndex <= 0)
        {
            pageIndex = 0;
        }
    }

    private void rightButton()
    {
        pageIndex++;
        if (pageIndex >= maxPageCount)
        {
            pageIndex = maxPageCount;
        }
    }

    private void bookSetup()
    {
        book = new GameObject[maxPageCount];
        book[0] = page1;
        book[1] = page2;
        book[2] = page3;
        book[3] = page4;
        book[4] = page5;
        book[5] = page6;
        
    }
}
