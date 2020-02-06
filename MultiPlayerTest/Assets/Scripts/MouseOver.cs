using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cakeslice
{
public class MouseOver : MonoBehaviour {

	//private 
	void Start(){
		this.GetComponent<Outline>().enabled = false;
	}

	// Use this for initialization
	void OnMouseOver () {
		this.GetComponent<Outline>().enabled = true;
	}
	
	// Update is called once per frame
	void OnMouseExit () {
		this.GetComponent<Outline>().enabled = false;
	}
}
}