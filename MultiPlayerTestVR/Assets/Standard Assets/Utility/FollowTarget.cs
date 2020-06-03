using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 0f, 0f);


        void Update()
        {
            //Vector3 v = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            //Quaternion q = new Quaternion(0, target.rotation.y, 0, 0);
            //Quaternion q = new Quaternion(this.transform.rotation.x, target.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            //transform.position = v;
            //this.transform.rotation.Set(0,target.rotation.y,0,0);

            //transform.rotation = Quaternion.Euler(-target.transform.rotation.x, target.transform.rotation.y, -target.transform.rotation.z);

            //var rotation = Quaternion.LookRotation(Vector3.forward);
            //transform.rotation = rotation;
        }
    }
}
