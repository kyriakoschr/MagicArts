using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnableAnimation : MonoBehaviour
{
    public int cntr;
    // Start is called before the first frame update
    void Start()
    {
        cntr = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator videowait(GameObject go)
    {
        yield return new WaitForSeconds((float)go.GetComponent<VideoPlayer>().clip.length);
        go.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
        //go.GetComponent<cakeslice.Outline>().enabled = false;
        go.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        cntr++;
        if (cntr == 1)
        {
            GameObject VideoToAnimate = null;
            if (this.transform.parent.name == "paint11")
                VideoToAnimate = this.transform.parent.transform.Find("VideoFirstSteps").gameObject;
            else if (this.transform.parent.name == "paint10")
                VideoToAnimate = this.transform.parent.transform.Find("VideoCafe").gameObject;
            else if (this.transform.parent.name == "paint5")
                VideoToAnimate = this.transform.parent.transform.Find("VideoPotato").gameObject;
            if (!VideoToAnimate.GetComponent<VideoPlayer>().isPlaying)
            {
                VideoToAnimate.SetActive(true);
                VideoToAnimate.GetComponent<VideoPlayer>().Play();
                VideoToAnimate.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
                //VideoToAnimate.GetComponent<cakeslice.Outline>().enabled = true;
                StartCoroutine(videowait(VideoToAnimate));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        cntr--;
        if (cntr == 0)
        {
            GameObject VideoToAnimate = null;
            if (this.transform.parent.name == "paint11")
                VideoToAnimate = this.transform.parent.transform.Find("VideoFirstSteps").gameObject;
            else if (this.transform.parent.name == "paint10")
                VideoToAnimate = this.transform.parent.transform.Find("VideoCafe").gameObject;
            else if (this.transform.parent.name == "paint5")
                VideoToAnimate = this.transform.parent.transform.Find("VideoPotato").gameObject;
            VideoToAnimate.GetComponent<VideoPlayer>().Pause();
            VideoToAnimate.GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
            //VideoToAnimate.GetComponent<cakeslice.Outline>().enabled = false;
            VideoToAnimate.SetActive(false);
        }
    }
}
