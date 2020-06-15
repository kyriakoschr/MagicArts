using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class TurnTable : MonoBehaviour
{

    [SerializeField] GameObject smallPicture;
    [SerializeField] GameObject bigPicture;
    [SerializeField] Transform picturePanel;
    float noOfPictures;

    public void SetPPanel(Transform go)
    {
        //picturePanel = go;
        Sprite[] pictures = Resources.LoadAll<Sprite>("Art/");
        Debug.Log(pictures.Length + " is lent ");
        for (int i = 0; i < pictures.Length; i++)
        {
            GameObject clone = (GameObject)Instantiate(smallPicture,picturePanel);
            clone.GetComponentInChildren<Image>().sprite = pictures[i];
            clone.transform.SetParent(picturePanel);
            clone.GetComponentInChildren<Text>().text = pictures[i].name;
            /*
            clone = (GameObject)Instantiate(bigPicture);
            clone.GetComponentInChildren<Image>().sprite = pictures[i];
            clone.GetComponentInChildren<Text>().text = pictures[i].name;
            RotateMe(i * 360 / pictures.Length);
            clone.transform.SetParent(transform);
            */
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetPPanel(null);
        /*Sprite[] pictures = Resources.LoadAll<Sprite>("Art/");
        Debug.Log(pictures.Length + " is lent ");
        for (int i = 0; i < pictures.Length; i++)
        {
            GameObject clone = (GameObject)Instantiate(smallPicture);
            clone.GetComponentInChildren<Image>().sprite = pictures[i];
            clone.transform.SetParent(picturePanel);
            clone.GetComponentInChildren<Text>().text = pictures[i].name;
            *//*
            clone = (GameObject)Instantiate(bigPicture);
            clone.GetComponentInChildren<Image>().sprite = pictures[i];
            clone.GetComponentInChildren<Text>().text = pictures[i].name;
            RotateMe(i * 360 / pictures.Length);
            clone.transform.SetParent(transform);
            *//*
        }*/
        //noOfPictures = pictures.Length;
        //RotateMe(new Vector2(0.5f, 0.5f));
    }
    public void Deb()
    {
        Debug.Log("SELCEVTED");
    }
    public void RotateMe(Vector2 vector2)
    {
        RotateMe(vector2.x*(360 -360/noOfPictures));
    }

    void RotateMe(float angle)
    {
        Quaternion newRotation = new Quaternion();
        //newRotation.eulerAngles = new Vector3(0, angle, 0);
        transform.rotation = newRotation;
    }
}
