using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableOfSimulator : MonoBehaviour
{
    public GripSwitch lInteractor;
    public GripSwitch rInteractor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        lInteractor.SimON();
        rInteractor.SimON();
    }

    private void OnDisable()
    {
        lInteractor.VRON();
        rInteractor.VRON();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
