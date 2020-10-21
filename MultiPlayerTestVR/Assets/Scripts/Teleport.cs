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
	public Transform roomDay;
	public Transform museum;
	public int inMuseum = 0;
	public GameObject sound;
	public GameObject canvasD;
	public GameObject canvasN;
	public Zinnia.Action.ToggleAction toggleAction;
	public static bool entered = false;

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
		if (simulator.activeSelf)
		{
			if (other.name.Equals("ExampleAvatar") && other.CompareTag("NonTeleportable"))
			{
				Debug.Log(other.name + " is tag");
				Debug.Log(inMuseum + " in museuem");
				if (inMuseum.Equals(0))
				{
					teleporter.Teleport(roomDay);
					/*if (simulator.activeInHierarchy) {
						Cursor.visible = true;
						canvasN.SetActive(true);
						Debug.LogError(this.gameObject.name);
						toggleAction.Receive(true);
					}*/
				}
				else
				{
					teleporter.Teleport(museum);
					/*if (simulator.activeInHierarchy)
					{
						Cursor.visible = false;
						canvasD.SetActive(false);
						canvasN.SetActive(false);
						toggleAction.Receive(true);
					}*/
				}
				sound.GetComponent<AudioSource>().Play();
			}
		}
        else
        {
			if ((other.name.Contains("ExampleAvatar")||(other.name.Equals("Capsule"))) && other.CompareTag("NonTeleportable"))
			{
				Debug.Log(other.name + " is tag");
				Debug.Log(inMuseum + " in museuem");
				if (inMuseum.Equals(0))
				{
					teleporter.Teleport(roomDay);
					/*if (simulator.activeInHierarchy) {
						Cursor.visible = true;
						canvasN.SetActive(true);
						Debug.LogError(this.gameObject.name);
						toggleAction.Receive(true);
					}*/
				}
				else
				{
					teleporter.Teleport(museum);
					/*if (simulator.activeInHierarchy)
					{
						Cursor.visible = false;
						canvasD.SetActive(false);
						canvasN.SetActive(false);
						toggleAction.Receive(true);
					}*/
				}
				sound.GetComponent<AudioSource>().Play();
			}
		}
	}
		
}