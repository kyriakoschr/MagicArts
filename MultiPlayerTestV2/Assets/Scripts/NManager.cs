using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NManager : NetworkBehaviour {
	[SyncVar]
	public bool wall0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[Command]
	public void CmdEnabl(){
		wall0 = true;
	}
}
