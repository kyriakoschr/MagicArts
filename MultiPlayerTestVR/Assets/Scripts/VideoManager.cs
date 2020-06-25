using cakeslice;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviourPun, IPunObservable, IPunOwnershipCallbacks
{
    public int version = 1; // 1=first 2=second
    public int[] isPlaying=new int[19];
    List<GameObject> vids;

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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsReading) // rec
        {
            for (int i = 0; i < isPlaying.Length; i++)
                isPlaying[i] = (int)stream.ReceiveNext();
            for (int i = 0; i < isPlaying.Length; i++)
                if (isPlaying[i] > 0)
                {
                    GameObject go = vids.Find(x => x.name.Equals("Video" + i.ToString()));
                    go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                    go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
                    if (version.Equals(2))
                    {
                        go.GetComponent<VideoPlayer>().Play();
                    }
                }
        }
        else if (stream.IsWriting) //send
        {
            for (int i = 0; i < isPlaying.Length; i++)
                stream.SendNext(isPlaying[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        vids = FindInActiveObjectsByTag("Video");
        Debug.LogError("Videos are " + vids.Count);
        /*PhotonNetwork.SendRate = 40;
        PhotonNetwork.SerializationRate = 40;*/
    }

    public void ReqAndPlay(bool PlayPause,int i)
    {
        if (PlayPause)
        {
            //isPlaying[i]++;
            this.photonView.RPC("Play", RpcTarget.All, i);
        }
        else
        {
            //isPlaying[i]--;
            this.photonView.RPC("Pause", RpcTarget.All, i);
        }
        /*Debug.LogError(base.photonView.Owner +" is owner");
        base.photonView.RequestOwnership();
        GameObject go = vids.Find(x => x.name.Equals("Video" + i.ToString()));
        Debug.LogError("b4 " + photonView.IsMine + " " + go.name + " " + isPlaying[i] + " " + PlayPause);
        if (PlayPause)
        {
            isPlaying[i]=isPlaying[i]+1;
            go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
        }
        else
        {
            isPlaying[i] = isPlaying[i] - 1;
            if (isPlaying[i] == 0)
            {
                go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            }
        }
        //Debug.LogError("after "+photonView.IsMine + " " + go.name + " " + isPlaying[i] + " " + PlayPause);*/

    }

    [PunRPC]
    void Play(int paint)
    {
        isPlaying[paint]++;
        if (isPlaying[paint] > 0)
        {
            GameObject go = vids.Find(x => x.name.Equals("Video" + paint.ToString()));
            go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
            if (version.Equals(2))
            {
                go.GetComponent<VideoPlayer>().Play();
            }
        }
    }

    [PunRPC]
    void Pause(int paint)
    {
        isPlaying[paint]--;
        if (isPlaying[paint] == 0)
        {
            GameObject go = vids.Find(x => x.name.Equals("Video" + paint.ToString()));
            go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            if (version.Equals(2))
            {
                go.GetComponent<VideoPlayer>().Pause();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(isPlaying[2]);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        Debug.LogError(requestingPlayer + " requested");
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.LogError(previousOwner + " given");
    }
}
