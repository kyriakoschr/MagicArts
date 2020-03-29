using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;

namespace cakeslice
{
    public class MouseOver2 : NetworkBehaviour {
        public GameObject vvideo = null;
        public GameObject aaudio = null;
        private Outline go;
        private bool over = false;
        [SyncVar(hook = "greenOutline")]
        public int b;

        public void greenOutline(int nval)
        {
            b = nval;
        }

        void Start(){
            go = GetComponentInParent<Outline>();
            go.enabled = false;
	    }

        void OnMouseOver() {
            over = true;
            if (!go.enabled)
            {
                go.color = 0;
                go.enabled = true;
            }
            /*if(vvideo!= null||aaudio!=null)
            {
                if(!aaudio.GetComponent<AudioSource>().isPlaying)
                {
                    //Debug.Log("LAMPIKE" + vvideo.GetComponent<VideoPlayer>().isPlaying);
                    //CmdOutline(false, 0);
                    if (go.enabled == false)
                    {
                        go.color = 0;
                        go.enabled = true;
                    }
                }
                else if (!vvideo.GetComponent<VideoPlayer>().isPlaying)
                {
                    //Debug.Log("LAMPIKE" + vvideo.GetComponent<VideoPlayer>().isPlaying);
                    //CmdOutline(true, 0);
                    if (go.enabled == false)
                    {
                        go.color = 0;
                        go.enabled = true;
                    }
                }
            }*/
            /*else
            {
                //Debug.Log("LAMPIKE" + vvideo.GetComponent<VideoPlayer>().isPlaying);
                CmdOutline(true, 0);
                go.color = 0;
                go.enabled = true;
            }
            if (!(vvideo != null && vvideo.GetComponent<VideoPlayer>().isPlaying) && !(aaudio != null && aaudio.GetComponent<AudioSource>().isPlaying))
            {
                Debug.Log("LAMPIKE" + vvideo.GetComponent<VideoPlayer>().isPlaying);
                go.color = 0;
                go.enabled = true;
            }*/
        }

        void OnMouseExit () {
            over = false;
            Debug.Log("WTERERE");
            bool flag = false;
            if (go.color == 0)
                go.enabled = false;
            /*if (aaudio != null)
            {
                Debug.Log("WTERERE2");
                if (go.color==1)
                {
                    flag = true;

                }
            }
            if (!flag && vvideo != null)
            {
                if (vvideo.GetComponent<VideoPlayer>().isPlaying)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                go.color = 0;
                go.enabled = false;

            }
            */
/*            if (!aaudio.GetComponent<AudioSource>().isPlaying)
                {
                    Debug.Log("WTERERE3");

                    //Debug.Log("LAMPIKE" + vvideo.GetComponent<VideoPlayer>().isPlaying);
                    //CmdOutline(false, 0);
                    go.color = 0;
                    go.enabled = false;
                }
                else if (!vvideo.GetComponent<VideoPlayer>().isPlaying)
                {
                    //Debug.Log("LAMPIKE" + vvideo.GetComponent<VideoPlayer>().isPlaying);
                    //CmdOutline(false, 0);
                    Debug.Log("WTERERE4");
                    go.color = 0;
                    go.enabled = false;
                }
            }
            Debug.Log("WTERERE5");
*/
            /*else
            {
                //Debug.Log("LAMPIKE" + vvideo.GetComponent<VideoPlayer>().isPlaying);
                CmdOutline(false, 0);
                go.color = 0;
                go.enabled = false;
            }
            if (!(vvideo != null && vvideo.GetComponent<VideoPlayer>().isPlaying) && !(aaudio != null && aaudio.GetComponent<AudioSource>().isPlaying))
            {
                Debug.Log("LAMPIKE" + vvideo.GetComponent<VideoPlayer>().isPlaying);
                go.color = 0;
                go.enabled = true;
            }*/
        }

        void Update()
        {
            /*if (aaudio!=null)
            {
                if (aaudio.GetComponent<AudioSource>().isPlaying)
                {
                    CmdOutline(true, 1);
                }
                else if (vvideo != null && vvideo.GetComponent<VideoPlayer>().isPlaying)
                {
                    CmdOutline(true, 1);
                }
                else if (!over)
                {
                    go.color = 0;
                    go.enabled = false;
                }
                else if (over)
                {
                    go.color = 0;
                    go.enabled = true;
                }
            }*/
        }

        [Command]
        void CmdOutline(bool on, int color)
        {
            RpcOutline(on, color);
        }

        [ClientRpc]
        void RpcOutline(bool on, int color)
        {
            go = GetComponentInParent<Outline>();
            go.color = color;
            go.enabled = on;
        }
    }
}