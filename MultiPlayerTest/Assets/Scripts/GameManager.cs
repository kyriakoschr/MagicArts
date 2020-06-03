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
    public GameObject scoreboard;
    public GameObject prefab;
    public GameObject sGroup;
    public GameObject btn; 

    public void generateRows()
    {
        Debug.Log("Generate rows");
        foreach (Transform child in scoreboard.transform)
        {
            if (child.name.Equals("Head"))
                continue;
            GameObject.Destroy(child.gameObject);
        }
        scores = scores.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        foreach (string uname in scores.Keys)
        {
            GameObject myrow = Instantiate(prefab);
            myrow.transform.Find("Name").GetComponent<Text>().text = uname;
            myrow.transform.Find("Score").GetComponent<Text>().text = scores[uname].ToString();
            myrow.transform.parent = scoreboard.transform;
        }
        btn.SetActive(true);
        answers.Clear();
        narrator = "";
        correctAnswer = "";
        sGroup.transform.Find("Storyteller").GetComponent<Text>().text = "";
    }

    void onHide()
    {
        if (narrator.Equals("") )
            startGame.gameObject.SetActive(true);
        else
        {
            sGroup.SetActive(false);
            choose.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        hide.onClick.AddListener(onHide);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scores.Values.Count + "scores count");
    }
}
