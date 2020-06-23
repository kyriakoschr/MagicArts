using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    public float minRotation = -40;
    public float maxRotation = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
        transform.rotation = Quaternion.Euler(currentRotation);
        /*if (transform.rotation.x > 40)
            transform.rotation.Set(40, transform.rotation.y, transform.rotation.z,transform.rotation.w);
        else if (transform.rotation.x < -40)
            transform.rotation.Set(-40, transform.rotation.y, transform.rotation.z, transform.rotation.w);*/
    }
}
