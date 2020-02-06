using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAwake : MonoBehaviour {

	VideoPlayer vp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		vp = GetComponent<VideoPlayer> ();
		vp.Play ();
		vp.Pause ();
	}
}
