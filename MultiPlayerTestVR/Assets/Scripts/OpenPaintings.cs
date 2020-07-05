using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPaintings : MonoBehaviourPun,IPunObservable,IPunOwnershipCallbacks
{
    public bool[] isOpen = new bool[19];
    public int[] isPlaying = new int[19];
    List<GameObject> extras;
    public GameObject sound;

    List<GameObject> FindInActiveObjectsByTag(string tag)
    {
        List<GameObject> validTransforms = new List<GameObject>();
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].gameObject.CompareTag(tag))
                {
                    validTransforms.Add(objs[i].gameObject);
                }
            }
        }
        return validTransforms;
    }

    // Start is called before the first frame update
    void Start()
    {
        extras = FindInActiveObjectsByTag("Extra");
        //Debug.Log(extras.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(isOpen[2]);
    }

    public void ReqAndOpen(int i)
    {
        Debug.LogError(photonView.IsMine);
        base.photonView.RequestOwnership();
        Debug.LogError("req "+photonView.IsMine);
        isOpen[i] = true;
        this.photonView.RPC("soundON", RpcTarget.All);
    }


    [PunRPC]
    public void soundON()
    {
        sound.GetComponent<AudioSource>().Play();
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsReading)//receiver
        {
            for (int i = 0; i < isOpen.Length; i++)
                isOpen[i] = (bool)stream.ReceiveNext();
            //isPlaying = (int[])stream.ReceiveNext();
            string tstr = "extra";
            for (int ind = 0; ind < isOpen.Length; ind++)
            {
                Debug.LogError(tstr + ind.ToString() + " " + isOpen[ind]);
                extras.Find(x => x.name.Equals(tstr + ind.ToString())).SetActive(isOpen[ind]);
            }
        }
        else if (stream.IsWriting)//sender
        {
            for(int i=0; i<isOpen.Length;i++)
                stream.SendNext(isOpen[i]);
            //stream.SendNext(isPlaying);
        }
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        Debug.LogError(requestingPlayer.UserId+" requesting ");
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.LogError("transfered");
    }
}
