using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Whilefun.FPEKit;

public class BookShelf : MonoBehaviour
{
    public static bool isActive = true;
    
    [SerializeField] private int numberBooks = 4;
    [SerializeField] private FPESlidingDoor door;
    [SerializeField] private AudioClip wrongCombinationClip;

    private AudioSource audioSource;
    private  int[] bookIds = new int[4];

    private  bool sequenceCorrect = true;
    private  int checkID = 0;

    private Book[] books;

    private void Start()
    {
        books = new Book[numberBooks];
        audioSource = GetComponent<AudioSource>();
    }


    public void CheckOpenCondition(int bookID, Book curBook)
    {
        print("check open cond");
        books[checkID] = curBook;

        if (bookID != checkID)
        {
            sequenceCorrect = false;
        }
        
        checkID++;
        
        // win condition
        if (checkID == numberBooks && sequenceCorrect)
        {
            OpenDoor();
            isActive = false;
        }
        
        // loose condition
        if (checkID == numberBooks && !sequenceCorrect)
        {
            audioSource.PlayOneShot(wrongCombinationClip);
            Invoke("ExecuteLoose", 0.5f);

        }
    }

    private void ExecuteLoose()
    {
        
        foreach (Book book in books)
        {
            book.RestoreBookPos();
        }

        books = new Book[numberBooks];
        sequenceCorrect = true;
        checkID = 0;
    }

    private void OpenDoor()
    {
        door.activateDoor();
        isActive = false;
    }
}
