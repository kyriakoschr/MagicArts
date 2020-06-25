using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Video;

public class Audio : MonoBehaviour
{
	MMManger mmm;

	public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
		mmm = GameObject.Find("MultiMediaManager").GetComponent<MMManger>();
	}

	public void PlayPause(int painting)
	{
		AudioSource vp = this.GetComponent<AudioSource>();
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
			MMManger.LObject rem = mmm.insertInList(this.gameObject, 1, painting);
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

	// Update is called once per frame
	void Update()
    {
        
    }
}
