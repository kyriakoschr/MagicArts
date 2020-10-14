using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAwake : MonoBehaviour {
	bool started = true;
	GameObject videoManager;
	VideoPlayer vp;
	MMManger mmm;
	public GameController gc;
	GameObject mplayer;
	InitPPlayer initpp;
	AudioSource voiceSpeaker;

	// Use this for initialization
	void Start () {
		videoManager = GameObject.Find("VideoManager");
		mmm = GameObject.Find("MultiMediaManager").GetComponent<MMManger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mplayer == null)
		{
			mplayer = gc.myLocalPlayer;
			/*initpp = gc.myLocalPlayer.GetComponent<InitPPlayer>();*/
		}
		if (voiceSpeaker == null)
			voiceSpeaker = mplayer.transform.Find("Speaker").GetComponent<AudioSource>();
		if (started && vp.isPlaying && vp.isPrepared)
		{
			started = false;
			vp.frame = 4;
			vp.Pause();
			vp.frame = 4;
		}
		if (vp.isPlaying)
		{
			float dist = Vector3.Distance(gameObject.transform.Find("VideoIcon").position, mplayer.transform.Find("Head").transform.position);
			float vlm;
			if (dist < 25)
                vlm = 1f;
            else if (dist < 50)
                vlm = 0.7f;
            else if (dist < 100)
                vlm = 0.4f;
            else
                vlm = 0.1f;
			if (voiceSpeaker.isPlaying)
				vlm *= 0.5f;
			vp.GetTargetAudioSource(0).volume= vlm;
		}
	}

	private void OnBecameVisible()
	{
		vp = GetComponent<VideoPlayer>();
		/*vp.Play();*/
		//vp.Pause ();
	}
	
	void Awake()
	{
		Debug.Log("awaken");
		vp = GetComponent<VideoPlayer>();
		/*vp.Play();
        vp.Pause ();*/
	}

	public void PlayPause(int painting)
    {
		Debug.Log(vp.clip);
		if (vp.isPlaying)
		{
			Debug.Log("IS PLAYING");
			vp.Pause();
			mmm.listRemove(this.gameObject, 2, painting);
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]--;*/
			videoManager.GetComponent<VideoManager>().ReqAndPlay(false, painting);
			videoManager.GetComponent<VideoManager>().hp--;
			videoManager.GetComponent<VideoManager>().hmd--;
			if (mmm.Version.Equals(1))
			{
				if (videoManager.GetComponent<VideoManager>().hmd > 0)
					gc.GetComponent<EmotionManager>().addHMD();
				else
					gc.GetComponent<EmotionManager>().removeHMD();
				if (videoManager.GetComponent<VideoManager>().hp > 0)
					gc.GetComponent<EmotionManager>().addHP();
				else
					gc.GetComponent<EmotionManager>().removeHP();
			}
		}
		else
		{ 
			MMManger.LObject rem = mmm.insertInList(this.gameObject, 2, painting,StartCoroutine(timer(vp.length-vp.time,vp,painting)));
			if (rem != null)
			{
				if (rem.getAV().Equals(1))
				{
					rem.getGo().GetComponent<AudioSource>().Pause();
					GameObject.Find("AudioManager").GetComponent<AudioManager>().ReqAndPlay(false, rem.getNo());
					videoManager.GetComponent<VideoManager>().hp--;
					if (mmm.Version.Equals(1))
					{
						if (videoManager.GetComponent<VideoManager>().hp > 0)
							gc.GetComponent<EmotionManager>().addHP();
						else
							gc.GetComponent<EmotionManager>().removeHP();
					}
				}
				else
				{
					rem.getGo().GetComponent<VideoPlayer>().Pause();
                    videoManager.GetComponent<VideoManager>().ReqAndPlay(false, rem.getNo());
					videoManager.GetComponent<VideoManager>().hp--;
					videoManager.GetComponent<VideoManager>().hmd--;
					if (mmm.Version.Equals(1))
					{
						if (videoManager.GetComponent<VideoManager>().hmd > 0)
							gc.GetComponent<EmotionManager>().addHMD();
						else
							gc.GetComponent<EmotionManager>().removeHMD();
						if (videoManager.GetComponent<VideoManager>().hp > 0)
							gc.GetComponent<EmotionManager>().addHP();
						else
							gc.GetComponent<EmotionManager>().removeHP();
					}
				}
			}
			vp.Play();
			videoManager.GetComponent<VideoManager>().hp++;
			videoManager.GetComponent<VideoManager>().hmd++;
			if (mmm.Version.Equals(1))
			{
				if (videoManager.GetComponent<VideoManager>().hmd > 0)
					gc.GetComponent<EmotionManager>().addHMD();
				else
					gc.GetComponent<EmotionManager>().removeHMD();
				if (videoManager.GetComponent<VideoManager>().hp > 0)
					gc.GetComponent<EmotionManager>().addHP();
				else
					gc.GetComponent<EmotionManager>().removeHP();
			}
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]++;*/
			videoManager.GetComponent<VideoManager>().ReqAndPlay(true, painting);
		}
	}

	IEnumerator timer(double t, VideoPlayer go,int painting)
	{
		yield return new WaitForSeconds((float)t);
		//if (go.transform.parent.parent.GetComponent<MouseOver2>().outlineMaterial.GetFloat("_OutlineEnabled").Equals(1.0f))
		go.frame = 4;
		go.Pause();
		go.frame = 4;
		videoManager.GetComponent<VideoManager>().ReqAndPlay(false, painting);
		videoManager.GetComponent<VideoManager>().hp--;
		videoManager.GetComponent<VideoManager>().hmd--;
		if (mmm.Version.Equals(2))
			yield return null;
		if (videoManager.GetComponent<VideoManager>().hmd > 0)
			gc.GetComponent<EmotionManager>().addHMD();
		else
			gc.GetComponent<EmotionManager>().removeHMD();
		if (videoManager.GetComponent<VideoManager>().hp > 0)
			gc.GetComponent<EmotionManager>().addHP();
		else
			gc.GetComponent<EmotionManager>().removeHP();
	}
}
