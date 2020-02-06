using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour {
	public GameObject ButtonDay;
	public GameObject ButtonNight;

	void Start () {
		//ButtonNight = GameObject.Find ("CanvasNight");
		//ButtonDay = GameObject.Find ("CanvasDay");
	}

	public void LoadScene(string Name)
	{ 
		if (Name == "day") {
			//ButtonNight.SetActive(false);
			//ButtonDay.SetActive(true);
			//GameObject.FindWithTag ("MainCamera").SetActive (true);
			//GameObject.FindWithTag ("TMainCamera").SetActive (false);
			//GameObject.FindWithTag ("BN").SetActive (true);
			transform.position = new Vector3 (0, 0.5f, 364);
		} else {
			//ButtonNight.SetActive(true);
			//ButtonDay.SetActive(false);
			//GameObject.FindWithTag ("MainCamera").SetActive (true);
			//GameObject.FindWithTag ("TMainCamera").SetActive (false);
			//GameObject.FindWithTag ("BN").SetActive (false);
			//GameObject.FindWithTag ("BD").SetActive (true);
			transform.position = new Vector3 (365f, 0.5f, 23.4f);
		}
	}

}