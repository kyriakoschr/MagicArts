using UnityEngine;
using System.Collections;
using TMPro;
using Photon.Pun;

public class PlayerNameScript : MonoBehaviourPun, IPunObservable
{

    string playerName;

    void Start()
    {
        if(photonView.IsMine)
            playerName= PhotonNetwork.LocalPlayer.NickName;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerName);
        }
        else
        {
            playerName = (string)stream.ReceiveNext();
        }
    }

    void Update()
    {
        GetComponent<TextMeshPro>().text = playerName;
        transform.GetChild(1).GetComponent<TextMeshPro>().text = playerName;
    }

}