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
    

    public void interactBook()
    {
        if (isIndented) return;
        if (!BookShelf.isActive) return;
        indentBook();
        isIndented = true;
        bookShelf.checkOpenCondition(bookID, this);
    }

    public void indentBook()
    {
        transform.Translate(Vector3.right * indentDistance);
    }

    public void restoreBookPos()
    {
        transform.Translate(Vector3.right * -indentDistance);
        isIndented = false;
    }
}
