using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour {
	public GameObject FPC;
	public GameObject TPC;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(1,0.5f,20);

		//FPC = GameObject.FindWithTag ("MainCamera");
		//TPC = GameObject.FindWithTag ("TMainCamera");
	}

	// Update is called once per frame
	void Update (){
		//if (transform.position.x < 27.5f && transform.position.x > -28 && transform.position.z < 52.3f && transform.position.z> -55.6f) {//FPC = GameObject.FindWithTag ("MainCamera");
			//TPC = GameObject.FindWithTag ("TMainCamera");
			RaycastHit hit;
			Camera cam;
			Ray ray;
			if (TPC.activeInHierarchy) {
				cam = TPC.GetComponent<Camera> ();
				ray = cam.ScreenPointToRay (Input.mousePosition);
			} else {
				cam = FPC.GetComponent<Camera> ();
				ray = cam.ScreenPointToRay (Input.mousePosition);
			}
			Collider terrain = GameObject.FindWithTag ("Terrain").GetComponent<MeshCollider> ();
			//Debug.Log ("Terrain name is " + terrain.name);

			if (terrain.Raycast (ray, out hit, Mathf.Infinity)) {
				transform.position = new Vector3( hit.point.x,transform.position.y,hit.point.z);
			}
		//}
	}
}
