using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificRoom : MonoBehaviour
{
    [SerializeField] GameObject roomChecker;
    [SerializeField] RoomLocator room = RoomLocator.NoRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            roomChecker.GetComponent<RoomChecker>().changeRoom(room.ToString());
            Debug.Log(room.ToString() + " entered");
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
}
