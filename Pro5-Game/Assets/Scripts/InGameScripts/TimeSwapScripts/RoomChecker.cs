using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class RoomChecker : MonoBehaviour
{
    [SerializeField] Text roomText;
    RoomLocator currentRoom = RoomLocator.NoRoom;
    GameObject player;
    [SerializeField] GameObject[] NOWTeleportPoints;
    [SerializeField] GameObject[] OLDTeleportPoints;
    [SerializeField] private PostProcessProfile pppNow;
    [SerializeField] private PostProcessProfile pppPast;
    private PostProcessVolume volume;
    
    private bool InTheNow = true;

    GameObject clockChecker;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        clockChecker = GameObject.FindGameObjectWithTag("ClockCheck");
        print(clockChecker);
        volume = FindObjectOfType<PostProcessVolume>();
    }

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
        

        if (Input.GetKeyDown(KeyCode.Q) && clockChecker.GetComponent<ClockEnabler>().clock)
        {
            Debug.Log("Changing Times");
            Fader.fader.CrossFade(changeTime);
            AudioManager.instance.SwapTrack();

        }

        if (!InTheNow)
        {
            volume.profile = pppPast;
        }
        else
        {
            volume.profile = pppNow;
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
        if (InTheNow)
        {
            InTheNow = false;

            switch (currentRoom)
            {
                case RoomLocator.LivingRoom:
                    player.transform.position = OLDTeleportPoints[0].gameObject.transform.position;
                    break;
                case RoomLocator.Kitchen:
                    player.transform.position = OLDTeleportPoints[1].gameObject.transform.position;
                    break;
                case RoomLocator.DiningRoom:
                    player.transform.position = OLDTeleportPoints[2].gameObject.transform.position;
                    break;
                case RoomLocator.Bath:
                    player.transform.position = OLDTeleportPoints[3].gameObject.transform.position;
                    break;
                case RoomLocator.Bedroom:
                    player.transform.position = OLDTeleportPoints[4].gameObject.transform.position;
                    break;
                case RoomLocator.FoyerLower:
                    player.transform.position = OLDTeleportPoints[5].gameObject.transform.position;
                    break;
                case RoomLocator.EntranceArea:
                    player.transform.position = OLDTeleportPoints[6].gameObject.transform.position;
                    break;
                case RoomLocator.Closet:
                    player.transform.position = OLDTeleportPoints[7].gameObject.transform.position;
                    break;
                case RoomLocator.AntiquesRoom:
                    player.transform.position = OLDTeleportPoints[8].gameObject.transform.position;
                    break;
                case RoomLocator.HiddenRoom:
                    player.transform.position = OLDTeleportPoints[9].gameObject.transform.position;
                    break;
                case RoomLocator.Stairs:
                    player.transform.position = OLDTeleportPoints[10].gameObject.transform.position;
                    break;
                case RoomLocator.Backroom:
                    player.transform.position = OLDTeleportPoints[11].gameObject.transform.position;
                    break;
                case RoomLocator.FoyerUpper:
                    player.transform.position = OLDTeleportPoints[12].gameObject.transform.position;
                    break;
                case RoomLocator.WC:
                    player.transform.position = OLDTeleportPoints[13].gameObject.transform.position;
                    break;
                case RoomLocator.UtilityRoom:
                    player.transform.position = OLDTeleportPoints[14].gameObject.transform.position;
                    break;
                case RoomLocator.StorageRoom:
                    //player.transform.position = OLDTeleportPoints[15].gameObject.transform.position;      //Uncomment if necessary, prevents player from traveling to old storageRoom
                    break;
                case RoomLocator.FinalRoom:
                    player.transform.position = OLDTeleportPoints[16].gameObject.transform.position;
                    break;
                case RoomLocator.NoRoom:
                    Debug.Log("Something went wrong...");
                    break;
                default:
                    Debug.Log("Something went wrong...");
                    break;
            }
        }
        else
        {
            InTheNow = true;

            switch (currentRoom)
            {
                case RoomLocator.LivingRoom:
                    player.transform.position = NOWTeleportPoints[0].gameObject.transform.position;
                    break;
                case RoomLocator.Kitchen:
                    player.transform.position = NOWTeleportPoints[1].gameObject.transform.position;
                    break;
                case RoomLocator.DiningRoom:
                    player.transform.position = NOWTeleportPoints[2].gameObject.transform.position;
                    break;
                case RoomLocator.Bath:
                    player.transform.position = NOWTeleportPoints[3].gameObject.transform.position;
                    break;
                case RoomLocator.Bedroom:
                    player.transform.position = NOWTeleportPoints[4].gameObject.transform.position;
                    break;
                case RoomLocator.FoyerLower:
                    player.transform.position = NOWTeleportPoints[5].gameObject.transform.position;
                    break;
                case RoomLocator.EntranceArea:
                    player.transform.position = NOWTeleportPoints[6].gameObject.transform.position;
                    break;
                case RoomLocator.Closet:
                    player.transform.position = NOWTeleportPoints[7].gameObject.transform.position;
                    break;
                case RoomLocator.AntiquesRoom:
                    player.transform.position = NOWTeleportPoints[8].gameObject.transform.position;
                    break;
                case RoomLocator.HiddenRoom:
                    player.transform.position = NOWTeleportPoints[9].gameObject.transform.position;
                    break;
                case RoomLocator.Stairs:
                    player.transform.position = NOWTeleportPoints[10].gameObject.transform.position;
                    break;
                case RoomLocator.Backroom:
                    player.transform.position = NOWTeleportPoints[11].gameObject.transform.position;
                    break;
                case RoomLocator.FoyerUpper:
                    player.transform.position = NOWTeleportPoints[12].gameObject.transform.position;
                    break;
                case RoomLocator.WC:
                    player.transform.position = NOWTeleportPoints[13].gameObject.transform.position;
                    break;
                case RoomLocator.UtilityRoom:
                    player.transform.position = NOWTeleportPoints[14].gameObject.transform.position;
                    break;
                case RoomLocator.StorageRoom:
                    player.transform.position = NOWTeleportPoints[15].gameObject.transform.position;
                    break;
                case RoomLocator.FinalRoom:
                    player.transform.position = NOWTeleportPoints[16].gameObject.transform.position;
                    break;
                case RoomLocator.NoRoom:
                    Debug.Log("Something went wrong...");
                    break;
                default:
                    Debug.Log("Something went wrong...");
                    break;
            }
        }
        
    }
}
