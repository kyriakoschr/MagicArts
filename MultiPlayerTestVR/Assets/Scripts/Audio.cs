using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Video;

public class Audio : MonoBehaviour
{
	MMManger mmm;
	AudioSource vp ;
	public AudioManager audioManager;
	public GameController gc;
	GameObject descr;
	GameObject mplayer;
    InitPPlayer initpp;
    AudioSource voiceSpeaker;

	// Start is called before the first frame update
	void Start()
    {
		mmm = GameObject.Find("MultiMediaManager").GetComponent<MMManger>();
        descr = transform.parent.transform.Find("Descr0").gameObject;
	}

	public void PlayPause(int painting)
	{
		Debug.Log("PLLPAUSE");
		if (vp.isPlaying)
		{
			vp.Pause();
			mmm.listRemove(this.gameObject, 1, painting);
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]--;*/
			audioManager.GetComponent<AudioManager>().ReqAndPlay(false, painting);
			GameObject.Find("VideoManager").GetComponent<VideoManager>().hp--;
			if (mmm.Version.Equals(1))
			{
				if (GameObject.Find("VideoManager").GetComponent<VideoManager>().hp > 0)
					gc.GetComponent<EmotionManager>().addHP();
				else
					gc.GetComponent<EmotionManager>().removeHP();
			}
		}
		else
		{
			MMManger.LObject rem = mmm.insertInList(this.gameObject, 1, painting, StartCoroutine(timer(vp.clip.length - vp.time, vp,painting)));
			if (rem != null)
			{
				if (rem.getAV().Equals(1))
				{
					rem.getGo().GetComponent<AudioSource>().Pause();
					audioManager.GetComponent<AudioManager>().ReqAndPlay(false, rem.getNo());
					GameObject.Find("VideoManager").GetComponent<VideoManager>().hp--;
					if (mmm.Version.Equals(1))
					{
						if (GameObject.Find("VideoManager").GetComponent<VideoManager>().hp > 0)
							gc.GetComponent<EmotionManager>().addHP();
						else
							gc.GetComponent<EmotionManager>().removeHP();
					}
				}
				else
				{
					rem.getGo().GetComponent<VideoPlayer>().Pause();
					GameObject.Find("VideoManager").GetComponent<VideoManager>().ReqAndPlay(false, rem.getNo());
					GameObject.Find("VideoManager").GetComponent<VideoManager>().hp--;
					GameObject.Find("VideoManager").GetComponent<VideoManager>().hmd--;
					if (mmm.Version.Equals(1))
					{
						if (GameObject.Find("VideoManager").GetComponent<VideoManager>().hmd > 0)
							gc.GetComponent<EmotionManager>().addHMD();
						else
							gc.GetComponent<EmotionManager>().removeHMD();
						if (GameObject.Find("VideoManager").GetComponent<VideoManager>().hp > 0)
							gc.GetComponent<EmotionManager>().addHP();
						else
							gc.GetComponent<EmotionManager>().removeHP();
					}
				}
			}
			vp.Play();
			GameObject.Find("VideoManager").GetComponent<VideoManager>().hp++;
			if (mmm.Version.Equals(1))
			{
				if (GameObject.Find("VideoManager").GetComponent<VideoManager>().hp > 0)
					gc.GetComponent<EmotionManager>().addHP();
				else
					gc.GetComponent<EmotionManager>().removeHP();
			}
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 1.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]++;*/
			audioManager.GetComponent<AudioManager>().ReqAndPlay(true, painting);
		}
	}

	IEnumerator timer(double t, AudioSource go,int painting)
	{
		yield return new WaitForSeconds((float)t);
		//if (go.transform.parent.parent.GetComponent<MouseOver2>().outlineMaterial.GetFloat("_OutlineEnabled").Equals(1.0f))
		go.Stop();
		go.time = 0;
		audioManager.GetComponent<AudioManager>().ReqAndPlay(false, painting);
		GameObject.Find("VideoManager").GetComponent<VideoManager>().hp--;
		if (mmm.Version.Equals(2))
			yield return null;
		if (GameObject.Find("VideoManager").GetComponent<VideoManager>().hp > 0)
			gc.GetComponent<EmotionManager>().addHP();
		else
			gc.GetComponent<EmotionManager>().removeHP();
	}

	private void Awake()
    {
		if (vp == null)
			vp = GetComponent<AudioSource>();
	}
	
	private void OnBecameVisible()
    {
		if (vp == null)
			vp = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
    {
		if (mplayer==null){
			mplayer = gc.myLocalPlayer;
/*			initpp = gc.myLocalPlayer.GetComponent<InitPPlayer>(); 
*/		}
		if (voiceSpeaker == null)
			voiceSpeaker = mplayer.transform.Find("Speaker").GetComponent<AudioSource>();
		if (vp.isPlaying)
		{
			float dist = Vector3.Distance(descr.transform.position, mplayer.transform.Find("Head").transform.position);
			float vlm;
			if (dist < 25)
				vlm = 1f;
			else if (dist < 50)
				vlm = 0.7f;
			else if (dist < 100)
				vlm = 0.3f;
			else if (dist < 150)
				vlm = 0.05f;
			else vlm = 0.0f;
			if (voiceSpeaker.isPlaying)
				vlm *= 0.5f;
			vp.volume = vlm;
		}
	}
}
