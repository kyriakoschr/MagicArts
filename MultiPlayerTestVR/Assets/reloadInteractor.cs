using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadInteractor : MonoBehaviour
{
    public GameObject prefab;
    public GameObject interactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void reload()
    {
        interactor = Instantiate(interactor, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
