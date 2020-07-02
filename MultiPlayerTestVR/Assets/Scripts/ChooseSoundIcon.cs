using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSoundIcon : MonoBehaviour
{
    public MMManger mmm;
    public Sprite headset;
    public Sprite sound;

    // Start is called before the first frame update
    void Start()
    {
        if (mmm.Version.Equals(1))
            GetComponent<SpriteRenderer>().sprite = headset;
        else
            GetComponent<SpriteRenderer>().sprite = sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
