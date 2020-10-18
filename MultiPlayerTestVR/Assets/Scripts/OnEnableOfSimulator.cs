using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Tilia.Locomotors.Teleporter;
using UnityEngine;

public class OnEnableOfSimulator : MonoBehaviour
{
    public GripSwitch lInteractor;
    public GripSwitch rInteractor;
    public GameObject canvasD;
    public GameObject canvasN;
    public GameObject btnD;
    public GameObject btnN;
    public GameObject VRBtn;
    public GameObject SimBtn;
    public TeleporterFacade teleporter;
    public Transform trackedAllias;
    public GameObject toggleRay;
    public GameObject menuVIVE;
    public GameObject menuPC;
    public switchModes switcher;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        lInteractor.SimON();
        rInteractor.SimON();
        //btnD.SetActive(false);
        //btnN.SetActive(false);
        SimBtn.SetActive(true);
        VRBtn.SetActive(false);
        trackedAllias.position = new Vector3(0,16, 0);
        switcher.onEnable();
        /*toggleRay.SetActive(true);
        menuPC.SetActive(true);
        menuVIVE.SetActive(false);*/
    }

    private void OnDisable()
    {
        lInteractor.VRON();
        rInteractor.VRON();
        canvasD.SetActive(false);
        canvasN.SetActive(false);
        //btnD.SetActive(true);
        //btnN.SetActive(true);
        SimBtn.SetActive(false);
        VRBtn.SetActive(true);
        teleporter.Teleport(this.transform);
        trackedAllias.position = new Vector3(0, 16, 0);
        /*toggleRay.SetActive(false);
        menuPC.SetActive(false);
        menuVIVE.SetActive(true);*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}
