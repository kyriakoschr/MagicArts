using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {
	//public GameObject ButtonDay = null; // assign in the editor
	//public GameObject ButtonNight = null; // assign in the editor
	//public GameObject FPC;
	public GameObject gObject;
    public string chosenPrefab;

	public void myChangeScene (string scene){
		//if (isLocalPlayer) {
			Debug.Log ("Has");
			RpcChangeScene (scene);
		//}
	}
	// Use this for initialization
	void Start () {
		if (isLocalPlayer==false)
			return;
		//rb = GetComponent<Rigidbody>();
		//FPC = GameObject.FindWithTag ("MainCamera");
		Debug.Log("Spawn my own personal unit.");
        //Instantiate(PlayerUnitPrefab);
        chosenPrefab = GameObject.Find("Option").GetComponent<Text>().text;
        Debug.Log("My chosen Prefab is " + chosenPrefab);
        if(chosenPrefab=="Boy")
	        CmdSpawnMyUnit(this.transform.position,this.transform.rotation,2);
        else
            CmdSpawnMyUnit(this.transform.position, this.transform.rotation, 1);
        //this.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
        DontDestroyOnLoad (this);
		//ButtonDay.GetComponent<Button>().onClick.AddListener(delegate{CmdChangeScene("day"); });
		//ButtonNight.GetComponent<Button>().onClick.AddListener(delegate{CmdChangeScene("night"); });

		/*Debug.Log ("pos " + FPC.transform.position);
		Debug.Log ("rot " + FPC.transform.rotation);
		Vector3 temp = new Vector3(this.transform.position.x,FPC.transform.position.y,this.transform.position.z+1);
		FPC.transform.position = temp;
		FPC.transform.rotation= this.transform.rotation;*/
	}
	/*
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement= new Vector3(moveHorizontal,0.0f,moveVertical);
		rb.AddForce(movement*speed);
	}
	*/
	public GameObject PlayerUnitPrefab1;
	public GameObject PlayerUnitPrefab2;
	//public GameObject Line;
	//public GameObject Spot;
	/*public GameObject LineD;
	public GameObject LineM;
	public GameObject LineS;*/
	// Update is called once per frame
	void Update () {


		if (isLocalPlayer==false)
			return;
		//Debug.Log ("Spawned " + gObject.name);

		/*if (Input.GetKeyDown (KeyCode.UpArrow))
			CmdMoveUnitUp ();*/
	}

	GameObject myPlayerUnit;
	GameObject myPlayerUnit1;
	GameObject myPlayerUnit2;
	GameObject SL;
	GameObject ML;
	GameObject DL;
	///////////COMMANDS
	//THose functs executed only by the server


	[Command]
	void CmdChangeScene (string scene){
		Debug.Log ("CMD CHAN");
		RpcChangeScene (scene);
	}

	[Command]
	void CmdSpawnMyUnit(Vector3 p,Quaternion r,int chosen)
	{
		//create the new object on server
		//rb = GetComponent<Rigidbody>();
		NetworkIdentity m_Identity;
		m_Identity = GetComponent<NetworkIdentity>();

		//Output to the console the connection associated with this NetworkIdentity
		Debug.Log("Connection : " + m_Identity.connectionToClient.connectionId);
        //Debug.Log ("TR is " + tr.position);
        Quaternion q = new Quaternion();
        GameObject chosenPre = null;
        if (chosen == 1)
            chosenPre = PlayerUnitPrefab1;
        else
            chosenPre = PlayerUnitPrefab2;
        if (m_Identity.connectionToClient.connectionId % 2 == 0) {
            q.SetLookRotation(new Vector3(-60, 0, 0));
            gObject = Instantiate(chosenPre, p,q);
        }
        else {
            q.SetLookRotation(new Vector3(15,0,25));
            gObject = Instantiate(chosenPre, p, q);
            }
		//GameObject go1 = Instantiate(Line);
		//GameObject go2 = Instantiate(Spot);
		/*GameObject gosl = Instantiate(LineS,Line.transform);
		GameObject goml = Instantiate(LineM,Line.transform);
		GameObject godl = Instantiate(LineD,Line.transform);*/
		myPlayerUnit = gObject;
		//go.transform.parent = tr;
		//myPlayerUnit1 = go1;
		//myPlayerUnit2= go2;
		/*SL = gosl;
		ML = goml;
		DL = godl;*/
		//Vector3 p1 = new Vector3 (p.x, 4, p.z+1);
		//GameObject FPC = Instantiate (FPCamera, p1, r);
		//propagate it to the clients
		NetworkServer.SpawnWithClientAuthority(gObject,connectionToClient);
		//return go;
		//NetworkServer.SpawnWithClientAuthority(go1,connectionToClient);
		//NetworkServer.SpawnWithClientAuthority(go2,connectionToClient);
		/*NetworkServer.SpawnWithClientAuthority(gosl,connectionToClient);
		NetworkServer.SpawnWithClientAuthority(goml,connectionToClient);
		NetworkServer.SpawnWithClientAuthority(godl,connectionToClient);*/
	}

	[Command]
	void CmdMoveUnitUp()
	{
		if (myPlayerUnit == null)
			return;
		myPlayerUnit.transform.Translate (1, 0, 0);
	}

	[Command]
	void CmdMoveUnitDown()
	{
		if (myPlayerUnit == null)
			return;
		myPlayerUnit.transform.Translate (-1, 0, 0);
	}

	[Command]
	void CmdMoveUnitRight()
	{
		if (myPlayerUnit == null)
			return;
		myPlayerUnit.transform.Translate (0, 0, 1);
	}

	[Command]
	void CmdMoveUnitLeft()
	{
		if (myPlayerUnit == null)
			return;
		myPlayerUnit.transform.Translate (0, 0, -1);
	}

	[ClientRpc]
	void RpcChangeScene(string scene){
		Debug.Log ("Spawned ");
		if (!isLocalPlayer) {
			Debug.Log (gObject.name);
			gObject.GetComponent<SceneLoader> ().LoadScene (scene);
			/*if (scene == "day")
				gObject.transform.position = new Vector3 (365f, 0.5f, 23.4f);
			else
				gObject.transform.position = new Vector3 (0, 0.5f, 364);*/
		}
	}
}

