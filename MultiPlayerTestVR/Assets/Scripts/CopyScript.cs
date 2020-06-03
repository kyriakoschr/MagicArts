using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            //Transform t = new Transform();
            //ViveManager.Instance.avatar.transform;
            transform.position = ViveManager.Instance.avatar.transform.position;
            transform.rotation = ViveManager.Instance.avatar.transform.rotation;
        }
    }
}
