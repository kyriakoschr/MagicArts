using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CopyScript : MonoBehaviourPun
{
    public float z = 0f; 
    public float y = -17f; 
    public float x = 0f;
    // Start is called before the first frame update
    void Start()
    {
        /*if (photonView.IsMine)
        {
            transform.position = ViveManager.Instance.avatar.transform.position;
            Vector3 temp = new Vector3(x, y, z);
            transform.position += temp;
            transform.parent = ViveManager.Instance.avatar.transform;
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            //Transform t = new Transform();
            //ViveManager.Instance.avatar.transform;
            transform.position = ViveManager.Instance.avatar.transform.position;
            Vector3 temp = new Vector3(x, y, z);
            transform.position += temp;
            Transform t = this.transform;
            t.eulerAngles = new Vector3(0, t.rotation.eulerAngles.y, 0);
            //transform.rotation = ViveManager.Instance.avatar.transform.rotation;
        }
    }

    void LateUpdate()
    {
        /*Transform t = this.transform;
        t.eulerAngles = new Vector3(0, t.rotation.eulerAngles.y, 0);*/

    }
}
