using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetMan: NetworkManager
{
    public UnityEngine.UI.Text IP;
    public UnityEngine.UI.Text username;
    public GameObject canvas;

    public void OnClickHost()
    {
        StartHost();
        //canvas.active = false;
    }

    public void OnClickClient()
    {
        // get the host IP from the input box
        string hostIp = IP.text;

        // Set the networkAddress to the hostIp (this is inherited from NetworkManager)
        networkAddress = hostIp;

        // Start the client
        StartClient();
        //canvas.active = false;
    }
}