using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkColls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("Collision with " + collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
