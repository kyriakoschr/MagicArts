using cakeslice;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviourPun, IPunObservable, IPunOwnershipCallbacks
{
    int version; // 1=first 2=second
    public int[] isPlaying=new int[19];
    List<GameObject> vids;
    
    MMManger mmm;

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

        mmm = GameObject.Find("MultiMediaManager").GetComponent<MMManger>();
        version = mmm.Version;
        /*PhotonNetwork.SendRate = 40;
         PhotonNetwork.SerializationRate = 40;*/
    }

    public void ReqAndPlay(bool PlayPause,int i)
    {
        if (PlayPause)
        {
            //isPlaying[i]++;
            this.photonView.RPC("Play", RpcTarget.All, i, PhotonNetwork.LocalPlayer.UserId);
        }
        else
        {
            //isPlaying[i]--;
            this.photonView.RPC("Pause", RpcTarget.All, i, PhotonNetwork.LocalPlayer.UserId);
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

    IEnumerator timer(double t, VideoPlayer go, int painting)
    {
        yield return new WaitForSeconds((float)t);
        //if (go.transform.parent.parent.GetComponent<MouseOver2>().outlineMaterial.GetFloat("_OutlineEnabled").Equals(1.0f))
        go.frame = 2;
        go.Pause();
        go.frame = 2;
    }

    [PunRPC]
    void Play(int paint, string usr)
    {
        isPlaying[paint]++;
        if (isPlaying[paint] > 0)
        {
            GameObject go = vids.Find(x => x.name.Equals("Video" + paint.ToString()));
            VideoPlayer vp = go.GetComponent<VideoPlayer>();
            go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
            Debug.Log("HHERERERERE");
            if (version.Equals(2) && !usr.Equals(PhotonNetwork.LocalPlayer.UserId)) //here is the bug
            {
                go.GetComponent<VideoPlayer>().Play();
                Debug.Log("Playing on 2nd");
                mmm.insertInList(go, 2, paint, StartCoroutine(timer(vp.length - vp.time, vp, paint)));
                Debug.Log(mmm.length() +" is len");
            }
        }
    }

    [PunRPC]
    void Pause(int paint, string usr)
    {
        isPlaying[paint]--;
        if (isPlaying[paint] <= 0)
        {
            isPlaying[paint] = 0;
            GameObject go = vids.Find(x => x.name.Equals("Video" + paint.ToString()));
            go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            if (version.Equals(2) && !usr.Equals(PhotonNetwork.LocalPlayer.UserId))
            {
                mmm.listRemove(go, 2, paint);
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
