
//Attach to player object
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Voice : NetworkBehaviour
{
	public Animator anim ;

	int lastSample;
	AudioClip c;
	public int FREQUENCY = 44100; //Default 44100
	public int length = 50;

	void Start()
	{
		//Debug.Log (Microphone.devices[0]);
		//Microphone.devices[0]+Microphone.devices[1]
		anim = GetComponent< Animator> ();
		//if (hasAuthority)
		//{
			c = Microphone.Start(Microphone.devices[0], true, length, FREQUENCY);
			while (Microphone.GetPosition(Microphone.devices[0]) < 0) { }
		//}
	}

	void FixedUpdate()
	{
		if (hasAuthority)
		{
			//if (Input.GetKey(KeyCode.V))
			//{
				Debug.Log ("Voice");
				anim.SetTrigger ("isShouting");
				//Debug.Log ("Have to wave mine");
				CmdShout ();
				int pos = Microphone.GetPosition(Microphone.devices[0]);
				Debug.Log ("Pos is " + pos);
				Debug.Log ("Last sample is " + lastSample);
				int diff = pos - lastSample;
				if (diff > 0)
				{
					float[] samples = new float[diff ];
					c.GetData(samples, lastSample);
					byte[] ba = ToByteArray(samples);

					Cmd_SendRPC(ba, c.channels);
				}
				lastSample = pos;
			//}

		}
	}

	[ClientRpc]
	public void Rpc_Send(byte[] ba, int chan)
	{
		ReciveData(ba, chan);
	}

	[Command]
	public void Cmd_SendRPC(byte[] ba, int chan)
	{
		ReciveData(ba, chan);
		Rpc_Send(ba, chan);
	}

	void ReciveData(byte[] ba, int chan)
	{
		float[] f = ToFloatArray(ba);
		GetComponent<AudioSource>().clip = AudioClip.Create("test", f.Length, chan, FREQUENCY, true, false);
		GetComponent<AudioSource>().clip.SetData(f, 0);
		if (!GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
	}

	public byte[] ToByteArray(float[] floatArray)
	{
		int len = floatArray.Length * 4;
		byte[] byteArray = new byte[len];
		int pos = 0;
		foreach (float f in floatArray)
		{
			byte[] data = System.BitConverter.GetBytes(f);
			System.Array.Copy(data, 0, byteArray, pos, 4);
			pos += 4;
		}
		return byteArray;
	}

	public float[] ToFloatArray(byte[] byteArray)
	{
		int len = byteArray.Length / 4;
		float[] floatArray = new float[len];
		for (int i = 0; i < byteArray.Length; i += 4)
		{
			floatArray[i / 4] = System.BitConverter.ToSingle(byteArray, i);
		}
		return floatArray;
	}

	[Command]
	void CmdShout()
	{
		//anim.SetTrigger ("isWaving");
		//waving=true;
		RpcShout();
	}
	[ClientRpc]
	void RpcShout()
	{
		if (!hasAuthority)
			anim.SetTrigger ("isShouting");
	}


}

