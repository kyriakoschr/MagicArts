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

        public int getAV()
        {
            return audioVideo;
        }
        public int getNo()
        {
            return number;
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

    public void listRemove(GameObject go,int av,int no)
    {
        currentlyPlayingLocally.RemoveAll(x => x.getAV().Equals(av) && x.getGo().Equals(go) && x.getNo().Equals(no));
    }

    public LObject insertInList(GameObject media,int av,int no)
    {
        LObject newObj = new LObject();
        newObj.setAv(av);
        newObj.setGo(media);
        newObj.setNo(no);
        LObject ret =null;
        if (Version.Equals(1)&&currentlyPlayingLocally.Count>0)
        {
            ret = currentlyPlayingLocally[0];
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
