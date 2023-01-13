using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whilefun.FPEKit;

public class DestructableObject : FPEInteractableActivateScript
{

    public void destroyObject()
    {
        Destroy(this.gameObject);
    }
}
