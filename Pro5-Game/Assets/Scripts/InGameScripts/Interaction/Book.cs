using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class Book : FPEInteractableActivateScript
{
    [SerializeField] private int bookID = 0;
    private float indentDistance = 0.05f;
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

    public void IndentBook()
    {
        transform.Translate(Vector3.right * indentDistance);
    }

    public void RestoreBookPos()
    {
        transform.Translate(Vector3.right * -indentDistance);
        isIndented = false;
    }
}
