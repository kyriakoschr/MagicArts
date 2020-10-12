using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public GameObject exitMenu;
    public Zinnia.Action.ToggleAction togleAction;
    public GameObject inputCntrls = null;
    public GameObject simChoice;

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
        exitMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            simChoice.SetActive(true);
            Cursor.visible = true;
            togleAction.Receive(true);
            inputCntrls.SetActive(false);
            exitMenu.SetActive(true);
        }
    }
}
