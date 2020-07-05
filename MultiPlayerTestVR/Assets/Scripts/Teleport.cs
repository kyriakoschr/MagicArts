using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Networking;
using Tilia.Locomotors.Teleporter;

public class Teleport : MonoBehaviour {

	public GameObject simulator;
	public TeleporterFacade teleporter;
	public TeleporterFacade teleporterSim;
	public TeleporterFacade teleporterUXR;
	public Transform roomDay;
	public Transform museum;
	public int inMuseum = 0;
	public GameObject sound;

	public void teleTo(Transform to)
	{
		teleporter.Teleport(to);
		sound.GetComponent<AudioSource>().Play();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (simulator.activeInHierarchy)
			teleporter = teleporterSim;
		else
			teleporter = teleporterUXR; 
		if (other.name.Equals("ExampleAvatar") && other.CompareTag ("NonTeleportable")) {
			Debug.Log(inMuseum + " in museuem");
			if (inMuseum.Equals(0))
				teleporter.Teleport(roomDay);
			else
				teleporter.Teleport(museum);
			sound.GetComponent<AudioSource>().Play();
		}
	}
		
}