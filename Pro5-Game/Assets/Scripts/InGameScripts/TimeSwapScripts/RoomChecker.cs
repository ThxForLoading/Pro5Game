using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomChecker : MonoBehaviour
{
    [SerializeField] Text roomText;
    RoomLocator currentRoom = RoomLocator.NoRoom;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoom == RoomLocator.Kitchen)
        {
            roomText.text = "Kitchen";
        }
        if (currentRoom == RoomLocator.LivingRoom)
        {
            roomText.text = "LivingRoom";
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Changing Times");
            changeTime();
        }
    }

    enum RoomLocator
    {
        LivingRoom,
        Kitchen,
        NoRoom
    }

    public void changeRoom(string room)
    {
        if (room == "LivingRoom")
        {
            currentRoom = RoomLocator.LivingRoom;
            return;
        }
        if (room == "Kitchen")
        {
            currentRoom = RoomLocator.Kitchen;
            return;
        }
        currentRoom = RoomLocator.NoRoom;

    }

    private void changeTime()
    {
        if (currentRoom == RoomLocator.Kitchen)
        {
            Debug.Log("Teleporting to old Kitchen");
            player.transform.position = new Vector3(0, 2, 0);
        }
        if (currentRoom == RoomLocator.LivingRoom)
        {
            Debug.Log("Teleporting to old LivingRoom");
        }
        if (currentRoom == RoomLocator.NoRoom)
        {
            Debug.Log("Something went wrong...");
        }
    }
}
