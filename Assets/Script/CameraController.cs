using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Came : MonoBehaviour
{
    public Transform target;
    public float yPos=0f;

    [SerializeField] private ExitDoor exitDoor; // to access exit door script
    [SerializeField] private GameObject player; // to access player location

    private void Start()
    {
        yPos = 0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x, yPos, this.transform.position.z);


        // if the player exits the door at the end
        if (exitDoor.exitRoom) { 
            // change camera position to the new room
            yPos = -15.5f;
            // change the player position to be in the next room
            player.transform.position = new Vector3(-5.935f, -18f, -0.52f);
        }
    }
}
