using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraTutorial : MonoBehaviour
{
    public Transform target;
    public float yPos = 0f;

    //[SerializeField] private ExitDoor exitDoor; // to access exit door script
    //[SerializeField] private ExitDoor exitBackToDiner; // To access Diner from Hallway script
    
    //[SerializeField] private KitchenDoorController kitchenDoor; // To access Kitchen from Diner script
    //[SerializeField] private ExitDoor kitchenToDiner; //To access Diner from Kitchen script

    //[SerializeField] private ExitDoor doorToAlley;
    //[SerializeField] private ExitDoor exitAlley;

    [SerializeField] private GameObject player; // to access player location

    //[SerializeField] private FadeToBlack screenFade;

    private void Start()
    {
        yPos = 0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x, yPos, this.transform.position.z);


        // fade to black doesn't work anymore if user spams e on the keyboard
        /*-- Hallway TP --*/
        // if the player exits the door at the end
        //if (exitDoor.exitRoom) 
        //{
        //    StartCoroutine(switchRooms(-15.5f, new Vector3(-5.935f, -18f, -0.52f), exitDoor));
        //}

        ////if the player wants to go from hallway back to diner
        //if (exitBackToDiner.exitRoom)
        //{
        //    StartCoroutine(switchRooms(0f, new Vector3(95.4f, -2.5f, -0.52f), exitBackToDiner));
        //}

        ///*-- Kitchen TP --*/
        ////if the player wants to go from diner to kitchen
        //if (kitchenDoor.exitRoom)
        //{
        //    StartCoroutine(switchRoomToKitchen(-31.5f, new Vector3(-3f, -34f, -0.52f), kitchenDoor));
        //}

        ////if the player wants to go from hallway back to diner
        //if (kitchenToDiner.exitRoom)
        //{
        //    StartCoroutine(switchRooms(0f, new Vector3(59f, -2.5f, -0.52f), kitchenToDiner));
        //}

        //// Between staff room and alley
        //// Exit staff room and go into alley
        //if (doorToAlley.exitRoom)
        //{
        //    StartCoroutine(switchRooms(-48.5f, new Vector3(-4.6f, -51.9f, -0.52f), doorToAlley));
        //}
        //// Exit alley go back into staff room
        //if (exitAlley.exitRoom)
        //{
        //    StartCoroutine(switchRooms(-15.5f, new Vector3(35.04f, -18.4f, -0.52f), exitAlley));
        //}
    }

    // 
    //private IEnumerator switchRooms(float yPosition, Vector3 playerPosition, ExitDoor door)
    //{
    //    StartCoroutine(screenFade.fadeOut()); // fade to black

    //    yield return new WaitForSeconds(0.5f);

    //    // change camera position to the new room
    //    yPos = yPosition;
    //    // change the player position to be in the next room
    //    player.transform.position = playerPosition;
    //    door.exitRoom = false; //turn off so not constantly tp

    //    yield return new WaitForSeconds(0.5f);

    //    StartCoroutine(screenFade.fadeIn()); // fade in
    //}

    //private IEnumerator switchRoomToKitchen(float yPosition, Vector3 playerPosition, KitchenDoorController door)
    //{
    //    StartCoroutine(screenFade.fadeOut()); // fade to black

    //    yield return new WaitForSeconds(0.5f);

    //    // change camera position to the new room
    //    yPos = yPosition;
    //    // change the player position to be in the next room
    //    player.transform.position = playerPosition;
    //    door.exitRoom = false; //turn off so not constantly tp

    //    yield return new WaitForSeconds(0.5f);

    //    StartCoroutine(screenFade.fadeIn()); // fade in
    //}
}