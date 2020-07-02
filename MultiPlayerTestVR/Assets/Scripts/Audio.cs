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
    // Start is called before the first frame update
    void Start()
    {
		mmm = GameObject.Find("MultiMediaManager").GetComponent<MMManger>();
		descr = transform.parent.transform.Find("Descr0").gameObject;
	}

	public void PlayPause(int painting)
	{
		if (vp.isPlaying)
		{
			vp.Pause();
			mmm.listRemove(this.gameObject, 1, painting);
			/*GetComponent<MouseOver2>().outlineMaterial.SetColor("_SolidOutline", Color.green);
			GetComponent<MouseOver2>().outlineMaterial.SetFloat("_OutlineEnabled", 0.0f);
			videoManager.GetComponent<VideoManager>().isPlaying[painting]--;*/
			audioManager.GetComponent<AudioManager>().ReqAndPlay(false, painting);
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
				}
				else
				{
					rem.getGo().GetComponent<VideoPlayer>().Pause();
					GameObject.Find("VideoManager").GetComponent<VideoManager>().ReqAndPlay(false, rem.getNo());
				}
			}
			vp.Play();
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
		if (vp.isPlaying&&mmm.Version.Equals(2))
		{
			float dist = Vector3.Distance(descr.transform.position, gc.myLocalPlayer.transform.Find("Head").transform.position);
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
			vp.volume = vlm;
		}
	}
}
