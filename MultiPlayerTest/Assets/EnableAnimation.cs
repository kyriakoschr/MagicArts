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
        go.GetComponent<cakeslice.Outline>().enabled = false;
        go.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        cntr++;
        if (cntr == 1)
        {
            GameObject VideoToAnimate = null;
            if (name=="paint11")
                VideoToAnimate = transform.Find("VideoFirstSteps").gameObject;
            else if(name == "paint10")
                VideoToAnimate = transform.Find("VideoCafe").gameObject;
            else if(name == "paint5")
                VideoToAnimate = transform.Find("VideoPotato").gameObject;
            if (!VideoToAnimate.GetComponent<VideoPlayer>().isPlaying)
            {
                VideoToAnimate.SetActive(true);
                VideoToAnimate.GetComponent<VideoPlayer>().Play();
                VideoToAnimate.GetComponent<cakeslice.Outline>().enabled = true;
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
            if (name == "paint11")
                VideoToAnimate = transform.Find("VideoFirstSteps").gameObject;
            else if (name == "paint10")
                VideoToAnimate = transform.Find("VideoCafe").gameObject;
            else if (name == "paint5")
                VideoToAnimate = transform.Find("VideoPotato").gameObject;
            VideoToAnimate.GetComponent<VideoPlayer>().Pause();
            VideoToAnimate.GetComponent<cakeslice.Outline>().enabled = false;
            VideoToAnimate.SetActive(false);
        }
    }
}
    