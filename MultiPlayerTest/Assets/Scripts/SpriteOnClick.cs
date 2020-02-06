using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SpriteOnClick : MonoBehaviour {

//	[SyncVar]
//	bool MSet;

	public GameObject Wall;
	public GameObject Menu;
	public GameObject Audio;
    RaycastHit hit;
    Ray ray;
    Camera cam;
    public GameObject FPC;
    public GameObject TPC;
    // Use this for initialization
    void Start () {
		//MSet = false;
	}

	void OnMouseDown(){
        
	
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        //if (hit.collider.GetType() == typeof(SphereCollider))
        //{
        //    return;
        //}
        if (TPC.activeInHierarchy)
        {
            cam = TPC.GetComponent<Camera>();
            ray = cam.ScreenPointToRay(Input.mousePosition);
        }
        else
        {
            cam = FPC.GetComponent<Camera>();
            ray = cam.ScreenPointToRay(Input.mousePosition);
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            if (hit.collider.GetType() == typeof(SphereCollider))
                return;
        if (Wall != null && Menu != null) {
			Debug.Log (Wall.name + "sprite on click");
            if (Wall.activeInHierarchy)
            {
                Debug.Log("Wall active in sprite");
                Menu.SetActive(true);
            }
		} else {
			VideoPlayer vp = GetComponent<VideoPlayer> ();
			if (vp != null) {
				if (vp.isPlaying)
					vp.Pause ();
				else
					vp.Play ();
			} else {
				AudioSource AS=Audio.GetComponent<AudioSource> ();
				if( AS.isPlaying == false)
					AS.Play ();
				else
					AS.Pause();
			}
		}
	//	else { 
			//if (isLocalPlayer) {
//				MSet = true;
//				Wall.SetActive (true);
//				CmdEnableMenu ();
			//}
		//}
//			if (isServer) {
//				Debug.Log ("server client seting true");
//				Wall.SetActive (true);
//				MSet = true;
//				RpcEnableMenu ();
//			} else {
//				Debug.Log ("Not server client calling cmd");
//				//MSet = true;
//				this.GetComponent<NetworkIdentity> ().AssignClientAuthority (connectionToClient);
//				CmdEnableMenu (true);
//				this.GetComponent<NetworkIdentity> ().RemoveClientAuthority (connectionToClient);
//			}
			//Wall.SetActive (true);
			//MSet = true;
			//CmdEnableMenu ();
	//		}
	}

	/*void OnEnable(){
		Debug.Log("OnEnable");
		MSet=true;
	}*/

	// Update is called once per frame
	void Update () {
		/*if (MSet) {
			Debug.Log ("Update activating it");
			Wall.SetActive (true);
		}*/
//		if (isServer) {
//			Debug.Log("I am server "+MSet	);
//
//		}
	}

//	void OnHook(bool value){
//		Debug.Log ("OnHook called");
//		MSet=value;
//		CmdEnableMenu (value);
//	}

	/*[Command]
	void CmdEnableMenu(bool value){
		Debug.Log ("CMD called");
		//this.GetComponent<NetworkIdentity> ().AssignClientAuthority (connectionToClient);
		Wall.SetActive (value);
		MSet = value;
		RpcEnableMenu ();
		//this.GetComponent<NetworkIdentity> ().RemoveClientAuthority (connectionToClient);
	}

	[ClientRpc]
	void RpcEnableMenu(){
		Debug.Log("RPC called on client");
		MSet = true;
		Wall.SetActive (true);
	}*/
}
