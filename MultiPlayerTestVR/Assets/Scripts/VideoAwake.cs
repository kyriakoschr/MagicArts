﻿using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAwake : MonoBehaviour {
	GameObject videoManager;
	VideoPlayer vp;
	MMManger mmm;

	// Use this for initialization
	void Start () {
		videoManager = GameObject.Find("VideoManager");
		mmm = GameObject.Find("MultiMediaManager").GetComponent<MMManger>();
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
			mmm.listRemove(this.gameObject, 2, painting);
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]--;*/
			videoManager.GetComponent<VideoManager>().ReqAndPlay(false, painting);
		}
		else
		{
			MMManger.LObject rem = mmm.insertInList(this.gameObject, 2, painting);
			if (rem != null)
			{
				if (rem.getAV().Equals(1))
				{
					rem.getGo().GetComponent<AudioSource>().Pause();
					GameObject.Find("AudioManager").GetComponent<AudioManager>().ReqAndPlay(false, rem.getNo());
				}
				else
				{
					rem.getGo().GetComponent<VideoPlayer>().Pause();
					videoManager.GetComponent<VideoManager>().ReqAndPlay(false, rem.getNo());
				}
			}
			vp.Play();
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]++;*/
			videoManager.GetComponent<VideoManager>().ReqAndPlay(true, painting);
		}
	}
}
