using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tilia.Indicators.SpatialTargets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA;
using Zinnia.Data.Collection.List;

public class GameManager : MonoBehaviourPun
{
    // Start is called before the first frame update
    public GameObject Simulator;
    public GameObject AccDecSim;
    public GameObject dText;
    public GameObject aText;
    public GameObject startGame;
    public Button startRound;
    public GameObject hide;
    public Button choose;
    public GameObject choosePanel;
    public Dictionary<string, int> rounds = new Dictionary<string, int>();
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
    public int answered = 0;
    public GameController gameController;
    public GameObjectObservableList placeholder;

    public void calcScore()
    {
        int dvalues = answers.Values.Distinct().ToList().Count;
        if (dvalues > 1 && answers.Values.Distinct().Contains(correctAnswer))
        {
            foreach (string s in answers.Keys)
                if (answers[s].Equals(correctAnswer))
                    if (scores.ContainsKey(s))
                            scores[s] += 3;
                    else
                        scores.Add(s, 3);
                
                else
                    if (!scores.ContainsKey(s))
                        if (!scores.ContainsKey(s))
                            scores.Add(s, 0);
            if (scores.ContainsKey(narrator))
                    scores[narrator] += 3;
                else
                    scores.Add(narrator, 3);
        }
        else
        {
            foreach (string s in answers.Keys)
                if (scores.ContainsKey(s))
                    scores[s] += 2;
                else
                    scores.Add(s, 2);
            if (!scores.ContainsKey(narrator))
                //scores = gManager.scores;
                //scores.Add(gManager.narrator, 0);
                if (!scores.ContainsKey(narrator))
                    scores.Add(narrator, 0);
        }
        if (rounds.Count.Equals(0))
            foreach (string uname in scores.Keys)
                rounds.Add(uname, 1);
        else
        {
            foreach (string uname in scores.Keys)
                if (rounds.ContainsKey(uname))
                    rounds[uname] += 1;
                else
                    rounds[uname] = 1;
        }
    }

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
            GameObject myrow = Instantiate(prefab, scoreboard1.transform);
            GameObject myrow1 = Instantiate(prefab, scoreboard2.transform);
            myrow.transform.Find("Rank").GetComponent<Text>().text = i.ToString();
            myrow.transform.Find("Name").GetComponent<Text>().text = uname;
            myrow.transform.Find("Score").GetComponent<Text>().text = scores[uname].ToString();
            myrow.transform.Find("Rounds").GetComponent<Text>().text = rounds[uname].ToString();
            myrow.transform.parent = scoreboard1.transform;
            myrow.GetComponent<RectTransform>().localPosition = new Vector3(myrow.GetComponent<RectTransform>().localPosition.x, myrow.GetComponent<RectTransform>().localPosition.y,0);
            myrow1.transform.Find("Rank").GetComponent<Text>().text = i.ToString();
            myrow1.transform.Find("Name").GetComponent<Text>().text = uname;
            myrow1.transform.Find("Score").GetComponent<Text>().text = scores[uname].ToString();
            myrow1.transform.Find("Rounds").GetComponent<Text>().text = rounds[uname].ToString();
            myrow1.transform.parent = scoreboard2.transform;
            myrow1.GetComponent<RectTransform>().localPosition = new Vector3(myrow1.GetComponent<RectTransform>().localPosition.x, myrow1.GetComponent<RectTransform>().localPosition.y, 0);
            i++;
        }
        //btn.SetActive(true); //start round btn enabled
        answers.Clear();
        narrator = "";
        correctAnswer = "";
        //sGroup.transform.Find("Storyteller").GetComponent<Text>().text = ""; //clear storyteller holder in ui
        Sound.Play();
    }

    public void onHide()
    {
        Debug.LogError("narrator is " + narrator);
        if (correctAnswer.Equals("")) 
            startGame.SetActive(true);
        /*else
        {
            sGroup.SetActive(false);
            choose.gameObject.SetActive(true);
        }*/
    }

    void Start()
    {
        //hide.onClick.AddListener(onHide);
    }

    public void addPlayer()
    {
        this.photonView.RPC("Accept", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName); //set avatar instead of viewid
    }

    [PunRPC]
    public void Accept(string username)
    {
        answers.Add(username, "accepted");
    }

    public void InviteUsers()
    {   
        this.photonView.RPC("AcceptDecline", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName); //set avatar instead of viewid
    }

    [PunRPC]
    public void AcceptDecline(string initiator)
    {
        narrator = initiator;
        if (!PhotonNetwork.LocalPlayer.NickName.Equals(initiator))
        {
            if (!Simulator.activeSelf)
            {
                GameObject AcceptDecline = gameController.myLocalPlayer.GetComponent<InitPPlayer>().AcceptDecline.gameObject;
                AcceptDecline.SetActive(true);
                AcceptDecline.transform.Find("Canvas/Text/Storyteller").GetComponent<Text>().text = initiator;
            }
            else
            {
                AccDecSim.SetActive(true);
                AccDecSim.transform.Find("AcceptDeclineVR/Canvas/Text/Storyteller").GetComponent<Text>().text = initiator;
            }
        }
    }

    public void CardPlacedSim(Text input)
    {
        if (narrator.Equals(PhotonNetwork.LocalPlayer.NickName))
            this.photonView.RPC("CardPlacedRPC", RpcTarget.All, input.text); //set avatar instead of viewid
        else
        {
            this.photonView.RPC("Answered", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, input.text); //set avatar instead of viewid
        }
    }

    public void CardPlaced(GameObject obj)
    {
        if(narrator.Equals(PhotonNetwork.LocalPlayer.NickName))
            this.photonView.RPC("CardPlacedRPC", RpcTarget.All,obj.name); //set avatar instead of viewid
        else
        {
            this.photonView.RPC("Answered", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName,obj.name); //set avatar instead of viewid
        }
    }

    [PunRPC]
    public void Answered(string user,string answer)
    {
        answers[user] = answer;
        answered++;
        if (answers.Count.Equals(answered))
        {
            calcScore();
            generateRows();
            //show scoreboard
            answered = 0;
        }

    }

    [PunRPC]
    public void CardPlacedRPC(string answer)
    {
        correctAnswer = answer;
        if (!PhotonNetwork.LocalPlayer.NickName.Equals(narrator))
        {
            if (Simulator.activeInHierarchy) {
                choosePanel.SetActive(true);
            }
            else
            {
                GameObject chooseAnswer = gameController.myLocalPlayer.GetComponent<InitPPlayer>().ChooseAnswer.gameObject;
                chooseAnswer.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
