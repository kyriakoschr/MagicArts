using cakeslice;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviourPun, IPunObservable
{
    int version ; // 1=first 2=second
    public int[] isPlaying = new int[19];
    List<GameObject> audios;
    List<GameObject> paintings;

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

    // Start is called before the first frame update
    void Start()
    {
        audios = FindInActiveObjectsByTag("Sound");
        paintings = FindInActiveObjectsByTag("Image");

        mmm = GameObject.Find("MultiMediaManager").GetComponent<MMManger>();
        version = mmm.Version;
        Debug.Log(string.Format("Audios are {0} and paintigs are {1} ", audios.Count, paintings.Count));
    }
    
    public void ReqAndPlay(bool PlayPause, int i)
    {
        if (PlayPause)
        {
            //isPlaying[i]++;
            this.photonView.RPC("Play", RpcTarget.All, i,PhotonNetwork.LocalPlayer.UserId);
        }
        else
        {
            //isPlaying[i]--;
            this.photonView.RPC("Pause", RpcTarget.All, i, PhotonNetwork.LocalPlayer.UserId);
        }
    }

    IEnumerator timer(double t, AudioSource go, int painting)
    {
        yield return new WaitForSeconds((float)t);
        //if (go.transform.parent.parent.GetComponent<MouseOver2>().outlineMaterial.GetFloat("_OutlineEnabled").Equals(1.0f))
        go.Stop();
        go.time = 0;
    }

    [PunRPC]
    void Play(int paint,string usr)
    {
        isPlaying[paint]++;
        if (isPlaying[paint] > 0)
        {
            GameObject audio = audios.Find(x => x.name.Equals("AudioSource" + paint.ToString()));
            GameObject painting = paintings.Find(x => x.name.Equals("paint" + paint.ToString()));
            AudioSource vp = audio.GetComponent<AudioSource>();
            Debug.Log(audio.name + " " + painting.name);
            if (paint.Equals(8))
            {
                GameObject painting81 = paintings.Find(x => x.name.Equals("paint8(1)"));
                painting81.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                painting81.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
            }
            painting.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            painting.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
            if (version.Equals(2) && !usr.Equals(PhotonNetwork.LocalPlayer.UserId))
            {
                audio.GetComponent<AudioSource>().Play();
                mmm.insertInList(audio, 1, paint, StartCoroutine(timer(vp.clip.length - vp.time, vp, paint)));
            }
        }
    }

    [PunRPC]
    void Pause(int paint,string usr)
    {
        isPlaying[paint]--;
        GameObject audio = audios.Find(x => x.name.Equals("AudioSource" + paint.ToString()));
        GameObject painting = paintings.Find(x => x.name.Equals("paint" + paint.ToString()));

        AudioSource vp = audio.GetComponent<AudioSource>();
        if (isPlaying[paint] <= 0)
        {
            isPlaying[paint] = 0;
            if (paint.Equals(8))
            {
                GameObject painting81 = paintings.Find(x => x.name.Equals("paint8(1)"));
                painting81.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                painting81.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            }
            painting.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            painting.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            if (version.Equals(2) && !usr.Equals(PhotonNetwork.LocalPlayer.UserId))
            {
                mmm.listRemove(audio, 1, paint);
                audio.GetComponent<AudioSource>().Pause();
            }
        }
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
                    GameObject audio = audios.Find(x => x.name.Equals("AudioSource" + i.ToString()));
                    GameObject painting = paintings.Find(x => x.name.Equals("paint" + i.ToString()));
                    painting.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                    painting.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
                    if (version.Equals(2))
                    {
                        audio.GetComponent<AudioSource>().Play();
                    }
                }
        }
        else if (stream.IsWriting) //send
        {
            for (int i = 0; i < isPlaying.Length; i++)
                stream.SendNext(isPlaying[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
