using System.Collections;
using System.Collections.Generic;
using Tilia.CameraRigs.SpatialSimulator;
using UnityEngine;
using Zinnia.Data.Collection.List;
using Zinnia.Data.Type.Transformation.Aggregation;

public class exit : MonoBehaviour
{
    public GameObject exitMenu;
    public Zinnia.Action.ToggleAction togleAction;
    public GameObject inputCntrls = null;
    public GameObject simChoice;
    public ObjectControllerConfigurator occ;
    public GameObject avobjes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void hideMenu()
    {
        simChoice.SetActive(false);
        Cursor.visible = false;
        togleAction.Receive(true);
        inputCntrls.SetActive(true);
        //occ.Target = avobjes;
        exitMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //simChoice.SetActive(true);
            if (!exitMenu.activeSelf)
            {
                Cursor.visible = true;
                togleAction.Receive(true);
                inputCntrls.SetActive(false);
                exitMenu.SetActive(true);
                //occ.ClearTarget();
            }
            else
            {
                hideMenu();
                /*inputCntrls.SetActive(true);
                togleAction.Receive(true);
                Cursor.visible = false;
                exitMenu.SetActive(false);*/
            }
        }
    }
}
