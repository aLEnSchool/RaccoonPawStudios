using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Came : MonoBehaviour
{
    public Transform target;
    public float yPos=0f;

    [SerializeField] private ExitDoor exitDoor;
    private void Start()
    {
        yPos = 0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x, yPos, this.transform.position.z);

        // if the player exits the door at the end
        //if (exitDoor.exitRoom)
        //
            // change camera position to the new room
        //    yPos = -15.5f;
        //}
    }
}
