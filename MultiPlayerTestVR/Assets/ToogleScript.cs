using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToogleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void valueChanged(Toggle t)
    {
        if (t.isOn)
        {
            t.GetComponentInChildren<Text>().text = "Hide Scoreboard";
        }
        else
        {
            t.GetComponentInChildren<Text>().text = "Show Scoreboard";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
