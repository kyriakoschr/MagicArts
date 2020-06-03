using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KeepOpenedArtifacts : NetworkBehaviour
{
    public class Artifact
    {
        public GameObject painting;
        public int audioVideo;
        public Coroutine cour;

        public Artifact(GameObject p, int av, Coroutine c)
        {
            painting = p;
            audioVideo = av;
            cour = c;
        }

        public Artifact(Artifact aa)
        {
            painting = aa.painting;
            audioVideo = aa.audioVideo;
            cour = aa.cour;
        }
    }

    public List<Artifact> artifacts = new List<Artifact>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" keeping "+artifacts.Count);
    }
}
