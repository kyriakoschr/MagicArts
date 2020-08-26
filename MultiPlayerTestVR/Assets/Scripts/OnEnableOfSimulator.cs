using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        lInteractor.SimON();
        rInteractor.SimON();
        btnD.SetActive(false);
        btnN.SetActive(false);
        SimBtn.SetActive(true);
        VRBtn.SetActive(false);
    }

    private void OnDisable()
    {
        lInteractor.VRON();
        rInteractor.VRON();
        canvasD.SetActive(false);
        canvasN.SetActive(false);
        btnD.SetActive(true);
        btnN.SetActive(true);
        SimBtn.SetActive(false);
        VRBtn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
