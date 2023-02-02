using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class Book : FPEInteractableActivateScript
{
    [SerializeField] private int bookID = 0;
    private float indentDistance = 0.085f;
    private BookShelf bookShelf;
    private bool isIndented = false;
    
    
    
    void Start()
    {
        bookShelf = GetComponentInParent<BookShelf>();
        if (bookShelf == null)
        {
            Debug.LogError("BookShelf not found");
        }
    }
    

    public void InteractBook()
    {
        if (isIndented) return;
        if (!BookShelf.isActive) return;
        IndentBook();
        isIndented = true;
        bookShelf.CheckOpenCondition(bookID, this);
    }

    private void IndentBook()
    {
        transform.Translate(Vector3.back * indentDistance);
    }

    public void RestoreBookPos()
    {
        transform.Translate(Vector3.back * -indentDistance);
        isIndented = false;
    }
}
