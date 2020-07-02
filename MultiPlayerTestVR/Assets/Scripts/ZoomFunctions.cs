using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomFunctions : MonoBehaviour
{
    public GameObject LZoom;
    public GameObject RZoom;

    public GameObject uxr;
    public GameObject sim;

    public bool rightOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnableDisable()
    {
        if (rightOn)
            EnableDisableR();
        else
            EnableDisableL();
    }

    public void EnableDisableL()
    {
        LZoom.SetActive(!LZoom.activeSelf);
    }
    public void EnableDisableR()
    {
        RZoom.SetActive(!RZoom.activeSelf);
    }
}
