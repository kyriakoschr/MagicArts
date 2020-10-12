using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnableAnimation : MonoBehaviour
{
    public int cntr;
    public GameController gc;
    public MMManger mmm;
    GameObject VideoToAnimate = null;
    VideoPlayer vp = null;

    // Start is called before the first frame update
    void Start()
    {
        cntr = 0;
        if (this.transform.parent.name == "paint11")
            VideoToAnimate = this.transform.parent.transform.Find("VideoFirstSteps").gameObject;
        else if (this.transform.parent.name == "paint10")
            VideoToAnimate = this.transform.parent.transform.Find("VideoCafe").gameObject;
        else if (this.transform.parent.name == "paint5")
            VideoToAnimate = this.transform.parent.transform.Find("VideoPotato").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (VideoToAnimate.activeSelf)
        {
            float dist = Vector3.Distance(VideoToAnimate.transform.position, gc.myLocalPlayer.transform.Find("Head").transform.position);
            float vlm;
            if (dist < 25)
                vlm = 1f;
            else if (dist < 50)
                vlm = 0.7f;
            else if (dist < 100)
                vlm = 0.4f;
            else
                vlm = 0.1f;
            vp = VideoToAnimate.GetComponent<VideoPlayer>();
            if(VideoToAnimate.name.Equals("VideoFirstSteps"))
                vp.GetTargetAudioSource(0).volume = vlm/3;
            else    
                vp.GetTargetAudioSource(0).volume = vlm;
        }
    }

    IEnumerator videowait(GameObject go)
    {
        yield return new WaitForSeconds((float)go.GetComponent<VideoPlayer>().clip.length);
        go.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
        go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
        go.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.LogError(other.name);
        if (!other.name.Equals("DefaultCollider"))
        {
            cntr++;
            if (cntr == 1)
            {
                if (!VideoToAnimate.GetComponent<VideoPlayer>().isPlaying)
                {
                    VideoToAnimate.SetActive(true);
                    VideoToAnimate.GetComponent<VideoPlayer>().Play();
                    VideoToAnimate.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                    VideoToAnimate.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
                    //StartCoroutine(videowait(VideoToAnimate));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.name.Equals("DefaultCollider"))
        {
            cntr--;
            if (cntr == 0)
            {
                VideoToAnimate.GetComponent<VideoPlayer>().Pause();
                VideoToAnimate.GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
                VideoToAnimate.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
                VideoToAnimate.SetActive(false);
            }
        }
    }
}
    