using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Networking;

public class Teleport : NetworkBehaviour {
	public Scene activeScene;
	// Use this for initialization
	void Start () {
		activeScene = SceneManager.GetActiveScene ();
	}
		
	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("RoomDay")) {
			//Debug.Log ("GO is " + this.gameObject.name);
			//SceneManager.LoadScene ("Scenes/roomDay",LoadSceneMode.Single);
			//string nam = SceneManager.GetSceneByName ("roomDay").name;
			//Debug.Log ("scene name is " + nam);

			//SceneManager.SetActiveScene (SceneManager.GetSceneByName("roomDay"));

			//CmdChangeScene (SceneManager.GetSceneByName ("roomDay"));
			//SceneManager.MoveGameObjectToScene(GameObject.Find("PlayerObject"),SceneManager.GetSceneByName("roomDay"));
			//SceneManager.MoveGameObjectToScene(this.gameObject,SceneManager.GetSceneByName("roomDay"));
			GameObject.FindWithTag ("Canvas").SetActive(true);
			GameObject.FindWithTag ("BN").SetActive(true);
			GameObject.FindWithTag ("BD").SetActive(false);
			Debug.Log ("Teleport to " + other.gameObject);
			transform.position = new Vector3 (365f, 0.5f, 23.4f);//GameObject.FindGameObjectWithTag ("Respawn").transform.position;
		}
		else if (other.CompareTag ("Back")) {
			//SceneManager.LoadScene ("Scenes/SampleScene");
			//SceneManager.SetActiveScene (SceneManager.GetSceneByName("Scenes/SampleScene"));
			GameObject.FindWithTag ("Canvas").SetActive(false);
			GameObject.FindWithTag ("BN").SetActive(false);
			GameObject.FindWithTag ("BD").SetActive(false);
			Debug.Log ("Teleport to " + other.gameObject);
			transform.position = new Vector3 (1.0f, 0.5f, 20.0f);//GameObject.FindGameObjectWithTag ("Respawn").transform.position;
		}
		if (other.CompareTag ("Baby")) {
			Debug.Log ("VIDEO:");
			//VideoPlayer vp = other.GetComponent<VideoPlayer>();
			/*vp.enabled = true;
			vp.Play();*/
			CmdPlay (other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		/*if (other.CompareTag ("Baby")) {
			Debug.Log ("VIDEO:");
			VideoPlayer vp = other.GetComponent<VideoPlayer>();
			vp.Stop ();
			vp.enabled=false;
			other.GetComponent<SpriteRenderer> ().color = Color.white;
		}*/
	}

	// Update is called once per frame
	void Update () {
		/*if (SceneManager.GetActiveScene ().name == "roomNight"||SceneManager.GetActiveScene ().name == "roomDay") {
			if (this.transform.position.z > 11.34f || this.transform.position.z <= 0) {
				this.transform.position = GameObject.FindGameObjectWithTag ("Cylinder").transform.position;
			}
			if (this.transform.position.x > 3.63f || this.transform.position.x < -3.63f) {
				this.transform.position = GameObject.FindGameObjectWithTag ("Cylinder").transform.position;
			}
		}*/
	}

	[Command]
	void CmdPlay(GameObject other)
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcPlay (other);
	}
		
	[ClientRpc]
	void RpcPlay(GameObject other)
	{
		VideoPlayer vp = other.GetComponent<VideoPlayer>();
		vp.enabled = true;
		vp.Play();
	}
		
}