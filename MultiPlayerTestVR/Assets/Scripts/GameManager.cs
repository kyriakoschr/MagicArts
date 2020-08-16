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
                {
                    if (!scores.ContainsKey(s))
                    {
                        Debug.Log("first score " + s);
                        //scores = gManager.scores;
                        //scores.Add(s, 3); 
                        if (scores.ContainsKey(name))
                            scores[name] += 3;
                        else
                            scores.Add(name, 3);
                    }
                    else
                    {
                        //scores = gManager.scores;
                        //scores[s] += 3;
                        scores[name] += 3;
                    }
                }
                else
                {
                    if (!scores.ContainsKey(s))
                    {
                        //scores = gManager.scores;
                        //scores.Add(s, 0);
                        if (scores.ContainsKey(name))
                            scores[name] += 0;
                        else
                            scores.Add(name, 0);
                    }
                }
            if (!scores.ContainsKey(narrator))
            {
                //scores = gManager.scores;
                //scores.Add(gManager.narrator, 3);
                if (scores.ContainsKey(name))
                    scores[name] += 3;
                else
                    scores.Add(name, 3);
            }
            else
            {
                //scores = gManager.scores;
                //scores[gManager.narrator] += 3;
                scores[name] += 3;
            }
        }
        else
        {
            foreach (string s in answers.Keys)
            {
                Debug.Log(s + " " + answers[s]);
                if (!scores.ContainsKey(s))
                {
                    //scores = gManager.scores;
                    //scores.Add(s, 2);
                    if (scores.ContainsKey(name))
                        scores[name] += 2;
                    else
                        scores.Add(name, 2);
                }
                else
                {
                    //scores = gManager.scores;
                    //scores[s] += 2;
                    scores[name] += 2;
                }
            }
            if (!scores.ContainsKey(narrator))
            {
                //scores = gManager.scores;
                //scores.Add(gManager.narrator, 0);
                if (scores.ContainsKey(name))
                    scores[name] += 0;
                else
                    scores.Add(name, 0);
            }
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

    public void addPlayer()
    {
        this.photonView.RPC("Accept", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName); //set avatar instead of viewid
    }

    [PunRPC]
    public void Accept(string username)
    {
        if (!PhotonNetwork.LocalPlayer.NickName.Equals(username))
        {
            answers.Add(username, "");
        }
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
            GameObject AcceptDecline = gameController.myLocalPlayer.GetComponent<InitPPlayer>().AcceptDecline.gameObject;
            AcceptDecline.SetActive(true);
            AcceptDecline.transform.Find("Canvas/Text/Storyteller").GetComponent<Text>().text = initiator;
        }
    }

    public void CardPlaced(GameObject obj)
    {
        if(narrator.Equals(PhotonNetwork.LocalPlayer.NickName))
            this.photonView.RPC("CardPlaced", RpcTarget.All,obj.name); //set avatar instead of viewid
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
    public void CardPlaced(string answer)
    {
        correctAnswer = answer;
        if (!PhotonNetwork.LocalPlayer.NickName.Equals(narrator)&&answers.ContainsKey(PhotonNetwork.LocalPlayer.NickName))
        {
            GameObject chooseAnswer = gameController.myLocalPlayer.GetComponent<InitPPlayer>().ChooseAnswer.gameObject;
            chooseAnswer.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
