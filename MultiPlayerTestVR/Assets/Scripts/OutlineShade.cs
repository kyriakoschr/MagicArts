using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OutlineShade : NetworkBehaviour {
	public Material[] BothOutlines;
	public Material second;
	public GameObject body;
	public Material none;

	void Start () {
		if (this.name == "claire(Clone)") {
			Debug.Log ("AAAAAAAAAAAAAA!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			body = this.transform.Find ("Girl_Body_Geo").gameObject;
		}
		else {
			Debug.Log ("Q!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			body = this.transform.Find ("Body").gameObject;
		}
		BothOutlines=body.GetComponent<SkinnedMeshRenderer> ().materials ;
		BothOutlines [1] = none;
		body.GetComponent<SkinnedMeshRenderer> ().materials = BothOutlines;
		Debug.Log (body.GetComponent<SkinnedMeshRenderer> ().materials[0]);
		Debug.Log (body.GetComponent<SkinnedMeshRenderer> ().materials[1]);
	}

	void OnMouseOver(){
		if (hasAuthority)
			return;
		Debug.Log ("MOUSSSSSSSSSSSSSSSEEEEEEEEEEEEE");
		BothOutlines [1] = second;
		body.GetComponent<SkinnedMeshRenderer> ().materials = BothOutlines;
	}

	void OnMouseExit(){
		if (hasAuthority)
			return;
		BothOutlines [1] = none;
		body.GetComponent<SkinnedMeshRenderer> ().materials = BothOutlines;
	}
}