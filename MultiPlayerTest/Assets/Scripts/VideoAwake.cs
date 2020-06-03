using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAwake : MonoBehaviour {
    bool started = true;

    VideoPlayer vp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log((ulong)vp.frame + " " + vp.frameCount);
        if (vp.frame == 4 && started)
        {
            started = false;
            vp.Pause();
        }
    }

    private void OnBecameVisible()
    {
        vp = GetComponent<VideoPlayer>();
        /*vp.Play();*/
        //vp.Pause ();
    }
    void Awake(){
        Debug.Log("awaken");
        vp = GetComponent<VideoPlayer> ();
        /*vp.Play();
        vp.Pause ();*/
	}
}
