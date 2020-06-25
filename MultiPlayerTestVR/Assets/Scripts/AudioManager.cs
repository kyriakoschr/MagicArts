using cakeslice;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviourPun, IPunObservable
{
    public int version = 1; // 1=first 2=second
    public int[] isPlaying = new int[19];
    List<GameObject> audios;
    List<GameObject> paintings;
    
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
        Debug.Log(string.Format("Audios are {0} and paintigs are {1} ", audios.Count, paintings.Count));
    }
    public void ReqAndPlay(bool PlayPause, int i)
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
    }

    [PunRPC]
    void Play(int paint)
    {
        isPlaying[paint]++;
        if (isPlaying[paint] > 0)
        {
            GameObject audio = audios.Find(x => x.name.Equals("AudioSource" + paint.ToString()));
            GameObject painting = paintings.Find(x => x.name.Equals("paint" + paint.ToString()));
            Debug.Log(audio.name + " " + painting.name);
            painting.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            painting.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
            if (version.Equals(2))
            {
                audio.GetComponent<AudioSource>().Play();
            }
        }
    }

    [PunRPC]
    void Pause(int paint)
    {
        isPlaying[paint]--;
        if (isPlaying[paint] <= 0)
        {
            isPlaying[paint] = 0;
            GameObject audio = audios.Find(x => x.name.Equals("AudioSource" + paint.ToString()));
            GameObject painting = paintings.Find(x => x.name.Equals("paint" + paint.ToString()));
            painting.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
            painting.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            if (version.Equals(2))
            {
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
