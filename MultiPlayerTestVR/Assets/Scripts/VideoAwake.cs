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

	// Use this for initialization
	void Start () {
		videoManager = GameObject.Find("VideoManager");
		mmm = GameObject.Find("MultiMediaManager").GetComponent<MMManger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (started && vp.isPlaying && vp.isPrepared)
		{
			started = false;
			vp.frame = 2;
			vp.Pause();
			vp.frame = 2;
		}
		if (vp.isPlaying&&mmm.Version.Equals(2))
		{
			float dist = Vector3.Distance(gameObject.transform.position, gc.myLocalPlayer.transform.Find("Head").transform.position);
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
			vp.GetTargetAudioSource(0).volume = vlm;
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

	IEnumerator timer(double t, VideoPlayer go,int painting)
	{
		yield return new WaitForSeconds((float)t);
		//if (go.transform.parent.parent.GetComponent<MouseOver2>().outlineMaterial.GetFloat("_OutlineEnabled").Equals(1.0f))
		go.frame = 2;
		go.Pause();
		go.frame = 2;
		videoManager.GetComponent<VideoManager>().ReqAndPlay(false, painting);
	}
}
