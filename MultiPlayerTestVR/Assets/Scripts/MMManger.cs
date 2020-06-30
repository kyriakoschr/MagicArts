using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class MMManger : MonoBehaviour
{
    public class LObject
    {
        int number;
        int audioVideo;
        GameObject go;
        Coroutine corout;

        public int getAV()
        {
            return audioVideo;
        }
        public int getNo()
        {
            return number;
        }

        public Coroutine getCo()
        {
            return corout;
        }

        public GameObject getGo()
        {
            return go;
        }

        public void setAv(int av)
        {
            audioVideo = av;
        }

        public void setNo(int no)
        {
            number = no;
        }
        
        public void setCo(Coroutine co)
        {
            corout = co;
        }

        public void setGo(GameObject gobj)
        {
            go = gobj;
        }
    }

    public int Version = 1;
    List<LObject> currentlyPlayingLocally = new List<LObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int length()
    {
        return currentlyPlayingLocally.Count;
    }

    public void listRemove(GameObject go,int av,int no)
    {
        Debug.Log("length is " + currentlyPlayingLocally.Count);
        LObject lo = currentlyPlayingLocally.Find(x => x.getAV().Equals(av) && x.getNo().Equals(no));
        Debug.Log(lo.getAV() + " " + lo.getGo()+" "+lo.getNo());
        StopCoroutine(lo.getCo());
        currentlyPlayingLocally.Remove(lo);
    }

    public LObject insertInList(GameObject media,int av,int no,Coroutine co)
    {
        LObject newObj = new LObject();
        newObj.setAv(av);
        newObj.setGo(media);
        newObj.setNo(no);
        newObj.setCo(co);
        LObject ret =null;
        if (Version.Equals(1)&&currentlyPlayingLocally.Count>0)
        {
            ret = currentlyPlayingLocally[0];
            StopCoroutine(ret.getCo());
            currentlyPlayingLocally.RemoveAt(0);
        }
        currentlyPlayingLocally.Add(newObj);
        return ret;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
