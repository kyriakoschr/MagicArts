using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHand : MonoBehaviour
{
    public Transform choices;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent.parent.parent.parent.parent.name.Equals("Right"))
            this.gameObject.SetActive( false);
        else
            GameObject.Find("TurnTable").GetComponent<TurnTable>().SetPPanel(choices);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
