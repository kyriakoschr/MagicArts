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
        /*GameObject old = interactor;*/
        interactor = Instantiate(interactor, this.transform);
/*        Destroy(old);
*/    }

    private void OnEnable()
    {
        if (interactor.name.Contains("SimBtn")|| interactor.name.Contains("Buttons"))
        {
            GameObject old = interactor;
            reload();
            interactor.SetActive(true);
            old.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
