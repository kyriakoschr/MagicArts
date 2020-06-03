using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour {
	public GameObject Menu;
	public Button MyButton;
	// Use this for initialization
	void Start () {
		Button btn1 = MyButton.GetComponent<Button> ();
		btn1.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick() {
		Debug.Log ("Clicked exit");
		Menu.SetActive (false);
	}


}
