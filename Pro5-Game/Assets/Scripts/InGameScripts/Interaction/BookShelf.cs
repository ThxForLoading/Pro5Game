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
    [SerializeField] private AudioClip bookSlide;
    [SerializeField] private AudioClip shelfSlide;

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
        
        audioSource.PlayOneShot(bookSlide);
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
            
            isActive = false;
            Invoke("OpenDoor", 0.5f);
        }
        
        // loose condition
        if (checkID == numberBooks && !sequenceCorrect)
        {
            
            Invoke("ExecuteLoose", 0.5f);

        }
    }

    private void ExecuteLoose()
    {
        audioSource.PlayOneShot(wrongCombinationClip);
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
        audioSource.PlayOneShot(shelfSlide);
        door.activateDoor();
        isActive = false;
    }
}
