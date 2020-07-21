﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Networking;
using Tilia.Locomotors.Teleporter;

public class Teleport : MonoBehaviour {

	public GameObject simulator;
	public TeleporterFacade teleporter;
	public Transform roomDay;
	public Transform museum;
	public int inMuseum = 0;
	public GameObject sound;
	public GameObject canvasD;
	public GameObject canvasN;

	public void teleTo(Transform to)
	{
		teleporter.Teleport(to);
		/*if (simulator.activeInHierarchy) {
			canvasD.SetActive(!canvasD.activeInHierarchy);
			canvasN.SetActive(!canvasN.activeInHierarchy);
		}*/
		sound.GetComponent<AudioSource>().Play();
	}

	void OnTriggerEnter(Collider other) 
	{
		Debug.Log(other.tag+" is tag");
		if (other.name.Equals("ExampleAvatar") && other.CompareTag ("NonTeleportable")) {
			Debug.Log(inMuseum + " in museuem");
			if (inMuseum.Equals(0))
			{
				teleporter.Teleport(roomDay);
				if (simulator.activeInHierarchy)
					canvasN.SetActive(true);
			}
			else {
				teleporter.Teleport(museum);
				if (simulator.activeInHierarchy)
                {
					canvasD.SetActive(false);
					canvasN.SetActive(false);
                }
			}
			sound.GetComponent<AudioSource>().Play();
		}
	}
		
}