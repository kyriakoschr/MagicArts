using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAwake : MonoBehaviour {
	GameObject videoManager;
	VideoPlayer vp;
	// Use this for initialization
	void Start () {
		videoManager = GameObject.Find("VideoManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		vp = GetComponent<VideoPlayer> ();
		vp.Play ();
		vp.Pause ();
	}

	public void PlayPause(int painting)
    {
		if (vp.isPlaying)
		{
			vp.Pause();
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]--;*/
			videoManager.GetComponent<VideoManager>().ReqAndPlay(false, painting);
		}
		else
		{
			vp.Play();
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]++;*/
			videoManager.GetComponent<VideoManager>().ReqAndPlay(true, painting);
		}
	}
}
