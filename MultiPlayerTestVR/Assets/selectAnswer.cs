using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectAnswer : MonoBehaviour
{
    public InitPPlayer ipp;
    public GameObject ad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.LogError("Trigger");
        if (other.name.Contains("Avatar")){
            if (this.name.Contains("Yes"))
                ipp.yesHandler();
            else if (this.name.Contains("No"))
                ipp.noHandler();
            else
                ipp.guestHandler();
            ad.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
