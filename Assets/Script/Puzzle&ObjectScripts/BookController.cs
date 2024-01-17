using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    private int pageIndex;
    private int maxPageCount;

    private GameObject[] book;

    // Start is called before the first frame update
    void Start()
    {
        pageIndex = 0;
        maxPageCount = 5;
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
}
