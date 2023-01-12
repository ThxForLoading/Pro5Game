using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    public static bool isActive = true;
    
    [SerializeField] private int numberBooks = 4;
    private  int[] bookIds = new int[4];

    private  bool sequenceCorrect = true;
    private  int checkID = 0;

    private Book[] books;

    private void Start()
    {
        books = new Book[numberBooks]; 
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
            ExecuteLoose();
        }
    }

    private void ExecuteLoose()
    {
        print("Loose");
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
        transform.Rotate(0f,90f,0f);
        isActive = false;
    }
}
