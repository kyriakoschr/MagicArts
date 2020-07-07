using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{

    public GameObject btn;
    public GameObject loading;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to "+PhotonNetwork.CloudRegion+" server!");
        loading.SetActive(false);
        btn.SetActive(true);
        //base.OnConnectedToMaster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
