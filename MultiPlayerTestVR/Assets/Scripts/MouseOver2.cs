using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace cakeslice
{
    public class MouseOver2 : MonoBehaviour {
        public GameObject vvideo = null;
        public GameObject aaudio = null;
        public GameObject Menu = null;
        public GameObject Canvas = null;
        public GameObject inputCntrls = null;
        private Outline go;
        public Material outlineMaterial;
        private bool over = false;
        public int b;
        public ZoomFunctions zf;
        public GameObject sim;
        public Zinnia.Action.ToggleAction togleAction;

        public void greenOutline(int nval)
        {
            b = nval;
        }

        void Start(){
            //go = GetComponentInParent<Outline>();
            //go.enabled = false;
            zf = GameObject.Find("ZoomFunctions").GetComponent<ZoomFunctions>();
            if (this.CompareTag("Video"))
            {
                outlineMaterial = new Material(this.GetComponent<MeshRenderer>().material);
                this.GetComponent<MeshRenderer>().material = outlineMaterial;
                outlineMaterial.SetColor("_SolidOutline", Color.green);
                outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            }
            else
            {
                outlineMaterial = new Material(this.GetComponent<SpriteRenderer>().material);
                this.GetComponent<SpriteRenderer>().material = outlineMaterial;
                if (GetComponent<VideoPlayer>() == null)
                {
                    outlineMaterial.SetColor("_SolidOutline", Color.red);
                    outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
                }
                else
                    outlineMaterial.SetColor("_SolidOutline", Color.green);
            }
//            outlineShader = outlineMaterial.shader;
        }

        void Awake()
        {
            //go = GetComponentInParent<Outline>();
            //go.enabled = false;
            if (this.CompareTag("Video"))
            {
                outlineMaterial = new Material(this.GetComponent<MeshRenderer>().material);
                this.GetComponent<MeshRenderer>().material = outlineMaterial;
                outlineMaterial.SetColor("_SolidOutline", Color.green);
                outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            }
            else
            {
                outlineMaterial = new Material(this.GetComponent<SpriteRenderer>().material);
                this.GetComponent<SpriteRenderer>().material = outlineMaterial;
                if (GetComponent<VideoPlayer>() == null)
                {
                    outlineMaterial.SetColor("_SolidOutline", Color.red);
                    outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
                }
                else
                    outlineMaterial.SetColor("_SolidOutline", Color.green);
            }
            //            outlineShader = outlineMaterial.shader;
        }

        private void OnCollisionEnter(Collision collision)
        {
            
        Debug.Log("TRIGGEREd");
        }

        public void KokosIn() {
            Debug.Log("In");
            if (GameObject.FindGameObjectWithTag("Menu"))
                return;
            if (this.name.Equals("Video")||GetComponent<VideoPlayer>() != null)
                return;
            over = true;
            /*if (!go.enabled)
            {
                go.color = 0;
                go.enabled = true;
            }*/
            if (outlineMaterial.GetFloat("_OutlineEnabled").Equals(0.0f))
            {
                outlineMaterial.SetColor("_SolidOutline",Color.red);
                outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
            }
        }

        public void OpenMenu()
        {
            Debug.Log("Open");
            if (Menu.activeInHierarchy) {
                if (!sim.activeInHierarchy)
                {
                    Cursor.visible = true;
                    togleAction.Receive(true);
                    Canvas.SetActive(true);
                    inputCntrls.SetActive(false);
                }
                else
                    zf.EnableDisable();
            }
            else
                Menu.SetActive(true);
        }
        public void KokosOut() {
            Debug.Log("Out");
            if (GameObject.FindGameObjectWithTag("Menu"))
                return;
            if (this.name.Equals("Video")||GetComponent<VideoPlayer>() != null)
                return;
            over = true;
            /*if (!go.enabled)
            {
                go.color = 0;
                go.enabled = true;
            }*/
            if (outlineMaterial.GetFloat("_OutlineEnabled").Equals(1.0f)&& !outlineMaterial.GetColor("_SolidOutline").Equals(Color.green))
            {
                outlineMaterial.SetColor("_SolidOutline",Color.red);
                outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            }
        }

        void OnMouseExit () {
            if (this.name.Equals("Video")||GetComponent<VideoPlayer>() != null)
                return;
            over = false;
            Debug.Log("WTERERE");
            bool flag = false;
            //if (go.color == 0)
            //    go.enabled = false;
            if (outlineMaterial.GetColor("_SolidOutline").Equals(Color.red))
                outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);

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

        /*[Command]
        void CmdOutline(bool on, int color)
        {
            RpcOutline(on, color);
        }

        [ClientRpc]
        void RpcOutline(bool on, int color)
        {
            //go = GetComponentInParent<Outline>();
            if (color == 1)
                outlineMaterial.SetColor("_SolidOutline", Color.green);
            else
                outlineMaterial.SetColor("_SolidOutline", Color.red);
            outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
            //go.color = color;
            //go.enabled = on;
        }*/
    }
}