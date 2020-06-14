using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyVIVEscript : MonoBehaviour
{
    private bool isHovering = false;
    private bool wasPressed = false;
    private bool isInUse = false;

    public bool WasPressed
    {
        get
        {
            return wasPressed;
        }
        set
        {
            wasPressed = value;
        }
    }

    public bool IsHovering
    {
        get
        {
            return isHovering;
        }
        set
        {
            isHovering = value;
        }
    }

    public bool IsInUse
    {
        get
        {
            return isInUse;
        }
        set
        {
            isInUse = value;
        }
    }
}
