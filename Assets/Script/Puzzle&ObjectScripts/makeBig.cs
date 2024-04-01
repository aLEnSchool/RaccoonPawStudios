using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeBig : MonoBehaviour
{
    //https://www.youtube.com/watch?v=xtebzQEX8T8

    private Vector3 bigScale, smallScale;
    private bool isBig;

    // Start is called before the first frame update
    void Start()
    {
        bigScale = new Vector3(1f, 1f, 1f);
        smallScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isBig = false;
    }   

    // Update is called once per frame
    private void OnMouseOver()
    {
        isBig = true;
        transform.localScale = bigScale;
        //isBig = !isBig; 
    } 
    private void OnMouseExit()
    {
        isBig = false;
        transform.localScale = smallScale;
        //isBig = !isBig; 
    }
}
