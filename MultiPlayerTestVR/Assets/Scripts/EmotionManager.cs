using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionManager : MonoBehaviourPun
{
    List<GameObject> FindInActiveObjectsByTag(string tag, Transform parent)
    {
        List<GameObject> validTransforms = new List<GameObject>();
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].gameObject.CompareTag(tag) && objs[i].parent.parent.Equals(parent))
                {
                    validTransforms.Add(objs[i].gameObject);
                }
            }
        }
        return validTransforms;
    }

    public GameController gc;
    public float secsForFeeling = 30;

    public void addFeel(int feeling)
    {
        this.photonView.RPC("addFeeling", RpcTarget.All, gc.myLocalPlayer.GetComponent<PhotonView>().ViewID, feeling);
    }

    [PunRPC]
    public void addFeeling(int player, int feeling) 
    {
        GameObject play = PhotonView.Find(player).gameObject;
        List<GameObject> bubbles = FindInActiveObjectsByTag("Bubble", play.transform);
        switch (feeling)
        {
            case 0:
                bubbles.Find(x => x.name.Equals("smilecloud")).gameObject.SetActive(true);
                StartCoroutine(timer(bubbles.Find(x => x.name.Equals("smilecloud")).gameObject));
                break;
            case 1:
                bubbles.Find(x => x.name.Equals("wowcloud")).gameObject.SetActive(true);
                StartCoroutine(timer(bubbles.Find(x => x.name.Equals("wowcloud")).gameObject));
                break;
            case 2:
                bubbles.Find(x => x.name.Equals("neutralcloud")).gameObject.SetActive(true);
                StartCoroutine(timer(bubbles.Find(x => x.name.Equals("neutralcloud")).gameObject));
                break;
            case 3:
                bubbles.Find(x => x.name.Equals("sadcloud")).gameObject.SetActive(true);
                StartCoroutine(timer(bubbles.Find(x => x.name.Equals("sadcloud")).gameObject));
                break;
            case 4:
                bubbles.Find(x => x.name.Equals("angrycloud")).gameObject.SetActive(true);
                StartCoroutine(timer(bubbles.Find(x => x.name.Equals("angrycloud")).gameObject));
                break;
        }
    }

    IEnumerator timer( GameObject go)
    {
        yield return new WaitForSeconds(secsForFeeling);
        //if (go.transform.parent.parent.GetComponent<MouseOver2>().outlineMaterial.GetFloat("_OutlineEnabled").Equals(1.0f))
        go.SetActive(false);
    }
    /*public enum Emotion
    {
        Happy,
        Sad,
        Wow,
        Angry,
        Neutral
    }

    Dictionary<Player, List<Emotion>> feelings = new Dictionary<Player, List<Emotion>>();

    public void AddFeeling( int emotion)
    {
        this.photonView.RPC("Add", RpcTarget.All, PhotonNetwork.LocalPlayer ,emotion);
    }

    public void RemoveFeeling( int emotion)
    {
        this.photonView.RPC("Remove", RpcTarget.All, PhotonNetwork.LocalPlayer, emotion);
    }

    *//*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsReading) // rec
        {
            feelings = (Dictionary<Player,List<Emotion>>)stream.ReceiveNext();
        }
        else //sender
        {
            stream.SendNext(feelings);
        }

    }*//*

    [PunRPC]
    void Add(Player player, int emotion)
    {
        feelings[player].Add((Emotion)emotion);
    }

    [PunRPC]
    void Remove(Player player,int emotion)
    {
        feelings[player].Remove((Emotion)emotion);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach(Player p in feelings.Keys)
        {
            foreach (Emotion e in feelings[p])
                Debug.LogError("Player "+p+" feels "+e);
        }
    }

    public void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        throw new System.NotImplementedException();
    }

    public void OnCreatedRoom()
    {
        throw new System.NotImplementedException();
    }

    public void OnCreateRoomFailed(short returnCode, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnJoinedRoom()
    {
        Debug.Log("ENTERED ROOM");
        feelings.Add(PhotonNetwork.LocalPlayer, new List<Emotion>());
    }

    public void OnJoinRoomFailed(short returnCode, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnJoinRandomFailed(short returnCode, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnLeftRoom()
    {
        feelings.Remove(PhotonNetwork.LocalPlayer);
    }*/

    /*public void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("ENTERED ROOM");
        feelings.Add(newPlayer, new List<Emotion>());
    }

    public void OnPlayerLeftRoom(Player otherPlayer)
    {
        feelings.Remove(otherPlayer);
    }

    public void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        throw new System.NotImplementedException();
    }

    public void OnMasterClientSwitched(Player newMasterClient)
    {
        throw new System.NotImplementedException();
    }*/
}
