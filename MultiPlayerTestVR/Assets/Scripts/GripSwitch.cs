using System.Collections;
using System.Collections.Generic;
using Tilia.Interactions.Interactables.Interactors;
using UnityEngine;
using Zinnia.Action;

public class GripSwitch : MonoBehaviour
{
    public GameObject simulator;
    public BooleanAction VRAction;
    public BooleanAction SimAction;
    public InteractorFacade interactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void VRON()
    {
        interactor.GrabAction = VRAction;
    }

    public void SimON()
    {
        interactor.GrabAction = SimAction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
