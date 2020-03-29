using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
	public GameObject m_FirstButton,m_SecondButton;
	// Use this for initialization
	void Start () {
		Button btn1 = m_FirstButton.GetComponent<Button> ();
		Button btn2 = m_SecondButton.GetComponent<Button> ();
		btn2.onClick.AddListener (delegate{TaskWithParameters("Hello");});
		btn1.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		Debug.Log ("On Click");
	}

	void TaskWithParameters(string message){
		Debug.Log (message);
	}
}
