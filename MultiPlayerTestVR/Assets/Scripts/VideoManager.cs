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
            //for (int i = 0; i < isPlaying.Length; i++)
                isPlaying[2] = (int)stream.ReceiveNext();
            /*for (int ind = 0; ind < vids.Count; ind++)
            {
                GameObject video = vids.Find(x => x.name.Equals("Video" + ind.ToString()));*/
                GameObject video = vids.Find(x => x.name.Equals("Video2"));
                /*if (video.GetComponent<MouseOver2>() == null||video.GetComponent<VideoPlayer>()==null)
                    continue;*/
                if (isPlaying[2] > 0)
                //if (isPlaying[ind] > 0)
                {
                    Debug.LogError("video2 has " + isPlaying[2]);
                    video.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                    video.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
                    if (version.Equals(2))
                    {
                        video.GetComponent<VideoPlayer>().Play();
                    }
                }
                else
                {
                    Debug.LogError("video2 has " + isPlaying[2]);
                    video.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                    video.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
                    if (version.Equals(2))
                    {
                        video.GetComponent<VideoPlayer>().Pause();
                    }
                }
            //}
        }
        else if (stream.IsWriting) //send
        {
            //for (int i = 0; i < isPlaying.Length; i++)
                stream.SendNext(isPlaying[2]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        vids = FindInActiveObjectsByTag("Video");
        Debug.LogError("Videos are " + vids.Count);
        PhotonNetwork.SendRate = 40;
        PhotonNetwork.SerializationRate = 40;
    }

    public void ReqAndPlay(bool PlayPause,int i)
    {
        Debug.LogError(base.photonView.Owner +" is owner");
        base.photonView.RequestOwnership();
        /*GameObject go = vids.Find(x => x.name.Equals("Video" + i.ToString()));
        Debug.LogError("b4 " + photonView.IsMine + " " + go.name + " " + isPlaying[i]+" " + PlayPause);*/
        if (PlayPause)
        {
            isPlaying[i]=isPlaying[i]+1;
            /*go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);*/
        }
        else
        {
            isPlaying[i] = isPlaying[i] - 1;
            /*if (isPlaying[i] == 0)
            {
                go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            }*/
        }
        //Debug.LogError("after "+photonView.IsMine + " " + go.name + " " + isPlaying[i] + " " + PlayPause);
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
