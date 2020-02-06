using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WallActivated : NetworkBehaviour {
	/*[SyncVar]
	bool MSet;*/
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable(){
		//MSet = true;
		//if (!hasAuthority) {
		Debug.Log ("Connection to client: " + this.GetComponent<NetworkIdentity> ().connectionToClient);
			this.GetComponent<NetworkIdentity> ().AssignClientAuthority (this.GetComponent<NetworkIdentity> ().connectionToClient);
			Debug.Log ("Calling cmd:");
			CmdEnableMe ();
		//}
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("UPDATE:");
	}

	[Command]
	void CmdEnableMe(){
		Debug.Log ("CMD");
		this.gameObject.SetActive (true);
		RpcEnableMe ();
	}

	[ClientRpc]
	void RpcEnableMe(){
		Debug.Log ("RPC");
		this.gameObject.SetActive (true);
	}
}
