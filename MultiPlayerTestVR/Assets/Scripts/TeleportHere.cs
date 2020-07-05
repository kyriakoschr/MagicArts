using System.Collections;
using System.Collections.Generic;
using Tilia.Locomotors.Teleporter;
using UnityEngine;

public class TeleportHere : MonoBehaviour
{
    public TeleporterFacade teleporter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void teleHere()
    {
        teleporter.Teleport(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
