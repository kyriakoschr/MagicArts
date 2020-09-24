using Photon.Pun;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
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
    public PhotonVoiceNetwork punvn;
    public Recorder recorder;
    public List<String> guests;

    public void calcScore()
    {
        /*scores.Add("kokos", 1);
        scores.Add("koka", 2);
        scores.Add("koki", 3);
        rounds.Add("kokos", 1);
        rounds.Add("koka", 1);
        rounds.Add("koki", 1);*/
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
        //revealAnswer();
        generateRows();
    }

    public void revealAnswer()
    {
        string myname = PhotonNetwork.LocalPlayer.NickName;
        string cardname;
        if (guests.Contains(myname))
            return;
        Debug.LogError("narr is " + narrator+" myname is "+myname);
        if (narrator.Equals(myname))
        {
            cardname = correctAnswer;
        }
        else
        {
            cardname = answers[myname];
        }
        Debug.LogError("cardname is " + cardname);
        gameController.myLocalPlayer.GetComponent<InitPPlayer>().revealMyAnswer(cardname);
    }

    public void generateRows()
    {
        Debug.LogError("Generate rows "+scores.Count+" "+answers.Count);
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
        //sGroup.transform.Find("Storyteller").GetComponent<Text>().text = ""; //clear storyteller holder in ui
        Debug.LogError("scores written");
        Sound.Play();
        Debug.LogError("sound played"); 
        startGame.SetActive(true);
        Debug.LogError("button active");
        //revealAnswer();
        Debug.LogError("answers revealed");
        answers.Clear();
        guests.Clear();
        narrator = "";
        correctAnswer = "";
        //this.photonView.RPC("deAccept", RpcTarget.All); //set avatar instead of viewid
    }

    [PunRPC]
    public void deAccept()
    {
        gameController.myLocalPlayer.GetComponent<InitPPlayer>().acceptOFF();
        gameController.myLocalPlayer.GetComponent<InitPPlayer>().stOFF();
        punvn.Client.ChangeAudioGroups(new byte[1] { 1 }, new byte[1] { 0 });
        //recorder.AudioGroup = 0;
    }

    public void onHide()
    {
        Debug.LogError("narrator is " + narrator);
        if (correctAnswer.Equals(""))
            startGame.SetActive(true);
        else
            hide.SetActive(true);
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
        startGame.SetActive(false);
        gameController.myLocalPlayer.GetComponent<InitPPlayer>().acceptON();
        punvn.Client.ChangeAudioGroups(new byte[1] { 0 }, new byte[1] { 1 });
        //recorder.AudioGroup = 1;
    }
    
    public void addGuest()
    {
        this.photonView.RPC("Guest", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName); //set avatar instead of viewid
        startGame.SetActive(false);
        gameController.myLocalPlayer.GetComponent<InitPPlayer>().guestON();
        punvn.Client.ChangeAudioGroups(new byte[1] { 0 }, new byte[1] { 1 });
        //recorder.AudioGroup = 1;
    }

    [PunRPC]
    public void Accept(string username)
    {
        answers.Add(username, "accepted");
    }
    
    [PunRPC]
    public void Guest(string username)
    {
        guests.Add(username);
    }
    
    [PunRPC]
    public void interruptH()
    {
        gameController.myLocalPlayer.GetComponent<InitPPlayer>().interruptHide();
    }

    public void interrupt()
    {
        this.photonView.RPC("interruptH", RpcTarget.All); 
    }

    public void InviteUsers()
    {
        if (narrator.Equals(""))
        {
            interrupt();
            this.photonView.RPC("AcceptDecline", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName); //set avatar instead of viewid
            gameController.myLocalPlayer.GetComponent<InitPPlayer>().sttON();
            gameController.myLocalPlayer.GetComponent<InitPPlayer>().guestOff();
            gameController.myLocalPlayer.GetComponent<InitPPlayer>().votedOFF();
            gameController.myLocalPlayer.GetComponent<InitPPlayer>().acceptOFF();
            punvn.Client.ChangeAudioGroups(new byte[1] { 0 }, new byte[1] { 1 });
        }
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
            gameController.myLocalPlayer.GetComponent<InitPPlayer>().acceptOFF();
            gameController.myLocalPlayer.GetComponent<InitPPlayer>().votedON();
        }
    }

    public void CardPlaced(GameObject obj)
    {
        if (narrator.Equals(PhotonNetwork.LocalPlayer.NickName))
            this.photonView.RPC("CardPlacedRPC", RpcTarget.All,obj.name); //set avatar instead of viewid
        else
        {
            /*answers[PhotonNetwork.LocalPlayer.NickName] = obj.name;
            answered++;
            if (answers.Count.Equals(answered))
            {
                revealAnswer();
                calcScore();
                //show scoreboard
                answered = 0;
            }*/
            this.photonView.RPC("Answered", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName,obj.name); //set avatar instead of viewid
            gameController.myLocalPlayer.GetComponent<InitPPlayer>().acceptOFF();
            gameController.myLocalPlayer.GetComponent<InitPPlayer>().votedON();
        }
    }

    [PunRPC]
    public void Answered(string user,string answer)
    {
        Debug.LogError(user + " answered " + answer);
        answers[user] = answer;
        answered++;
        if (answers.Count.Equals(answered))
        {
            revealAnswer();
            calcScore();
            //show scoreboard
            answered = 0;
        }

    }

    [PunRPC]
    public void CardPlacedRPC(string answer)
    {
        correctAnswer = answer;
        //calcScore();
        if (!PhotonNetwork.LocalPlayer.NickName.Equals(narrator))
        {
            if (!answers.ContainsKey(PhotonNetwork.LocalPlayer.NickName))
                return;
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
