﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitUXR : MonoBehaviour
{
    public Transform trackedAllias;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        this.transform.position = trackedAllias.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}