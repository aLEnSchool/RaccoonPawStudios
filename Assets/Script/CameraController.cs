using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Came : MonoBehaviour
{
    public Transform target;
    public float yPos=0f;
    private void Start()
    {
        yPos = 0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x, yPos, this.transform.position.z);
    }
}
