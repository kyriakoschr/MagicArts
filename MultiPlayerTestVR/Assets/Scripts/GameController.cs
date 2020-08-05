using Photon.Pun;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviourPunCallbacks
{
    public GameObject myLocalPlayer;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        myLocalPlayer = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PPlayer"), Vector3.zero, Quaternion.identity);
        myLocalPlayer.transform.Find("Head/Username").GetComponent<TextMeshPro>().SetText(PhotonNetwork.LocalPlayer.NickName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
