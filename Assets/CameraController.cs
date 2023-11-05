using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Came : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x, target.position.y + 3f, this.transform.position.z);
    }
}
