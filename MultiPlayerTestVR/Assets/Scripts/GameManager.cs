using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dText;
    public GameObject aText;
    public Button startGame;
    public Button startRound;
    public Button hide;
    public Button choose;
    public GameObject choosePanel;
    public Dictionary<string, string> answers = new Dictionary<string, string>();
    public Dictionary<string, int> scores = new Dictionary<string, int>();
    public string correctAnswer;
    public string narrator;
    public GameObject scoreboard1;
    public GameObject scoreboard2;
    public GameObject prefab;
    public RectTransform rt;
    public RectTransform rt2;
    public GameObject sGroup;
    public GameObject btn;
    public AudioSource Sound;

    public void generateRows()
    {
        Debug.Log("Generate rows");
        foreach (Transform child in scoreboard1.transform)
        {
            if (child.name.Equals("Head"))
                continue;
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in scoreboard2.transform)
        {
            if (child.name.Equals("Head"))
                continue;
            GameObject.Destroy(child.gameObject);
        }
        scores = scores.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        int i = 1;
        foreach (string uname in scores.Keys)
        {
            GameObject myrow = Instantiate(prefab, scoreboard1.transform.Find("Head").transform);
            GameObject myrow1 = Instantiate(prefab, scoreboard2.transform.Find("Head").transform);
            myrow.transform.Find("Rank").GetComponent<Text>().text = i.ToString();
            myrow.transform.Find("Name").GetComponent<Text>().text = uname;
            myrow.transform.Find("Score").GetComponent<Text>().text = scores[uname].ToString();
            myrow.transform.parent = scoreboard1.transform;
            myrow.GetComponent<RectTransform>().localPosition = new Vector3(myrow.GetComponent<RectTransform>().localPosition.x, myrow.GetComponent<RectTransform>().localPosition.y,11);
            myrow1.transform.Find("Rank").GetComponent<Text>().text = i.ToString();
            myrow1.transform.Find("Name").GetComponent<Text>().text = uname;
            myrow1.transform.Find("Score").GetComponent<Text>().text = scores[uname].ToString();
            myrow1.transform.parent = scoreboard2.transform;
            myrow1.GetComponent<RectTransform>().localPosition = new Vector3(myrow1.GetComponent<RectTransform>().localPosition.x, myrow1.GetComponent<RectTransform>().localPosition.y, 11);
            i++;
        }
        //btn.SetActive(true); //start round btn enabled
        answers.Clear();
        narrator = "";
        correctAnswer = "";
        //sGroup.transform.Find("Storyteller").GetComponent<Text>().text = ""; //clear storyteller holder in ui
        Sound.Play();
    }

    // public void onHide()
    // {
    //     Debug.LogError("narrator is " + narrator);
    //     if (narrator.Equals("") )
    //         startGame.gameObject.SetActive(true);
    //     else
    //     {
    //         sGroup.SetActive(false);
    //         choose.gameObject.SetActive(true);
    //     }
    // }

    void Start()
    {
        //hide.onClick.AddListener(onHide);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
