using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchModes : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;

    // Start is called before the first frame update
    public void onEnable()
    { 
        t1 = this.transform.Find("Button.Switch to HMD mode").gameObject;
        t2 = this.transform.Find("Button.Switch to PC mode").gameObject;
        t1.GetComponent<Button>().onClick.AddListener(showSwitchToHMD);
        t2.GetComponent<Button>().onClick.AddListener(showSwitchToPC);
        t2.SetActive(false);
    }

    public void showSwitchToHMD(){
        t1.SetActive(false);
        t2.SetActive(true);
    }

    public void showSwitchToPC(){
        t1.SetActive(true);
        t2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
