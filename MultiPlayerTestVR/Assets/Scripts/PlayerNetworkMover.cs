using UnityEngine;
using System.Collections;
using Photon.Pun;
using TMPro;

public class PlayerNetworkMover : MonoBehaviourPun,IPunObservable
{
    public string playerName;
    private Transform _transformCacheName;
    private Transform _playerTransformName;

    void Start()
    {
        _transformCacheName = GetComponent<Transform>();
        _playerTransformName = _transformCacheName.Find("Username");
        playerName = PhotonNetwork.LocalPlayer.NickName;
        if (photonView.IsMine)
        {
            GetComponentInChildren<PlayerNameScript>().enabled = true;
        }
        else
        {
            StartCoroutine("UpdateData");
        }
    }

    IEnumerator UpdateData()
    {
        while (true)
        {
            playerName = _playerTransformName.GetComponent<TextMeshPro>().text;
            yield return null;
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_playerTransformName.GetComponent<TextMeshPro>().text);
        }
        else
        {
            //Debug.LogError("My name will be printed on" + _playerTransformName.GetComponent<TextMeshPro>().text);
            //Debug.LogError("stream contains" + stream.ReceiveNext());
            transform.Find("Username").GetComponent<TextMeshPro>().SetText((string)stream.ReceiveNext());
        }
    }

}