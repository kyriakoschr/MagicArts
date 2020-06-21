using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPaintings : MonoBehaviourPun,IPunObservable,IPunOwnershipCallbacks
{
    public bool[] isOpen = new bool[19];
    GameObject[] extras;

    GameObject[] FindInActiveObjectsByTag(string tag)
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
        return validTransforms.ToArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        extras = FindInActiveObjectsByTag("Extra");
        Debug.Log(extras.Length);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError(isOpen[2]);
    }

    public void OpenPaint(int i)
    {
        isOpen[i] = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsReading)//receiver
        {
            isOpen = (bool[])stream.ReceiveNext();

            for (int ind = 0; ind <=extras.Length;ind++)
                extras[ind].SetActive(isOpen[ind]);
        }
        else if (stream.IsWriting)//sender
        {
            stream.SendNext(isOpen);
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
