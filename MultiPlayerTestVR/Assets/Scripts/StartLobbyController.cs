using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int RoomSize;
    public TextMeshProUGUI username;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void QuickStart()
    {
        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinRoom("Room0");
        PhotonNetwork.LocalPlayer.NickName = username.text;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 0/*(byte)RoomSize */};
        roomOps.PublishUserId = true;
        PhotonNetwork.CreateRoom("Room" + 0, roomOps);
        //Debug.LogError(randomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to create room ... trying again");
        CreateRoom();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
