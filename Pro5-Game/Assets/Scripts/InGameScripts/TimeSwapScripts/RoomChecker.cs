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
        switch (currentRoom)
        {
            case RoomLocator.LivingRoom:
                roomText.text = "Living Room";
                break;
            case RoomLocator.Kitchen:
                roomText.text = "Kitchen";
                break;
            case RoomLocator.DiningRoom:
                roomText.text = "Dining Room";
                break;
            case RoomLocator.Bath:
                roomText.text = "Bath";
                break;
            case RoomLocator.Bedroom:
                roomText.text = "Bedroom";
                break;
            case RoomLocator.FoyerLower:
                roomText.text = "Bottom Floor Foyer";
                break;
            case RoomLocator.EntranceArea:
                roomText.text = "Entrance";
                break;
            case RoomLocator.Closet:
                roomText.text = "Closet";
                break;
            case RoomLocator.AntiquesRoom:
                roomText.text = "Antiques Room";
                break;
            case RoomLocator.HiddenRoom:
                roomText.text = "Hidden Room?";
                break;
            case RoomLocator.Stairs:
                roomText.text = "Stairway";
                break;
            case RoomLocator.Backroom:
                roomText.text = "Kitchen Backroom";
                break;
            case RoomLocator.FoyerUpper:
                roomText.text = "1st Floor Foyer";
                break;
            case RoomLocator.WC:
                roomText.text = "Toilet";
                break;
            case RoomLocator.UtilityRoom:
                roomText.text = "Utility Room";
                break;
            case RoomLocator.StorageRoom:
                roomText.text = "Storage Room";
                break;
            case RoomLocator.FinalRoom:
                roomText.text = "Final Room";
                break;
            case RoomLocator.NoRoom:
                roomText.text = "NoRoom?";
                break;
            default:
                roomText.text = "No Room?";
                break;
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
        DiningRoom,
        Bath,
        Bedroom,
        FoyerLower,
        EntranceArea,
        Closet,
        AntiquesRoom,
        HiddenRoom,
        Stairs,
        Backroom,
        FoyerUpper,
        WC,
        UtilityRoom,
        StorageRoom,
        FinalRoom,
        NoRoom
    }

    public void changeRoom(string room)
    {

        switch (room)
        {
            case "LivingRoom":
                currentRoom = RoomLocator.LivingRoom;
                break;
            case "Kitchen":
                currentRoom = RoomLocator.Kitchen;
                break;
            case "DiningRoom":
                currentRoom = RoomLocator.DiningRoom;
                break;
            case "Bath":
                currentRoom = RoomLocator.Bath;
                break;
            case "Bedroom":
                currentRoom = RoomLocator.Bedroom;
                break;
            case "FoyerLower":
                currentRoom = RoomLocator.FoyerLower;
                break;
            case "EntranceArea":
                currentRoom = RoomLocator.EntranceArea;
                break;
            case "Closet":
                currentRoom = RoomLocator.Closet;
                break;
            case "AntiquesRoom":
                currentRoom = RoomLocator.AntiquesRoom;
                break;
            case "HiddenRoom":
                currentRoom = RoomLocator.HiddenRoom;
                break;
            case "Stairs":
                currentRoom = RoomLocator.Stairs;
                break;
            case "Backroom":
                currentRoom = RoomLocator.Backroom;
                break;
            case "FoyerUpper":
                currentRoom = RoomLocator.FoyerUpper;
                break;
            case "WC":
                currentRoom = RoomLocator.WC;
                break;
            case "UtilityRoom":
                currentRoom = RoomLocator.UtilityRoom;
                break;
            case "StorageRoom":
                currentRoom = RoomLocator.StorageRoom;
                break;
            case "FinalRoom":
                currentRoom = RoomLocator.FinalRoom;
                break;
            default:
                currentRoom = RoomLocator.NoRoom;
                break;
        }

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
        if (currentRoom == RoomLocator.DiningRoom)
        {
            Debug.Log("Teleporting to old Dining Room");
        }
        if (currentRoom == RoomLocator.NoRoom)
        {
            Debug.Log("Something went wrong...");
        }
    }
}
