using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using cakeslice;

public class SpriteOnClick : NetworkBehaviour {

//	[SyncVar]
//	bool MSet;

	public GameObject Wall;
	public GameObject Menu;
	public GameObject Audio;
    public GameObject user;
    RaycastHit hit;
    Ray ray;
    Camera cam;
    public GameObject FPC;
    public GameObject TPC;
    public GameObject luser = null;
    bool found = false;

    void find() {
        //MSet = false;
        Debug.Log("ONSTARTERERERE");
        GameObject[] users = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < users.Length; i++)
        {
            Debug.Log("lplayer " + users[i].gameObject.transform.name);
            if (users[i].gameObject.GetComponent<PlayerCapsule>().checkme())
            {
                luser = users[i].gameObject;
                break;
            }

        }
        Debug.Log(luser.transform.name + " is local player");
        found = true;
        //users..gameObject.GetComponent<PlayerCapsule>().outP(this.transform.name, true);
        //user.GetComponent<PlayerCapsule>().outP(this.transform.name, true);
    }

    public void closeout(GameObject name)
    {
        luser.GetComponent<PlayerCapsule>().outP(name.name, false);
        //if (name.name == "paint8")
        //    luser.GetComponent<PlayerCapsule>().outP("paint8(1)", false);
    }

    [Command]
    void CmdOutPaint2(string name, bool nval)
    {
        RpcOutPaint2(name, nval);
    }

    [ClientRpc]
    void RpcOutPaint2(string name, bool nval)
    {
        cakeslice.Outline outl = GameObject.Find(name).GetComponent<cakeslice.Outline>();
        MouseOver2 mouseOver2 = GameObject.Find(name).GetComponent<MouseOver2>();
        if (nval)
            mouseOver2.b = mouseOver2.b + 1;
        else
            mouseOver2.b = mouseOver2.b - 1;
        if (mouseOver2.b > 0)
        {
            outl.color = 1;
            outl.enabled = true;
        }
        else
        {
            outl.color = 0;
            outl.enabled = nval;
        }
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
                Debug.Log(this.transform.name +" Wall active in sprite");
                Menu.SetActive(true);
                //GameObject[] users = GameObject.FindGameObjectsWithTag("Player");
                //GameObject user = users[0];
                /*for(int i = 0; i < users.Length; i++)
                {
                    Debug.Log("lplayer " + users[i].gameObject.transform.name);
                    if (users[i].gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
                    {
                        user = users[i].gameObject;
                        break;
                    }

                }*/
                if (!found)
                    find();
                Debug.Log(luser.transform.name);
                //users..gameObject.GetComponent<PlayerCapsule>().outP(this.transform.name, true);
                luser.GetComponent<PlayerCapsule>().outP(this.transform.name, true);
                //if (this.transform.name == "paint8")
                //    luser.GetComponent<PlayerCapsule>().outP("paint8(1)", true);
                //CmdOutPaint2(this.transform.name, true);
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
