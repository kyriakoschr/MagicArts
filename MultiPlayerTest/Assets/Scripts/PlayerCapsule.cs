using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using cakeslice;

public class PlayerCapsule : NetworkBehaviour {
	[SyncVar(hook="f0_onHook")]
	public bool b_wall0;
	public bool lb_wall0;
	[SyncVar(hook="f1_onHook")]
	public bool b_wall1;
	public bool lb_wall1;
	[SyncVar(hook="f2_onHook")]
	public bool b_wall2;
	public bool lb_wall2;
	[SyncVar(hook="f3_onHook")]
	public bool b_wall3;
	public bool lb_wall3;
	[SyncVar(hook="f4_onHook")]
	public bool b_wall4;
	public bool lb_wall4;
	[SyncVar(hook="f5_onHook")]
	public bool b_wall5;
	public bool lb_wall5;
	[SyncVar(hook="f6_onHook")]
	public bool b_wall6;
	public bool lb_wall6;
	[SyncVar(hook="f7_onHook")]
	public bool b_wall7;
	public bool lb_wall7;
	[SyncVar(hook="f8_onHook")]
	public bool b_wall8;
	public bool lb_wall8;
	[SyncVar(hook="f9_onHook")]
	public bool b_wall9;
	public bool lb_wall9;
	[SyncVar(hook="f10_onHook")]
	public bool b_wall10;
	public bool lb_wall10;
	[SyncVar(hook="f11_onHook")]
	public bool b_wall11;
	public bool lb_wall11;
	//[SyncVar(hook="f12_onHook")]
	//public bool b_wall12;
	//public bool lb_wall12;
	[SyncVar(hook="f13_onHook")]
	public bool b_wall13;
	public bool lb_wall13;
	[SyncVar(hook="f14_onHook")]
	public bool b_wall14;
	public bool lb_wall14;
	//[SyncVar(hook="f15_onHook")]
	//public bool b_wall15;
	//public bool lb_wall15;
	//[SyncVar(hook="f16_onHook")]
	//public bool b_wall16;
	//public bool lb_wall16;
	[SyncVar(hook="f17_onHook")]
	public bool b_wall17;
	public bool lb_wall17;
	[SyncVar(hook="f18_onHook")]
	public bool b_wall18;
	public bool lb_wall18;
	[SyncVar(hook="f19_onHook")]
	public bool b_wall19;
	public bool lb_wall19;
	[SyncVar(hook="f20_onHook")]
	public bool b_wall20;
	public bool lb_wall20;
	[SyncVar(hook="f21_onHook")]
	public bool b_wall21;
	public bool lb_wall21;
	//public 	SyncListBool paintings = new SyncListBool();
	public GameObject w1;
	public GameObject w2;
	//public GameObject m_YourFirstButton, m_YourSecondButton;
	public float mouseSensitivity = 10.0f;
	public float clampAngle = 0.0f;
	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the up/y axis
	private Texture lamp;
	public Animator anim ;
	public Vector3 bestGuessPosition;
	//public GameObject FPCamera;
	public Quaternion bestGuessRotation;
	public GameObject FPC;
	public GameObject TPC;
	public GameObject headphones;
	public GameObject vr;
	public GameObject VideoToAnimate;
	public GameObject VideoToAnimate2;
	public GameObject VideoToAnimate3;
	public bool openedPainting;
	private GameObject ButtonNight;
	private GameObject ButtonDay;
	private GameObject CanvasNight;
	private GameObject CanvasDay;
	Vector3 offset;
	public string activeScene;
	public string nactiveScene;
	public GameObject myGO;
	private Button btn1;
	private Button btn2;
	public GameObject[] wall;
	public GameObject smile;
	public GameObject angry;
	public GameObject wow;
	public GameObject sad;
	public GameObject neutral;

	void f0_onHook (bool nval){
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		openedPainting=true;
		b_wall0 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f3_onHook (bool nval){
		//Debug.Log ("called hook before "+b_wall0);
		openedPainting=true;
		//lb_wall0 = nval;
		b_wall3 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f4_onHook (bool nval){
		//Debug.Log ("called hook before "+b_wall0);
		openedPainting=true;
		//lb_wall0 = nval;
		b_wall4 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f5_onHook (bool nval){
		//Debug.Log ("called hook before "+b_wall0);
		openedPainting=true;
		//lb_wall0 = nval;
		b_wall5 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f6_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall6 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f1_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall1 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f7_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall7 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f8_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall8 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f2_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall2 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f9_onHook (bool nval){
		openedPainting=true;
		Debug.Log ("called hook before "+b_wall9);
		//lb_wall0 = nval;
		b_wall9 = nval;
		Debug.Log("Called on hook after "+b_wall9);
	}

	void f10_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall10 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f11_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall11 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	//void f12_onHook (bool nval){
	//	openedPainting=true;
	//	//Debug.Log ("called hook before "+b_wall0);
	//	//lb_wall0 = nval;
	//	b_wall12 = nval;
	//	//Debug.Log("Called on hook after "+b_wall0);
	//}

	void f13_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall13 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f14_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall14 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	//void f15_onHook (bool nval){
	//	openedPainting=true;
	//	//Debug.Log ("called hook before "+b_wall0);
	//	//lb_wall0 = nval;
	//	b_wall15 = nval;
	//	//Debug.Log("Called on hook after "+b_wall0);
	//}

	//void f16_onHook (bool nval){
	//	openedPainting=true;
	//	//Debug.Log ("called hook before "+b_wall0);
	//	//lb_wall0 = nval;
	//	b_wall16 = nval;
	//	//Debug.Log("Called on hook after "+b_wall0);
	//}

	void f17_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall17 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f18_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall18 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f19_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall19 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f20_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall20 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	void f21_onHook (bool nval){
		openedPainting=true;
		//Debug.Log ("called hook before "+b_wall0);
		//lb_wall0 = nval;
		b_wall21 = nval;
		//Debug.Log("Called on hook after "+b_wall0);
	}

	public override void OnStartServer(){
//		Debug.Log ("ENTERD");
//		for (int i = 0; i < 12; i++) {
//			paintings.Add (false);
//		}
//		//b_wall0 = false;
	}

	public override void OnStartClient()
	{
		//Debug.Log (b_wall0 + " is bwall on start client with name "+this.name);
	}

	public void LoadMyScene(string Name)
	{ 
		Debug.Log (Name);
		if (hasAuthority== true){
			Debug.Log ("Auth");
			if (Name == "day") {
				Debug.Log ("Day");
				//GameObject.FindWithTag ("MainCamera").SetActive (true);
				//GameObject.FindWithTag ("TMainCamera").SetActive (false);
				//GameObject.FindWithTag ("BN").SetActive (true);
				this.gameObject.transform.position = new Vector3 (365f, 0.5f, 23.4f);
			} else {
				Debug.Log ("Night");
				Debug.Log (this.name);
				//GameObject.FindWithTag ("MainCamera").SetActive (true);
				//GameObject.FindWithTag ("TMainCamera").SetActive (false);
				//GameObject.FindWithTag ("BN").SetActive (false);
				//GameObject.FindWithTag ("BD").SetActive (true);
				this.gameObject.transform.position = new Vector3 (0.4f, 0.5f, 331);
			}
		}
	}
		
	void Start()
	{
		//Debug.Log (btn1.name);
		//Debug.Log ("Count is: "+paintings[0]);
		//wall1 = new GameObject[12];
		NetworkManagerHUD hud=FindObjectOfType<NetworkManagerHUD>();
		if (hud != null)
			hud.showGUI = false;
		openedPainting=false;
//		smile= transform.Find ("smilecloud").gameObject;
//		wow= transform.Find ("wowcloud").gameObject;
//		sad= transform.Find("sadcloud").gameObject;
//		neutral= transform.Find ("neutralcloud").gameObject;
//		angry= transform.Find("angrycloud").gameObject;
		smile.SetActive (false);
		angry.SetActive (false);
		neutral.SetActive (false);
		wow.SetActive (false);
		sad.SetActive (false);
		vr.SetActive (false);
		headphones.SetActive (false);
		CmdHeadVR (false, false);
		CmdSSound ();
		GameObject[] Buttons =Resources.FindObjectsOfTypeAll<GameObject>();
		for (int i = 0; i < Buttons.Length; i++) {
			if (Buttons [i].name == "ButtonNight") {
				ButtonNight = Buttons [i].gameObject;
				btn2 = ButtonNight.GetComponent<Button>();
				btn2.onClick.AddListener(delegate {LoadMyScene("night"); });
			} else if (Buttons [i].name == "ButtonDay") {
				ButtonDay = Buttons [i].gameObject;
				btn1 = ButtonDay.GetComponent<Button>();
				btn1.onClick.AddListener(delegate {LoadMyScene("day"); });
			} else if (Buttons [i].name == "CanvasDay") {
				CanvasDay = Buttons [i].gameObject;
			} else if (Buttons [i].name == "CanvasNight") {
				CanvasNight = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "water1") {
				w1= Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra0") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[0] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra1") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[1] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra2") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[2] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra3") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[3] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra4") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[4] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra5") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[5] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra6") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[6] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra7") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[7] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra8") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[8] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra9") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[9] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra10") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[10] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra11") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[11] = Buttons [i].gameObject;
			}
			//else if (Buttons [i].name == "extra12") {
			//	//Debug.Log ("Len of array:" + wall1.Length);
			//	//Debug.Log ("Walls:" + walls);
			//	wall[12] = Buttons [i].gameObject;
			//}
			else if (Buttons [i].name == "extra13") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[13] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra14") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[14] = Buttons [i].gameObject;
			}
			//else if (Buttons [i].name == "extra15") {
			//	//Debug.Log ("Len of array:" + wall1.Length);
			//	//Debug.Log ("Walls:" + walls);
			//	wall[15] = Buttons [i].gameObject;
			//}
			//else if (Buttons [i].name == "extra16") {
			//	//Debug.Log ("Len of array:" + wall1.Length);
			//	//Debug.Log ("Walls:" + walls);
			//	wall[16] = Buttons [i].gameObject;
			//}
			else if (Buttons [i].name == "extra17") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[17] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra18") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[18] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra19") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[19] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra20") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[20] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "extra21") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				wall[21] = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "VideoFirstSteps") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				VideoToAnimate = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "VideoPotato") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				VideoToAnimate2 = Buttons [i].gameObject;
			}
			else if (Buttons [i].name == "VideoCafe") {
				//Debug.Log ("Len of array:" + wall1.Length);
				//Debug.Log ("Walls:" + walls);
				VideoToAnimate3 = Buttons [i].gameObject;
			}
            else if(Buttons[i].name == "Main Camera") {
                //Debug.Log ("Len of array:" + wall1.Length);
                //Debug.Log ("Walls:" + walls);
                FPC = Buttons[i].gameObject;
            }
            else if(Buttons[i].name == "TMainCamera") {
                //Debug.Log ("Len of array:" + wall1.Length);
                //Debug.Log ("Walls:" + walls);
                TPC = Buttons[i].gameObject;
            }
        }
		/*ButtonNight=GameObject.Find ("ButtonNight");
		ButtonDay=GameObject.Find ("ButtonDay");
		CanvasNight=GameObject.Find ("CanvasNight");
		CanvasDay=GameObject.Find ("CanvasDay");
		btn1 = ButtonDay.GetComponent<Button>();
		btn2 = ButtonNight.GetComponent<Button>();
		btn1.onClick.AddListener(delegate {LoadMyScene("day"); });
		btn2.onClick.AddListener(delegate {LoadMyScene("night"); });*/
		CanvasDay.SetActive (false);
		CanvasNight.SetActive (false);
		DontDestroyOnLoad (this);
		activeScene = "Museum";
		nactiveScene = "Museum";
		//FPC = Instantiate (FPCP);
		//TPC=Instantiate (TPCP);
		//FPC = GameObject.FindWithTag ("MainCamera");
		//TPC = GameObject.FindWithTag ("TMainCamera");
		//DontDestroyOnLoad (TPC);
		//DontDestroyOnLoad (FPC);
		anim = GetComponent< Animator> ();
		bestGuessPosition=transform.position;
		bestGuessRotation=transform.rotation;
		//Uncomment for FPC
		FPC.transform.position = new Vector3(this.transform.position.x,FPC.transform.position.y,this.transform.position.z);
		FPC.transform.rotation= this.transform.rotation;

		//Uncomment for TPC
		offset =this.transform.position-TPC.transform.position ;
		TPC.transform.rotation = this.transform.rotation;
		Vector3 rot = TPC.transform.localRotation.eulerAngles;
		rotY = rot.x;
		rotX = rot.z;
		TPC.transform.LookAt (this.transform);
		//FPC.SetActive(false);
		//Debug.Log ("Entered by" + this.name);
		//for (int i = 0; i < 13; i++)
		//	Debug.Log (wall [i].name);
		if ( hasAuthority==false)
			return;
		Debug.Log ("Entered by" + this.name);
		if (isServer)
			return;
		//CmdRequest();
		//Debug.Log (lb_wall0 + " on client " + this.name);
		if (this.name == "remy(Clone)") {
			lb_wall0 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall0;
			lb_wall1 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall1;
			lb_wall2 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall2;
			lb_wall3 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall3;
			lb_wall4 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall4;
			lb_wall5 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall5;
			lb_wall6 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall6;
			lb_wall7 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall7;
			lb_wall8 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall8;
			lb_wall9 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall9;
			lb_wall10 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall10;
			lb_wall11 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall11;
			//lb_wall12 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall12;
			lb_wall13 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall13;
			lb_wall14 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall14;
			//lb_wall15 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall15;
			//lb_wall16 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall16;
			lb_wall17 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall17;
			lb_wall18 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall18;
			lb_wall19 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall19;
			lb_wall20 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall20;
			lb_wall21 = GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall21;
		} else if (this.name == "claire(Clone)") {
			lb_wall0 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall0;
			lb_wall1 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall1;
			lb_wall2 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall2;
			lb_wall3 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall3;
			lb_wall4 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall4;
			lb_wall5 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall5;
			lb_wall6 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall6;
			lb_wall7 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall7;
			lb_wall8 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall8;
			lb_wall9 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall9;
			lb_wall10 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall10;
			lb_wall11 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall11;
			//lb_wall12 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall12;
			lb_wall13 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall13;
			lb_wall14 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall14;
			//lb_wall15 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall15;
			//lb_wall16 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall16;
			lb_wall17 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall17;
			lb_wall18 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall18;
			lb_wall19 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall19;
			lb_wall20 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall20;
			lb_wall21 = GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall21;
		}
		Debug.Log (lb_wall0 + " on client " + this.name);
		if (lb_wall0) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[0].SetActive (true);
		}
		if (lb_wall1) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[1].SetActive (true);
		}
		if (lb_wall2) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[2].SetActive (true);
		}
		if (lb_wall3) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[3].SetActive (true);
		}
		if (lb_wall4) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[4].SetActive (true);
		}
		if (lb_wall5) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[5].SetActive (true);
		}
		if (lb_wall6) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[6].SetActive (true);
		}
		if (lb_wall7) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[7].SetActive (true);
		}
		if (lb_wall8) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[8].SetActive (true);
		}
		if (lb_wall9) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[9].SetActive (true);
		}
		if (lb_wall10) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[10].SetActive (true);
		}
		if (lb_wall11) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[11].SetActive (true);
		}
		//if (lb_wall12) {
		//	openedPainting = true;
		//	Debug.Log ("Entered by " + this.name);
		//	wall[12].SetActive (true);
		//}
		if (lb_wall13) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[13].SetActive (true);
		}
		if (lb_wall14) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[14].SetActive (true);
		}
		//if (lb_wall15) {
		//	openedPainting = true;
		//	Debug.Log ("Entered by " + this.name);
		//	wall[15].SetActive (true);
		//}
		//if (lb_wall16) {
		//	openedPainting = true;
		//	Debug.Log ("Entered by " + this.name);
		//	wall[16].SetActive (true);
		//}
		if (lb_wall17) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[17].SetActive (true);
		}
		if (lb_wall18) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[18].SetActive (true);
		}
		if (lb_wall19) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[19].SetActive (true);
		}
		if (lb_wall20) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[20].SetActive (true);
		}
		if (lb_wall21) {
			openedPainting = true;
			Debug.Log ("Entered by " + this.name);
			wall[21].SetActive (true);
		}
	}


	public float speed = 10.0F;
	public float rspeed = 100.0F;
	float ourLatency;

	float latencySmoothingFactor = 10;

	void Update()
	{
		//Scene scene = myGO.scene;
		//Debug.Log ("scene is " + Application.loadedLevelName);
		if (hasAuthority == false) 
		{
			/*NetworkIdentity m_Identity=GetComponent<NetworkIdentity>();
			foreach (KeyValuePair<NetworkInstanceId,m_Identity.connectionToClient.connectionId> item in ClientScene.objects) {
				Debug.Log ("key " + item.Key + " value " + item.Value);
			}*/

			transform.position = Vector3.Lerp (transform.position, bestGuessPosition, Time.deltaTime * latencySmoothingFactor);
			transform.rotation = Quaternion.Slerp (transform.rotation, bestGuessRotation, Time.deltaTime * latencySmoothingFactor);
			return;
		}
//		if(anim.GetBool("isRolling")){
//			Debug.Log ("isrolling@@@@@@@@@@@@@@@@@@@@@@@@@ "+this.transform.position);
//			CmdUpdateVelocity(this.transform.position,this.transform.rotation);
//			return;
//		}
		if (nactiveScene != activeScene) {
			//FPC = GameObject.FindWithTag ("MainCamera");
			//TPC = GameObject.FindWithTag ("TMainCamera");
			activeScene = nactiveScene;
			//CmdChangeScene (SceneManager.GetActiveScene ().name);
			/*if (activeScene.name == "roomDay")
				this.transform.position = new Vector3 (2.86f, 0.5f, 27.288f);
			else if(activeScene.name == "roomNight")
				this.transform.position = new Vector3 (0.78f, 0.5f, 5.2f);*/
		}
		//Working with transform.position
//		if (paintings [0] == true) {
//			Debug.Log ("KOO is true");
//			wall0.SetActive (true);
//		}
//		if (b_wall0) {
//			Debug.Log ("Entered by" + this.name);
//			wall0.SetActive (true);
//		}
		/*float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rspeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0, 0, translation);
		transform.Rotate (0, rotation, 0);
		if (translation+rotation != 0) {
			anim.SetBool ("isWalking", true);
			CmdWalk ();
		} else {
			anim.SetBool ("isWalking", false);
			CmdNotWalk ();
		}*/

		float rotation = (Input.GetAxis ("Horizontal")+Input.GetAxis("Mouse X")) * rspeed;
		rotation *= Time.deltaTime;
		bool changed = false;
		if (GameObject.Find ("Canvas") == null) {
			transform.Rotate (0, rotation, 0);
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				//anim.SetBool ("isWalking", true);
				changed = true;
				transform.GetComponent<Rigidbody> ().MovePosition (transform.position + transform.forward * Time.deltaTime * speed);
				//transform.GetComponent<Rigidbody> ().rotation = Quaternion.LookRotation (Vector3.forward);
				//CmdWalk ();
			}
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				//anim.SetBool ("isWalking", true);
				changed = true;
				transform.GetComponent<Rigidbody> ().MovePosition (transform.position - transform.forward * Time.deltaTime * speed);
				//transform.GetComponent<Rigidbody> ().rotation = Quaternion.LookRotation (Vector3.back);
				//CmdWalk ();
			}
		
			/*if (Input.GetKey (KeyCode.A)) {
			anim.SetBool ("isWalking", true);
			//transform.GetComponent<Rigidbody> ().AddForce (transform., ForceMode.VelocityChange);
			//transform.GetComponent<Rigidbody> ().rotation = Quaternion.LookRotation (Vector3.left);
			CmdWalk ();
		}
		if (Input.GetKey (KeyCode.D)) {
			anim.SetBool ("isWalking", true);
			//transform.GetComponent<Rigidbody> ().AddForce (new Vector3 (-1.0f, 0, 0), ForceMode.VelocityChange);
			//transform.GetComponent<Rigidbody> ().rotation = Quaternion.LookRotation (Vector3.right);
			CmdWalk ();
		}*/
			if (rotation != 0 || changed) {
				anim.SetBool ("isWalking", true);
				CmdWalk ();
			} else {
				anim.SetBool ("isWalking", false);
				CmdNotWalk ();
			}
		}
		float desiredAngle = this.transform.eulerAngles.y;
		Quaternion rrotation = Quaternion.Euler(0, desiredAngle, 0);
		Vector3 newv3 = new Vector3 (this.transform.position.x, this.transform.position.y , this.transform.position.z);
		TPC.transform.position = newv3-(rrotation*offset);
		TPC.transform.LookAt(this.transform);
		float mouseY = -Input.GetAxis("Mouse Y");
		//float mouseX = Input.GetAxis("Mouse X");
		//mouseY=mouseY * Time.deltaTime;
		rotY += mouseY *mouseSensitivity* Time.deltaTime;
		//rotX += mouseX *mouseSensitivity* Time.deltaTime;
		if(GameObject.Find("Canvas")==null)	
			TPC.transform.Rotate (rotY, 0,0);
		//TPC.transform.rotation=new Quaternion(rotY,TPC.transform.rotation.y,TPC.transform.rotation.z,TPC.transform.rotation.w);
		//TPC.transform.Rotate (90,0,0);

		//float mouseX = Input.GetAxis("Mouse X");
		//rotX += mouseX * mouseSensitivity * Time.deltaTime;

		//rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		/*Quaternion localRotation =new Quaternion( rotY, TPC.transform.rotation.y,TPC.transform.rotation.z ,TPC.transform.rotation.w);
		TPC.transform.rotation = localRotation;
		*/
		//Uncomment for FPC

		Vector3 temp= new Vector3 (this.transform.position.x, FPC.transform.position.y, this.transform.position.z + 0.2f);
		FPC.transform.position =temp+ this.transform.forward*4f;
		FPC.transform.rotation= this.transform.rotation;
		if(GameObject.Find("Canvas")==null)	
			FPC.transform.Rotate (rotY, 0,0);
		//Vector3 p1= new Vector3(transform.position.x,4,transform.position.z+1);
		//Debug.Log ("bef transf pos "+p1);
		//Debug.Log ("bef transf prot "+transform.rotation);
		//FPCamera.transform.position = p1;
		//FPCamera.transform.rotation=transform.rotation;
		//Debug.Log ("after transf pos "+FPCamera.transform.position);
		//Debug.Log ("after transf prot "+FPCamera.transform.rotation);
		//Vector3 rotat;
		//float angl;
		//transform.rotation.ToAngleAxis(angl,rotat);
		//Vector3 p = transform.position;
		if (Input.GetKeyDown (KeyCode.H)) {
			anim.SetTrigger ("isWaving");
			//Debug.Log ("Have to wave mine");
			CmdWave ();
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			anim.SetTrigger ("isPointing");
			//Debug.Log ("Have to wave mine");
			CmdPoint ();
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			//anim.SetTrigger ("isPointing");
			//Debug.Log ("Have to wave mine");
			CmdDance();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			//anim.SetTrigger ("isroll");
			//Debug.Log ("Have to wave mine");
			CmdRoll();
		}
		if(Input.GetKeyDown(KeyCode.F1))
			if(activeScene=="Museum")
				if (TPC.activeInHierarchy) {
					FPC.gameObject.GetComponent<OutlineEffect> ().enabled = true;
					TPC.gameObject.GetComponent<OutlineEffect> ().enabled = false;
					FPC.SetActive (true);
					TPC.SetActive (false);
					GameObject.Find ("paint0").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint1").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint2").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint3").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint4").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint5").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint6").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint7").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint8").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint8(1)").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint9").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint10").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint11").GetComponent<cakeslice.Outline> ().enabled=false;
					//GameObject.Find ("paint12").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint13").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint14").GetComponent<cakeslice.Outline> ().enabled=false;
					//GameObject.Find ("paint15").GetComponent<cakeslice.Outline> ().enabled=false;
					//GameObject.Find ("paint16").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint17").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint18").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint19").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint20").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint21").GetComponent<cakeslice.Outline> ().enabled=false;
				} else {
					FPC.gameObject.GetComponent<OutlineEffect> ().enabled = false;
					TPC.gameObject.GetComponent<OutlineEffect> ().enabled = true;
					FPC.SetActive (false);
					TPC.SetActive (true);
					GameObject.Find ("paint0").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint1").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint2").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint3").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint4").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint5").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint6").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint7").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint8").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint8(1)").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint9").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint10").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint11").GetComponent<cakeslice.Outline> ().enabled=false;
					//GameObject.Find ("paint12").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint13").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint14").GetComponent<cakeslice.Outline> ().enabled=false;
					//GameObject.Find ("paint15").GetComponent<cakeslice.Outline> ().enabled=false;
					//GameObject.Find ("paint16").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint17").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint18").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint19").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint20").GetComponent<cakeslice.Outline> ().enabled=false;
					GameObject.Find ("paint21").GetComponent<cakeslice.Outline> ().enabled=false;
				}
		if(Input.GetKeyDown(KeyCode.C)){
			anim.SetTrigger ("isCome");
			CmdCome ();
		}

		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.T))
		if (activeScene == "Museum" && GameObject.Find ("Canvas") == null) {
			Debug.Log ("Have to teleport");
			RaycastHit hit;
			Camera cam;
			Ray ray;
			bool clicked = false;
			bool clicked2 = false;
			Vector3 target =new Vector3(0,0,0);
			if (TPC.activeInHierarchy) {
				cam = TPC.GetComponent<Camera> ();
				ray = cam.ScreenPointToRay (Input.mousePosition);
			} else {
				cam = FPC.GetComponent<Camera> ();
				ray = cam.ScreenPointToRay (Input.mousePosition);
			}
			if (this.name == "claire(Clone)" || this.name == "remy(Clone)") {
				//GameObject player = GameObject.FindWithTag ("Player");
				//if (player != null) {
				//Collider otherplayer = player.GetComponent<BoxCollider> ();
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					if (hit.collider.gameObject.name == "claire(Clone)" || hit.collider.gameObject.name == "remy(Clone)") {
						clicked = true;
						//Debug.Log ("Claire clicked on "+hit.collider.gameObject.name);
						if (hit.collider.gameObject != this.gameObject) {
							clicked2 = true;
							Debug.Log (hit.collider.gameObject.name);
							CmdMoveHim (this.transform.position + transform.forward*4, this.transform.rotation, hit.collider.gameObject);
							CmdDrag ();
							//this.transform.LookAt (hit.collider.gameObject.transform.position);
							target =this.transform.position + transform.forward*4;
						}
					}
					//Debug.Log ("Claire clicked on remy");
//							player.transform.position = Vector3.Lerp(player.transform.position,this.transform.position,Time.deltaTime * latencySmoothingFactor);
//							player.transform.rotation= Vector3.Lerp(player.transform.rotation,this.transform.rotationTime.deltaTime * latencySmoothingFactor);
//							player.GetComponent<PlayerCapsule>().CmdUpdateVelocity ( this.transform.position,this.transform.rotation);
//							player.GetComponent<PlayerCapsule>().MoveMe(this.transform.position,this.transform.rotation);
				}
				//}
			}/* else if (this.name == "remy(Clone)"){
//					GameObject player = GameObject.FindWithTag ("Claire");
//					if(player!=null){
						//Collider otherplayer = player.GetComponent<BoxCollider> ();
						if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
							CmdMoveHim (this.transform.position, this.transform.rotation, hit.collider.gameObject);	
							clicked = true;
							CmdDrag ();
							Debug.Log ("Remy clicked on "+hit.collider.gameObject.name);
						}
					//}
				}*/
				if (clicked&&clicked2){
					Debug.Log ("Target pos " + target);
					this.transform.LookAt (target);
				}else{
					Collider paint0 = GameObject.Find ("paint0").GetComponent<BoxCollider> ();
					Collider paint1 = GameObject.Find ("paint1").GetComponent<BoxCollider> ();
					Collider paint2 = GameObject.Find ("paint2").GetComponent<BoxCollider> ();
					Collider paint3 = GameObject.Find ("paint3").GetComponent<BoxCollider> ();
					Collider paint4 = GameObject.Find ("paint4").GetComponent<BoxCollider> ();
					Collider paint5 = GameObject.Find ("paint5").GetComponent<BoxCollider> ();
					Collider paint6 = GameObject.Find ("paint6").GetComponent<BoxCollider> ();
					Collider paint7 = GameObject.Find ("paint7").GetComponent<BoxCollider> ();
					Collider paint8 = GameObject.Find ("paint8").GetComponent<BoxCollider> ();
					Collider paint8b = GameObject.Find ("paint8(1)").GetComponent<BoxCollider> ();
					Collider paint9 = GameObject.Find ("paint9").GetComponent<BoxCollider> ();
					Collider paint10 = GameObject.Find ("paint10").GetComponent<BoxCollider> ();
					Collider paint11 = GameObject.Find ("paint11").GetComponent<BoxCollider> ();
					//Collider paint12 = GameObject.Find ("paint12").GetComponent<BoxCollider> ();
					Collider paint13 = GameObject.Find ("paint13").GetComponent<BoxCollider> ();
					Collider paint14 = GameObject.Find ("paint14").GetComponent<BoxCollider> ();
					//Collider paint15 = GameObject.Find ("paint15").GetComponent<BoxCollider> ();
					//Collider paint16 = GameObject.Find ("paint16").GetComponent<BoxCollider> ();
					Collider paint17 = GameObject.Find ("paint17").GetComponent<BoxCollider> ();
					Collider paint18 = GameObject.Find ("paint18").GetComponent<BoxCollider> ();
					Collider paint19 = GameObject.Find ("paint19").GetComponent<BoxCollider> ();
					Collider paint20 = GameObject.Find ("paint20").GetComponent<BoxCollider> ();
					Collider paint21 = GameObject.Find ("paint21").GetComponent<BoxCollider> ();
					Collider terrain = GameObject.FindWithTag ("Terrain").GetComponent<MeshCollider> ();
					if (paint0.Raycast (ray, out hit, Mathf.Infinity)) {
							openedPainting = true;
							Debug.Log (wall[0].name+" on ClientQQQQQQQQQQQQQQQQQQQQQQ");
							//b_wall0 = true;
						if (!b_wall0&&!lb_wall0) {
								GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
								CmdEnableWall (wall [0].name, 0);
								Debug.Log (b_wall0 + " on Client AAAAAAAAAAAAAAAAAAA");
							}
						}
					else if (paint1.Raycast (ray, out hit, Mathf.Infinity)) {
							openedPainting = true;
							//Debug.Log (wall0.name+" on Client");
							//b_wall0 = true;
						if (!b_wall1&&!lb_wall1) {
								GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
								CmdEnableWall (wall [1].name, 1);
								Debug.Log (b_wall1 + " on Client");
							}
						}
					else if (paint2.Raycast (ray, out hit, Mathf.Infinity)) {
							openedPainting = true;//Debug.Log (wall0.name+" on Client");
							//b_wall0 = true;
						if (!b_wall2&&!lb_wall2) {
								GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
								CmdEnableWall (wall [2].name, 2);
								Debug.Log (b_wall2 + " on Client");
							}
						}
					else if (paint3.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;
                        Debug.Log (paint3.name+" on Client");
						//b_wall0 = true;
						if (!b_wall3&&!lb_wall3) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [3].name, 3);
							Debug.Log (b_wall3 + " on Client");
						}
					}
					else if (paint4.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall4&&!lb_wall4) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [4].name, 4);
							Debug.Log (b_wall4 + " on Client");
						}
					}
					else if (paint5.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall5&&!lb_wall5) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [5].name, 5);
							Debug.Log (b_wall5 + " on Client");
						}
					}
					else if (paint6.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall6&&!lb_wall6) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [6].name, 6);
							Debug.Log (b_wall6 + " on Client");
						}
					}
					else if (paint7.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall7&&!lb_wall7) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [7].name, 7);
							Debug.Log (b_wall7 + " on Client");
						}
					}
					else if (paint8.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall8&&!lb_wall8) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [8].name, 8);
							Debug.Log (b_wall8 + " on Client");
						}
					}else if (paint8b.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall8&&!lb_wall8) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [8].name, 8);
							Debug.Log (b_wall8 + " on Client");
						}
					}
					else if (paint9.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;Debug.Log (wall [9].name + " on Client");
						//b_wall0 = true;
						if (!b_wall9&&!lb_wall9) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [9].name, 9);
							Debug.Log (b_wall9 + " on Client");
						}
					}
					else if (paint10.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall10&&!lb_wall10) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [10].name, 10);
							Debug.Log (b_wall10 + " on Client");
						}
					}
					else if (paint11.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall11&&!lb_wall11) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [11].name, 11);
							Debug.Log (b_wall11 + " on Client");
						}
					}
					//else if (paint12.Raycast (ray, out hit, Mathf.Infinity)) {
					//	openedPainting = true;//Debug.Log (wall0.name+" on Client");
					//	//b_wall0 = true;
					//	if (!b_wall12&&!lb_wall12) {
					//		GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
					//		CmdEnableWall (wall [12].name, 12);
					//		Debug.Log (b_wall12 + " on Client");
					//	}
					//}
					else if (paint13.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall13&&!lb_wall13) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [13].name, 13);
							Debug.Log (b_wall13 + " on Client");
						}
					}
					else if (paint14.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall14&&!lb_wall14) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [14].name, 14);
							Debug.Log (b_wall14 + " on Client");
						}
					}
					//else if (paint15.Raycast (ray, out hit, Mathf.Infinity)) {
					//	openedPainting = true;//Debug.Log (wall0.name+" on Client");
					//	//b_wall0 = true;
					//	if (!b_wall15&&!lb_wall15) {
					//		GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
					//		CmdEnableWall (wall [15].name, 15);
					//		Debug.Log (b_wall15 + " on Client");
					//	}
					//}
					//else if (paint16.Raycast (ray, out hit, Mathf.Infinity)) {
					//	openedPainting = true;//Debug.Log (wall0.name+" on Client");
					//	//b_wall0 = true;
					//	if (!b_wall16&&!lb_wall16) {
					//		GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
					//		CmdEnableWall (wall [16].name, 16);
					//		Debug.Log (b_wall16 + " on Client");
					//	}
					//}
					else if (paint17.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall17&&!lb_wall17) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [17].name, 17);
							Debug.Log (b_wall17 + " on Client");
						}
					}
					else if (paint18.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall18&&!lb_wall18) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [18].name, 18);
							Debug.Log (b_wall18 + " on Client");
						}
					}
					else if (paint19.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall19&&!lb_wall19) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [19].name, 19);
							Debug.Log (b_wall19 + " on Client");
						}
					}
					else if (paint20.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall20&&!lb_wall20) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [20].name, 20);
							Debug.Log (b_wall20 + " on Client");
						}
					}
					else if (paint21.Raycast (ray, out hit, Mathf.Infinity)) {
						openedPainting = true;//Debug.Log (wall0.name+" on Client");
						//b_wall0 = true;
						if (!b_wall21&&!lb_wall21) {
							GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdEnableWall (wall [21].name, 21);
							Debug.Log (b_wall21 + " on Client");
						}
					}
					else if (terrain.Raycast (ray, out hit, Mathf.Infinity)) {
						transform.position = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
					}
					if (openedPainting) {
						RaycastHit hitt;
						if (Physics.Raycast (ray,out hitt,Mathf.Infinity)) {
						//Debug.Log(hitt.collider.name);
							if (hitt.collider.name == "happy0") {
								CmdCSound ();
								CmdSmile ();
								Debug.Log ("SMILED:)");
							}
							else if (hitt.collider.name == "neutral") {
								CmdCSound ();
								CmdNeutral();
								Debug.Log ("neutral");
							}else if (hitt.collider.name == "angry0") {
								CmdCSound ();
								CmdAngry();
								Debug.Log ("angry");
							}else if (hitt.collider.name == "wow0") {
								CmdCSound ();
								CmdWow ();
								Debug.Log ("Wow :)");
							}else if (hitt.collider.name == "sad0") {
								CmdCSound ();
								CmdSad();
								Debug.Log ("Sad :(");
							}
						}
						/*Collider smile = GameObject.Find ("happy0").GetComponent<BoxCollider> ();
						Collider wow = GameObject.Find ("wow0").GetComponent<BoxCollider> ();
						Collider neutral = GameObject.Find ("neutral").GetComponent<BoxCollider> ();
						Collider sad = GameObject.Find ("sad0").GetComponent<BoxCollider> ();
						Collider angry= GameObject.Find ("angry0").GetComponent<BoxCollider> ();
						if (smile.Raycast (ray, out hit, Mathf.Infinity)) {
							//Debug.Log (wall0.name+" on Client");
							//b_wall0 = true;
							//GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							//CmdEnableWall (wall [12].name, 12);
							Debug.Log("entered 788");
							CmdSmile();
							Debug.Log ("smile on Client");
						}
						else if (wow.Raycast (ray, out hit, Mathf.Infinity)) {
							//Debug.Log (wall0.name+" on Client");
							//b_wall0 = true;
							//GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							//CmdEnableWall (wall [12].name, 12);
							CmdWow();
							Debug.Log ("wow on Client");
						}
						else if (neutral.Raycast (ray, out hit, Mathf.Infinity)) {
							//Debug.Log (wall0.name+" on Client");
							//b_wall0 = true;
							//GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							//CmdEnableWall (wall [12].name, 12);
							CmdNeutral();
							Debug.Log (  "neutral on Client");
						}
						else if (sad.Raycast (ray, out hit, Mathf.Infinity)) {
							//Debug.Log (wall0.name+" on Client");
							//	b_wall0 = true;
							//GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							//CmdEnableWall (wall [12].name, 12);
							CmdSad();
							Debug.Log ( "sad on Client");
						}
						else if (angry.Raycast (ray, out hit, Mathf.Infinity)) {
							//Debug.Log (wall0.name+" on Client");
							//b_wall0 = true;
							//GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play (0);
							CmdAngry();
							Debug.Log ("angry on Client");
						}*/
					}
				}				//this.transform.position = Input.mousePosition;
			}
			if (activeScene == "Museum") {
				GameObject tar = GameObject.FindWithTag ("Cylinder");
				GameObject sou = GameObject.FindWithTag ("RayS");
				GameObject mid = GameObject.FindWithTag ("RayM");
				GameObject dest = GameObject.FindWithTag ("RayD");
				sou.transform.position = this.transform.position;
				dest.transform.position = tar.transform.position;
				mid.transform.position = new Vector3 ((sou.transform.position.x + dest.transform.position.x) / 2, 3.0f, (sou.transform.position.z + dest.transform.position.z) / 2);
				bool temphs=false;
				bool tempvr=false;
				GameObject[] sounds = GameObject.FindGameObjectsWithTag("Sound");
				foreach (GameObject sound in sounds) {
					//Debug.Log ("sound: "+sound.gameObject.name+" "+temphs);
					if (sound.GetComponent<AudioSource> ().isPlaying) {
						temphs = true;
					}
				}
				GameObject[] videos = GameObject.FindGameObjectsWithTag ("Video");
				foreach (GameObject video in videos) {
					if (video.GetComponent<VideoPlayer> ().isPlaying) {
						tempvr = true;
						temphs = true;
					}
				}
				//				GameObject[] videos = GameObject.FindGameObjectsWithTag("Video");
				//				foreach (GameObject video in videos)
				//					video.GetComponent<VideoPlayer> ().Pause();
				/*if (GameObject.Find ("VideoPotato") != null )
					if(GameObject.Find ("VideoPotato").GetComponent<VideoPlayer> ().isPlaying){
						temphs = true;
						tempvr = true;
					}
				if (GameObject.Find ("VideoCafe") != null )
					if(GameObject.Find ("VideoCafe").GetComponent<VideoPlayer> ().isPlaying){
						temphs = true;
						tempvr = true;
					}
				if (GameObject.Find ("VideoFirstSteps") != null )
					if(GameObject.Find ("VideoFirstSteps").GetComponent<VideoPlayer> ().isPlaying){
						temphs = true;
						tempvr = true;
					}
                */
				CmdHeadVR (temphs, tempvr);
		}	
		//Debug.DrawRay (transform.position, tar.transform.position, Color.red);
		CmdUpdateVelocity ( this.transform.position,this.transform.rotation);

			//anim.SetTrigger ("isWaving");
		//transform.Translate( velocity * Time.deltaTime );
		/*if (Input.GetKey (KeyCode.UpArrow))
		{
			Vector3 t=transform.position + up;
			transform.position = Vector3.Lerp( transform.position, t, Time.deltaTime * latencySmoothingFactor);
			CmdUpdateVelocity ( transform.position);
		}
		if (Input.GetKey (KeyCode.DownArrow))
		{
			Vector3 t=transform.position + down;
			transform.position = Vector3.Lerp( transform.position, t, Time.deltaTime * latencySmoothingFactor);
			CmdUpdateVelocity ( transform.position);
		}		
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			Vector3 t=transform.position + left;
			transform.position = Vector3.Lerp( transform.position, t, Time.deltaTime * latencySmoothingFactor);
			CmdUpdateVelocity ( transform.position);
		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			Vector3 t=transform.position + right;
			transform.position = Vector3.Lerp( transform.position, t, Time.deltaTime * latencySmoothingFactor);
			CmdUpdateVelocity ( transform.position);
		}*/
		//if (Input.GetKeyDown (KeyCode.V)) 
		//	velocity = new Vector3 (1, 0, 0);
		//CmdUpdateVelocity (t, transform.position);
		//}
	}
    /*
	void OnTriggerExit(Collider other){
		if (hasAuthority) {
			if (other.CompareTag ("SR")) {
				CmdSRPlay (false);
				//w1.SetActive (false);
				//w2.SetActive (false);
			}
			else if (other.CompareTag ("Baby")) {
				Debug.Log ("VIDEO:");
				
				CmdVPause (other.gameObject);
				//StartCoroutine (checkVid(other.gameObject));
			}
			else if (other.CompareTag("Potato")){
				CmdVPause(other.gameObject);
				//w1.SetActive (true);
				//w2.SetActive (true);
			}
			else if (other.CompareTag("Cafe")){
				CmdVPause (other.gameObject);
				//w1.SetActive (true);
				//w2.SetActive (true);
			}
		}
	}*/
		
	/*void OnTriggerStay(Collider other){
        if (hasAuthority)
        {
            if (other.CompareTag("SR"))
            {
                CmdSRPlay(true);
                //w1.SetActive (true);
                //w2.SetActive (true);
            }
            else
                CmdVPlay(other.gameObject);
        }
    }*/

	void OnTriggerEnter(Collider other)
	{
		if (hasAuthority) {
			if (other.CompareTag ("RoomDay")) {
				
				bool tempvr = vr.activeSelf;
				bool temphs = headphones.activeSelf;
				nactiveScene = "RoomDay";
				CanvasNight.SetActive (true);
				GameObject[] sounds = GameObject.FindGameObjectsWithTag ("Sound");
				foreach (GameObject sound in sounds) {
					if (sound.GetComponent<AudioSource> ().isPlaying) {
						sound.GetComponent<AudioSource> ().mute = !sound.GetComponent<AudioSource> ().mute;
						temphs = false;
					}
				}
				GameObject[] videos = GameObject.FindGameObjectsWithTag ("Video");
				foreach (GameObject video in videos) {
					if (video.GetComponent<VideoPlayer> ().isPlaying) {
						video.GetComponent<AudioSource> ().mute = !video.GetComponent<AudioSource> ().mute;
						temphs = false;
						tempvr = false;
					}
				}
				if(GameObject.Find ("VideoFirstSteps")!=null){
				//if (GameObject.Find ("paint11").GetComponent<AudioSource> ().isPlaying){
					GameObject.Find ("paint11").GetComponent<AudioSource> ().mute = !GameObject.Find ("paint11").GetComponent<AudioSource> ().mute;
					temphs = false;
					tempvr = false;
					//CmdHeadVR (false, false);
					//headphones.SetActive (false);
					//vr.SetActive (false);
				}
				if (GameObject.Find ("VideoPotato")!=null){
					GameObject.Find ("paint5").GetComponent<AudioSource> ().mute = !GameObject.Find ("paint5").GetComponent<AudioSource> ().mute;
					temphs = false;
					tempvr = false;
					//CmdHeadVR (false, false);
					//headphones.SetActive (false);
					//vr.SetActive (false);
				}
				if (GameObject.Find ("VideoCafe")!=null){
					GameObject.Find ("paint10").GetComponent<AudioSource> ().mute = !GameObject.Find ("paint10").GetComponent<AudioSource> ().mute;
					temphs = false;
					tempvr = false;
					//CmdHeadVR (false, false);
					//headphones.SetActive (false);
					//vr.SetActive (false);
				}	
				CmdHeadVR (temphs, tempvr);
				//ButtonNight.SetActive(true);
				CanvasDay.SetActive(false);
				Debug.Log ("Teleport to " + other.gameObject);
				CmdSSound ();
				FPC.gameObject.GetComponent<OutlineEffect> ().enabled = true;
				TPC.gameObject.GetComponent<OutlineEffect> ().enabled = false;
				FPC.SetActive (true);
				TPC.SetActive (false);
				GameObject.Find ("paint0").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint1").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint2").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint3").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint4").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint5").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint6").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint7").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint8").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint8(1)").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint9").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint10").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint11").GetComponent<cakeslice.Outline> ().enabled=false;
				//GameObject.Find ("paint12").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint13").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint14").GetComponent<cakeslice.Outline> ().enabled=false;
				//GameObject.Find ("paint15").GetComponent<cakeslice.Outline> ().enabled=false;
				//GameObject.Find ("paint16").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint17").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint18").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint19").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint20").GetComponent<cakeslice.Outline> ().enabled=false;
				GameObject.Find ("paint21").GetComponent<cakeslice.Outline> ().enabled=false;
				transform.position = new Vector3 (365f, 0.5f, 23.4f);
				//SceneManager.MoveGameObjectToScene(GameObject.Find("PlayerObject"),SceneManager.GetSceneByName("roomDay"));
				//SceneManager.MoveGameObjectToScene(this.gameObject,SceneManager.GetSceneByName("roomDay"));
				//Debug.Log ("Teleport to " + other.gameObject);
				//transform.position = new Vector3 (3.5f, 0.5f, 23.4f);//GameObject.FindGameObjectWithTag ("Respawn").transform.position;
			}
			else if (other.CompareTag ("Back")) {
				nactiveScene = "Museum";
				//SceneManager.LoadScene ("Scenes/SampleScene");
				//SceneManager.SetActiveScene (SceneManager.GetSceneByName("Scenes/SampleScene"));
				/*CmdChangeScene ("SampleScene");
				Debug.Log ("Teleport to " + other.gameObject);*/
				//GameObject.Find("Canvas").SetActive(false);
				//GameObject.Find("paint11").GetComponent<VideoPlayer>().SetDirectAudioMute(0,true);
				bool tempvr = vr.activeSelf;
				bool temphs =headphones.activeSelf;
				GameObject[] sounds = GameObject.FindGameObjectsWithTag("Sound");
				foreach (GameObject sound in sounds) {
					if (sound.GetComponent<AudioSource> ().isPlaying) {
						sound.GetComponent<AudioSource> ().mute = !sound.GetComponent<AudioSource> ().mute;
						temphs = true;
					}
				}
				GameObject[] videos = GameObject.FindGameObjectsWithTag ("Video");
				foreach (GameObject video in videos) {
					if (video.GetComponent<VideoPlayer> ().isPlaying) {
						video.GetComponent<AudioSource> ().mute = !video.GetComponent<AudioSource> ().mute;
						tempvr = true;
						temphs = true;
					}
				}
//				GameObject[] videos = GameObject.FindGameObjectsWithTag("Video");
//				foreach (GameObject video in videos)
//					video.GetComponent<VideoPlayer> ().Pause();
				if (GameObject.Find ("VideoFirstSteps")!=null){
					GameObject.Find ("paint11").GetComponent<AudioSource> ().mute = !GameObject.Find ("paint11").GetComponent<AudioSource> ().mute;
					temphs = true;
					tempvr = true;
				}
				if (GameObject.Find ("VideoPotato")!=null){
					GameObject.Find ("paint5").GetComponent<AudioSource> ().mute = !GameObject.Find ("paint5").GetComponent<AudioSource> ().mute;
					temphs = true;
					tempvr = true;
				}
				if (GameObject.Find ("VideoCafe")!=null){
					GameObject.Find ("paint10").GetComponent<AudioSource> ().mute = !GameObject.Find ("paint10").GetComponent<AudioSource> ().mute;
					temphs = true;
					tempvr = true;
				}
				CanvasNight.SetActive(false);
				CanvasDay.SetActive(false);
				//ButtonNight.SetActive(false);
				//ButtonDay.SetActive(false);
				Debug.Log ("Teleport to " + other.gameObject);
				transform.position = new Vector3 (-50.34f, 0.5f, 167.34f);
				CmdSSound ();
				CmdHeadVR (temphs, tempvr);
				//transform.position = new Vector3 (3.5f, 0.5f, 23.4f);//GameObject.FindGameObjectWithTag ("Respawn").transform.position;
			}
			else if (other.CompareTag ("Baby")) {
				//CmdPlay (other.gameObject);
			}
			else if (other.CompareTag("Potato")){
				//CmdPlay (other.gameObject);
			}
			else if (other.CompareTag("Cafe")){
				//CmdPlay (other.gameObject);
			}
		}
	}

	public Sprite sprite;
	public IEnumerator checkVid(GameObject go){
		Debug.Log ("Started");
		VideoPlayer vp=go.GetComponent<VideoPlayer>();
		yield return new WaitForSeconds(28);
		Debug.Log ("while ended");
		vp.enabled=false;
		SpriteRenderer renderer = go.GetComponent<SpriteRenderer>();
		renderer.sprite = sprite;
		Debug.Log ("finished");
		//yield return null;
	
	}

	[Command]
	void CmdHeadVR(bool head,bool vrb){
		headphones.SetActive (head);
		vr.SetActive (vrb);
		RpcHeadVR (head, vrb);
	}

	[Command]
	void CmdMoveHim(Vector3 p,Quaternion r,GameObject go){
		Debug.Log ("Move him entered on " + go.name);
		go.transform.position = p;
		go.transform.rotation = r;
		go.GetComponent<PlayerCapsule> ().bestGuessPosition = p;
		go.GetComponent<PlayerCapsule> ().bestGuessRotation = r;
		RpcMoveHim(p, r,go);
		Debug.Log ("Move him exit on " + go.name);
	}


    [Command]
    void CmdPlay(GameObject other)
    {
        //anim.SetTrigger ("isWaving");
        //waving=true;
        //CmdHeadVR(true,true);
        RpcPlay(other.gameObject);
        //StartCoroutine (serverwait (other.gameObject));
    }

    [Command]
    void CmdVPlay(GameObject other)
    {
        //anim.SetTrigger ("isWaving");
        //waving=true;
        //CmdHeadVR(true,true);
        RpcVPlay(other.gameObject);
        //StartCoroutine (serverwait (other.gameObject));
    }

    

    [Command]
	void CmdPause(GameObject other)
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		//CmdHeadVR(true,true);
		RpcPause (other.gameObject);
		//StartCoroutine (serverwait (other.gameObject));
	}

    [Command]
	void CmdVPause(GameObject other)
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		//CmdHeadVR(true,true);
		RpcVPause (other.gameObject);
		//StartCoroutine (serverwait (other.gameObject));
	}

	[Command]
    void CmdSRPlay(bool flag)
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcSRPlay (flag);
	}
		
	[Command]
	void CmdChangeScene(string newScene)
	{
		RpcChangeScene (newScene);
	}

	[Command]
	void CmdUpdateVelocity(  Vector3 p,Quaternion r)
	{
		Debug.Log ("Entered cmdUpdateVelocity on " + this.name);
		// I am on a server
		transform.position = p;
		transform.rotation = r;

		// If we know what our current latency is, we could do something like this:
		//  transform.position = p + (v * (thisPlayersLatencyToServer))


		// Now let the clients know the correct position of this object.
		RpcUpdateVelocity( transform.position,transform.rotation);
	}

	[Command]
	void CmdWave()
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcWave ();
	}

	[Command]
	void CmdCome()
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcCome ();
	}

	[Command]
	void CmdDrag(){
		RpcDrag ();
	}
	/*
	[Command]
	void CmdEnabled(string wall){
		GameObject[] paints2 =Resources.FindObjectsOfTypeAll<GameObject>();
		for (int i = 0; i < paints2.Length; i++) {
			if (paints2 [i].name == wall) {
				if (paints2 [i].activeInHierarchy)
					return true;
				else
					return false;
			}
		}
		return false;
	}*/

	[Command]
	void CmdRequest (){
		RpcSend ();
	}

	[Command]
	void CmdSmile(){
		RpcSmile ();
	}

	[Command]
	void CmdSad(){
		RpcSad();
	}

	[Command]
	void CmdNeutral(){
		RpcNeutral();
	}

	[Command]
	void CmdWow(){
		RpcWow ();
	}

	[Command]
	void CmdAngry(){
		RpcAngry();
	}

	[Command]
	void CmdEnableWall(string wall,int index)
	{
		GameObject[] paints =Resources.FindObjectsOfTypeAll<GameObject>();
		for (int i = 0; i < paints.Length; i++) {
			if (paints [i].name == wall) {
				Debug.Log (paints [i].name + " on CMD");
                Debug.Log(paints[i].activeInHierarchy+ " is active before");
                paints[i].SetActive (true);
                Debug.Log(paints[i].activeInHierarchy + " is active after");
                if (index == 0) {
					b_wall0 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall0 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall0 = true;
				} else if (index == 1) {
					b_wall1 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall1 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall1 = true;
				} else if (index == 3) {
					b_wall3 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall3 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall3 = true;
				} else if (index == 2) {
					b_wall3 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall2 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall2 = true;
				} else if (index == 4) {
					b_wall4 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall4 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall4 = true;
				} else if (index == 5) {
					b_wall5 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall5 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall5 = true;
				} else if (index == 6) {
					b_wall6 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall6 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall6 = true;
				} else if (index == 7) {
					b_wall7 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall7 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall7 = true;
				} else if (index == 8) {
					b_wall8 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall8 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall8 = true;
				} else if (index == 9) {
					b_wall9 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall9 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall9 = true;
				} else if (index == 10) {
					b_wall10 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall10 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall10 = true;
				}
				else if (index == 11) {
					b_wall11 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall11 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall11 = true;
				}
				//else if (index == 12) {
				//	b_wall12 = true;
				//	if (this.name == "remy(Clone)")
				//		GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall12 = true;
				//	else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
				//		GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall12 = true;
				//}
				else if (index == 13) {
					b_wall13 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall13 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall13 = true;
				}
				else if (index == 14) {
					b_wall14 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall14 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall14 = true;
				}
				//else if (index == 15) {
				//	b_wall15 = true;
				//	if (this.name == "remy(Clone)")
				//		GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall15 = true;
				//	else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
				//		GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall15 = true;
				//}
				//else if (index == 16) {
				//	b_wall16 = true;
				//	if (this.name == "remy(Clone)")
				//		GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall16 = true;
				//	else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
				//		GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall16 = true;
				//}
				else if (index == 17) {
					b_wall17 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall17 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall17 = true;
				}
				else if (index == 18) {
					b_wall18 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall18 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall18 = true;
				}
				else if (index == 19) {
					b_wall19 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall19 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall19 = true;
				}
				else if (index == 20) {
					b_wall20 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall20 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall20 = true;
				}
				else if (index == 21) {
					b_wall21 = true;
					if (this.name == "remy(Clone)")
						GameObject.Find ("claire(Clone)").GetComponent<PlayerCapsule> ().b_wall21 = true;
					else if (this.name == "claire(Clone)"&&GameObject.Find ("remy(Clone)")!=null)
						GameObject.Find ("remy(Clone)").GetComponent<PlayerCapsule> ().b_wall21 = true;
				}
				//GameObject.Find ("NWManager").GetComponent<NManager> ().CmdEnabl();
				//f_onHook (true);
				//paintings [index] = true;
				//paintings.Dirty (index);
				Debug.Log (b_wall0 + " OOKOK:");
				RpcEnableWall (wall,index);
				//return b_wall0;
				break;
			}
		}
		//return b_wall0;
//		Debug.Log (wall.name+"CMD");
//		wall.SetActive(true);
//		//waving=true;
//		RpcEnableWall (wall.name);
	}

	[Command]
	void CmdPoint()
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcPoint();
	}

	[Command]
	void CmdDance()
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcDance();
	}

	[Command]
	void CmdRoll()
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcRoll();
		//FPC.transform.position =temp+ this.transform.forward*1.5f;
		Vector3 temp=this.transform.position+this.transform.forward*2;
		CmdUpdateVelocity(temp,this.transform.rotation);
	}

	IEnumerator waiter(GameObject go)
	{
		go.SetActive(true);
		yield return new WaitForSeconds(30);
		go.SetActive (false);

	}

	[Command]
	void CmdSSound(){
		RpcSSound();
	}

	[Command]
	void CmdCSound(){
		RpcCSound();
	}

	[Command]
	void CmdWalk()
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcWalk ();
	}

	[Command]
	void CmdNotWalk()
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcNotWalk ();
	}

	[ClientRpc]
	void RpcSmile(){
		smile.SetActive (true);
		StartCoroutine (waiter (smile));
	}

	[ClientRpc]
	void RpcNeutral(){
		neutral.SetActive (true);
		StartCoroutine (waiter (neutral));
	}

	[ClientRpc]
	void RpcSad(){
		sad.SetActive (true);
		StartCoroutine (waiter (sad));
	}

	[ClientRpc]
	void RpcWow(){
		wow.SetActive (true);
		StartCoroutine (waiter (wow));
	}

	[ClientRpc]
	void RpcAngry(){
		angry.SetActive (true);
		StartCoroutine (waiter (angry));
	}

	[ClientRpc]
	void RpcHeadVR(bool head,bool vrb){
		headphones.SetActive (head);
		vr.SetActive (vrb);
	}

	[ClientRpc]
	void RpcSend(){
		Debug.Log("RPC send "+GameObject.Find("NWManager").GetComponent<NManager>().wall0);
		lb_wall0 = GameObject.Find("NWManager").GetComponent<NManager>().wall0;
	}

	[ClientRpc]
	void RpcMoveHim(Vector3 p,Quaternion r,GameObject go){
		go.transform.position = p;
		go.transform.rotation= r;
		go.GetComponent<PlayerCapsule>().bestGuessPosition= p;
		go.GetComponent<PlayerCapsule> ().bestGuessRotation = r;
//		if (localPlayerAuthority) {
//			Debug.Log ("RPCMOVE go pos "+go.transform.position);
//			Debug.Log ("RPCMOVE my pos "+this.transform.position);
//			Debug.Log ("RPCMOVE p "+p);
//			this.transform.LookAt(p);
//		}
	}
		
	[ClientRpc]
	void RpcEnableWall(string wall,int index)
	{	
		//if (isServer)
		//b_wall0=true;
		//if (isLocalPlayer)
		//	return;
		GameObject[] paints=Resources.FindObjectsOfTypeAll<GameObject>();
		for (int i = 0; i < paints.Length; i++) 
			if (paints [i].name == wall) {
				paints [i].SetActive (true);
				if (index == 0) {
					b_wall0 = true;
					lb_wall0 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==1){
					b_wall1 = true;
					lb_wall1 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==2){
					b_wall2 = true;
					lb_wall2 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==3){
					b_wall3 = true;
					lb_wall3 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==4){
					b_wall4 = true;
					lb_wall4 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==5){
					b_wall5 = true;
					lb_wall5 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==6){
					b_wall6 = true;
					lb_wall6 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==7){
					b_wall7 = true;
					lb_wall7 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==8){
					b_wall8 = true;
					lb_wall8 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==9){
					b_wall9 = true;
					lb_wall9 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==10){
					b_wall10 = true;
					lb_wall10 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==11){
					b_wall11 = true;
					lb_wall11 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				//else if (index==12){
				//	b_wall12 = true;
				//	lb_wall12 = true;
				//	GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				//}
				else if (index==13){
					b_wall13 = true;
					lb_wall13 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==14){
					b_wall14 = true;
					lb_wall14 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				//else if (index==15){
				//	b_wall15 = true;
				//	lb_wall15 = true;
				//	GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				//}
				//else if (index==16){
				//	b_wall16 = true;
				//	lb_wall16 = true;
				//	GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				//}
				else if (index==17){
					b_wall17 = true;
					lb_wall17 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==18){
					b_wall18 = true;
					lb_wall18 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==19){
					b_wall19 = true;
					lb_wall19 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==20){
					b_wall20 = true;
					lb_wall20 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				else if (index==21){
					b_wall21 = true;
					lb_wall21 = true;
					GameObject.Find ("ShowAMenu").GetComponent<AudioSource> ().Play(0);
				}
				break;
			}
		Debug.Log ("RPC is "+b_wall0);


	}

	[ClientRpc]
	void RpcChangeScene(string newScene)
	{
		if (hasAuthority) {
			Debug.Log (this.gameObject.name+ " HAS AUTH");
		} else {
			Debug.Log (this.gameObject.name+" new Scene is " + newScene);
			Debug.Log (this.gameObject.name+" active Scene is " + SceneManager.GetActiveScene().name);
			if (newScene==SceneManager.GetActiveScene().name){
				this.enabled = false;
				//Debug.Log ("EQUALS");
			}
		}
	}

	[ClientRpc]
	void RpcPause(GameObject other)
	{
		if (other.name == "paint11") {
            VideoToAnimate.GetComponent<VideoPlayer>().Pause();
            VideoToAnimate.GetComponent<cakeslice.Outline>().enabled = false;
            VideoToAnimate.SetActive(false);
		} else if (other.name == "paint5") {
			VideoToAnimate2.GetComponent<VideoPlayer> ().Pause ();	
			VideoToAnimate2.GetComponent<cakeslice.Outline> ().enabled = false;
			VideoToAnimate2.SetActive (false);
		}
		else if (other.name == "paint10") {
			VideoToAnimate3.GetComponent<VideoPlayer> ().Pause ();	
			VideoToAnimate3.GetComponent<cakeslice.Outline> ().enabled = false;
			VideoToAnimate3.SetActive (false);
		}

	}

    [ClientRpc]
	void RpcVPause(GameObject other)
	{
        if (other.name == "paint11")
        {   
            VideoToAnimate.GetComponent<VideoPlayer>().Pause();
            VideoToAnimate.GetComponent<cakeslice.Outline>().enabled = false;
            VideoToAnimate.SetActive(false);
        }
        else if (other.name == "paint5")
        {
            VideoToAnimate2.GetComponent<VideoPlayer>().Pause();
            VideoToAnimate2.GetComponent<cakeslice.Outline>().enabled = false;
            VideoToAnimate2.SetActive(false);
        }
        else if (other.name == "paint10")
        {
            VideoToAnimate3.GetComponent<VideoPlayer>().Pause();
            VideoToAnimate3.GetComponent<cakeslice.Outline>().enabled = false;
            VideoToAnimate3.SetActive(false);
        }
    }

	[ClientRpc]
	void RpcPlay(GameObject other)
	{
		if (other.name == "paint11") {
			VideoToAnimate.SetActive (true);
			VideoToAnimate.GetComponent<VideoPlayer> ().Play ();
			VideoToAnimate.GetComponent<cakeslice.Outline> ().enabled = true;
			StartCoroutine (videowait (VideoToAnimate));
		} else if (other.name == "paint5") {
			VideoToAnimate2.SetActive (true);
			VideoToAnimate2.GetComponent<VideoPlayer> ().Play ();
			VideoToAnimate2.GetComponent<cakeslice.Outline> ().enabled = true;
			StartCoroutine (videowait (VideoToAnimate2));
		}
		else if (other.name == "paint10") {
			VideoToAnimate3.SetActive (true);
			VideoToAnimate3.GetComponent<VideoPlayer> ().Play ();
			VideoToAnimate3.GetComponent<cakeslice.Outline> ().enabled = true;
			StartCoroutine (videowait (VideoToAnimate3));
		}
//		VideoPlayer vp = other.GetComponent<VideoPlayer>();
//		vp.enabled = true;
//		vp.Play ();
		//vp.isplaying;
	}

	IEnumerator videowait(GameObject go)
	{
		yield return new WaitForSeconds((float)go.GetComponent<VideoPlayer> ().clip.length);
		go.GetComponent<cakeslice.Outline> ().enabled = false;
		go.SetActive (false);
	}

	IEnumerator serverwait(GameObject go)
	{
		yield return new WaitForSeconds((float)go.GetComponent<VideoPlayer> ().clip.length);
		CmdHeadVR(false,false);
	}

    [ClientRpc]
    void RpcSRPlay(bool flag)
    {
        //w1.GetComponent<cakeslice.Outline>().enabled = flag;
        w1.SetActive(flag);
    }

    [ClientRpc]
    void RpcVPlay(GameObject other)
    {
        //w1.GetComponent<cakeslice.Outline>().enabled = flag;
        if (other.name == "paint11")
        {
            if (!VideoToAnimate.GetComponent<VideoPlayer>().isPlaying)
            {
                VideoToAnimate.SetActive(true);
                VideoToAnimate.GetComponent<VideoPlayer>().Play();
                VideoToAnimate.GetComponent<cakeslice.Outline>().enabled = true;
                StartCoroutine(videowait(VideoToAnimate));
            }
        }
        else if (other.name == "paint5")
        {
            if (!VideoToAnimate2.GetComponent<VideoPlayer>().isPlaying)
            {
                VideoToAnimate2.SetActive(true);
                VideoToAnimate2.GetComponent<VideoPlayer>().Play();
                VideoToAnimate2.GetComponent<cakeslice.Outline>().enabled = true;
                StartCoroutine(videowait(VideoToAnimate2));
            }
        }
        else if (other.name == "paint10")
        {
            if (!VideoToAnimate3.GetComponent<VideoPlayer>().isPlaying)
            {
                VideoToAnimate3.SetActive(true);
                VideoToAnimate3.GetComponent<VideoPlayer>().Play();
                VideoToAnimate3.GetComponent<cakeslice.Outline>().enabled = true;
                StartCoroutine(videowait(VideoToAnimate3));
            }
        }
    }
   

    [ClientRpc]
	void RpcSSound()
	{
		GameObject.Find ("SpawnSound").GetComponent<AudioSource> ().Play(0);
	}

	[ClientRpc]
	void RpcCSound()
	{
		GameObject.Find ("CloudSound").GetComponent<AudioSource> ().Play(0);
	}

	[ClientRpc]
	void RpcWave()
	{
		if(this.name=="claire(Clone)")
			GameObject.Find ("WaveClaire").GetComponent<AudioSource> ().Play(0);
		else
			GameObject.Find ("WaveRemy").GetComponent<AudioSource> ().Play(0);
		if (!hasAuthority){
			anim.SetTrigger ("isWaving");
		}
	}

	[ClientRpc]
	void RpcCome()
	{
		if (this.name == "claire(Clone)")
			GameObject.Find ("ComeClaire").GetComponent<AudioSource> ().Play (0);
		else
			GameObject.Find ("ComeRemy").GetComponent<AudioSource> ().Play (0);
		if (!hasAuthority) {
			anim.SetTrigger ("isCome");
		}
	}

	[ClientRpc]
	void RpcDrag(){
		GameObject.Find ("DragSound").GetComponent<AudioSource> ().Play (0);
	}

	[ClientRpc]
	void RpcPoint()
	{
		if (this.name == "claire(Clone)")
			GameObject.Find ("PointClaire").GetComponent<AudioSource> ().Play (0);
		else
			GameObject.Find ("PointRemy").GetComponent<AudioSource> ().Play (0);
		if (!hasAuthority) {
			anim.SetTrigger ("isPointing");
		}
	}

	[ClientRpc]
	void RpcDance()
	{
		//if (!hasAuthority) {
		anim.SetTrigger ("isDance");
		//}
	}

	[ClientRpc]
	void RpcRoll()
	{
		//if (!hasAuthority) {
		anim.SetTrigger ("isRoll");
		//anim.SetBool ("isRolling", true);
		//}
	}

	[ClientRpc]
	void RpcWalk()
	{
		if (!hasAuthority)
			anim.SetBool("isWalking",true);
	}

	[ClientRpc]
	void RpcNotWalk()
	{
		if (!hasAuthority)
			anim.SetBool("isWalking",false);
	}

	[ClientRpc]
	void RpcUpdateVelocity(  Vector3 p,Quaternion r )
	{
		// I am on a client

		if( hasAuthority )
		{
			// Hey, this is my own object. I "should" already have the most accurate
			// position/velocity (possibly more "Accurate") than the server
			// Depending on the game, I MIGHT want to change to patch this info
			// from the server, even though that might look a little wonky to the user.

			// Let's assume for now that we're just going to ignore the message from the server.
			return;
		}

		// I am a non-authoratative client, so I definitely need to listen to the server.

		// If we know what our current latency is, we could do something like this:
		//transform.position = p + (velocity * (ourLatency));

		//transform.position = p;

		bestGuessPosition = p ;
		bestGuessRotation = r;



		// Now position of player one is as close as possible on all player's screens

		// IN FACT, we don't want to directly update transform.position, because then 
		// players will keep teleporting/blinking as the updates come in. It looks dumb.


	}
}
