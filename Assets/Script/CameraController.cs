using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Came : MonoBehaviour
{
    public Transform target;
    public float yPos = 0f;

    [SerializeField] private ExitDoor exitDoor; // to access exit door script
    [SerializeField] private ExitBackToDiner exitBackToDiner; // To access Diner from Hallway script
    
    [SerializeField] private KitchenDoorController kitchenDoor; // To access Kitchen from Diner script
    [SerializeField] private ExitKitchenToDiner kitchenToDiner; //To access Diner from Kitchen script

    [SerializeField] private GameObject player; // to access player location

    private void Start()
    {
        yPos = 0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x, yPos, this.transform.position.z);


        /*-- Hallway TP --*/
        // if the player exits the door at the end
        if (exitDoor.exitRoom) { 
            // change camera position to the new room
            yPos = -15.5f;
            // change the player position to be in the next room
            player.transform.position = new Vector3(-5.935f, -18f, -0.52f);

            exitDoor.exitRoom = false; //turn off so not constantly tp
        }

        //if the player wants to go from hallway back to diner
        if (exitBackToDiner.exitRoom)
        {
            // change camera position to the diner
            yPos = 0f;
            // change the player position to be in the diner
            player.transform.position = new Vector3(95.4f, -2.5f, -0.52f);

            exitBackToDiner.exitRoom = false; //turn off so not constantly tp
        }

        /*-- Kitchen TP --*/
        //if the player wants to go from diner to kitchen
        if (kitchenDoor.exitRoom)
        {
            // change camera position to the diner
            yPos = -31.5f;
            // change the player position to be in the diner
            player.transform.position = new Vector3(-3f, -34f, -0.52f);

            kitchenDoor.exitRoom = false; //turn off so not constantly tp
        }

        //if the player wants to go from hallway back to diner
        if (kitchenToDiner.exitRoom)
        {
            // change camera position to the diner
            yPos = 0f;
            // change the player position to be in the diner
            player.transform.position = new Vector3(59f, -2.5f, -0.52f);

            kitchenToDiner.exitRoom = false; //turn off so not constantly tp
        }
    }
}
