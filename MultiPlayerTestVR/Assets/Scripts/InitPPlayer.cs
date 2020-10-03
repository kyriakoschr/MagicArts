using Photon.Pun;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
using System.Collections;
using System.Collections.Generic;
using Tilia.Indicators.ObjectPointers;
using Tilia.Indicators.SpatialTargets;
using Tilia.Locomotors.Teleporter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zinnia.Action;
using Zinnia.Data.Collection.List;
using Zinnia.Rule;
using Zinnia.Tracking.Follow;

public class InitPPlayer : MonoBehaviourPun
{
    public GameObject left;
    public GameObject right;
    public GameObject head;
    public GameObject lzoom;
    public GameObject rzoom;
    public GameObject flz;
    public GameObject frz;
    public GameObject accepted;
    public GameObject voted;
    public GameObject table;
    public GameObject guest;
    public GameObject st;
    public GameObject sound;

    public TeleporterFacade teleporter;

    public GameObject headphones;
    public GameObject hmd;

    public GameObject AcceptDecline;
    public GameObject ChooseAnswer;
    
    public GameObject MyCard;
    public Material[] cards;
    public Material dMaterial;
    public Material gMaterial;

    public PhotonVoiceNetwork punvn;
    Coroutine currentHide=null;
    public GameManager gm;
    Transform scoreboard;

    /*    public BooleanAction button1;
        public BooleanAction button2;

        public GameObject playArea;
        public GameObject headset;

        public ListContainsRule cameras;

        public GameObject spatialDispatcher;*/

    public void interruptHide()
    {
        if(currentHide!=null)
            this.photonView.RPC("immediateHide", RpcTarget.AllBufferedViaServer);
    }

    [PunRPC]
    void immediateHide()
    {
        StopCoroutine(currentHide);
        currentHide = null;
        hideMyAns();
        votedOFF();
        stOFF();
        guestOff();
        punvn.Client.ChangeAudioGroups(new byte[1] { 1 }, new byte[1] { 0 });
    }

    IEnumerator hideAnswer()
    {
        yield return new WaitForSeconds(120);
        hideMyAns();
        votedOFF();
        stOFF();
        guestOff();
        punvn.Client.ChangeAudioGroups(new byte[1] { 1 }, new byte[1] { 0 });
    }

    public void teleGuest()
    {
        this.photonView.RPC("tGuest", RpcTarget.AllBufferedViaServer);
    }

    [PunRPC]
    void tGuest()
    {
        GameObject emptyGO = new GameObject();
        Transform newTransform = emptyGO.transform;
        Vector3 v3 = scoreboard.position + new Vector3(Random.Range(1,3)==1? Random.Range(10, 30): Random.Range(-30, -10), 0, Random.Range(1, 3) == 1 ? Random.Range(10, 30) : Random.Range(-30, -10));
        newTransform.position = v3;
        newTransform.LookAt(scoreboard);
        teleporter.Teleport(newTransform);
        sound.GetComponent<AudioSource>().Play();
    }

    [PunRPC]
    public void revealAnswer(string cardname)
    {
        cards = Resources.LoadAll<Material>("TexturesM/");
        Debug.LogError(cardname + " is cardname and total cards "+cards.Length+" cardname "+cardname);
        foreach (Material m in cards)
        {
            Debug.LogError(m.name);
            if (m.name.Equals(cardname))
            {
                MyCard.GetComponent<MeshRenderer>().material = m;
                //MyCard.SetActive(true);
                break;
            }
        }
        GameObject emptyGO = new GameObject();
        Transform newTransform = emptyGO.transform;
        Vector3 v3 = scoreboard.position + new Vector3(Random.Range(1, 3) == 1 ? Random.Range(10, 30) : Random.Range(-30, -10), 0, Random.Range(1, 3) == 1 ? Random.Range(10, 30) : Random.Range(-30, -10));
        newTransform.position = v3;
        newTransform.LookAt(scoreboard);
        teleporter.Teleport(newTransform);
        sound.GetComponent<AudioSource>().Play();
        currentHide =StartCoroutine(hideAnswer());
    }

    public void revealMyAnswer(string cardname)
    {
        this.photonView.RPC("revealAnswer", RpcTarget.AllBufferedViaServer,cardname);
    }

    public void EnableDisableHMD(bool input)
    {
        hmd.SetActive(input);
    }
    
    public void EnableDisableHeadphones(bool input)
    {
        headphones.SetActive(input);
    }

    public void acceptON()
    {
        this.photonView.RPC("trueAccept", RpcTarget.AllBufferedViaServer);
    }
    
    public void guestON()
    {
        this.photonView.RPC("guestTrue", RpcTarget.AllBufferedViaServer);
    }
    
    public void guestOff()
    {
        this.photonView.RPC("guestFalse", RpcTarget.AllBufferedViaServer);
    }
    
    public void votedON()
    {
        this.photonView.RPC("trueVoted", RpcTarget.AllBufferedViaServer);
    }

    public void acceptOFF()
    {
        this.photonView.RPC("falseAccept", RpcTarget.AllBufferedViaServer);
    }
    
    public void votedOFF()
    {
        this.photonView.RPC("falseVoted", RpcTarget.AllBufferedViaServer);
    }
    
    public void hideMyAns()
    {
        this.photonView.RPC("hideRPC", RpcTarget.AllBufferedViaServer);
    }

    public void sttON()
    {
        this.photonView.RPC("trueST", RpcTarget.AllBufferedViaServer);
    }

    public void stOFF()
    {
        this.photonView.RPC("falseST", RpcTarget.AllBufferedViaServer);
    }

    public void AcceptInvitation()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().addPlayer();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SpawnSound").GetComponent<AudioSource>().Play();
        if (!photonView.IsMine)
            return;
        cards= Resources.LoadAll<Material>("BackColor_Blue/");
        Debug.LogError("photon view is mine");
        left = GameObject.Find("LeftControllerAlias");
        right = GameObject.Find("RightControllerAlias");
        head = GameObject.Find("HeadsetAlias");
        GameObject voice = GameObject.Find("Voice");
        voice.GetComponent<Recorder>().Init(voice.GetComponent<PhotonVoiceNetwork>().VoiceClient);
        transform.GetComponent<PhotonVoiceView>().RecorderInUse = voice.GetComponent<Recorder>();
        punvn = GameObject.Find("Voice").GetComponent<PhotonVoiceNetwork>();
        /*button1 = GameObject.Find("ButtonOne").GetComponent<BooleanAction>();
        button2 = GameObject.Find("ButtonTwo").GetComponent<BooleanAction>();
        
        playArea = GameObject.Find("PlayAreaAlias").gameObject;
        headset = GameObject.Find("HeadsetAlias").gameObject;

        cameras = GameObject.Find("SceneCameras").GetComponent<ListContainsRule>();

        spatialDispatcher = GameObject.Find("Indicators.SpatialTargets.Dispatcher");*/

        this.transform.Find("FollowLeftHand").GetComponent<ObjectFollower>().Sources.InsertAt(left,0);
        this.transform.Find("FollowRightHand").GetComponent<ObjectFollower>().Sources.InsertAt(right,0);
        this.transform.Find("FollowHMD").GetComponent<ObjectFollower>().Sources.InsertAt(head, 0);

        scoreboard = GameObject.Find("MenuBoard_double").transform;
        sound = GameObject.Find("SpawnSound");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        teleporter = GameObject.Find("CameraRigs.TrackedAlias/Locomotors.Teleporter.Instant").GetComponent<TeleporterFacade>();

        ZoomFunctions zm = GameObject.Find("ZoomFunctions").GetComponent<ZoomFunctions>();
        zm.LZoom = lzoom;
        zm.RZoom = rzoom;

        if (PhotonNetwork.CountOfPlayers > 2)
            gm.openT();
        //this.photonView.RPC("setUname", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName); //set avatar instead of viewid

        /*GameObject temp = this.transform.Find("Indicators.ObjectPointers.Curved").gameObject;
        temp.GetComponent<PointerFacade>().FollowSource = left;
        temp.GetComponent<PointerFacade>().ActivationAction = button2;
        temp.GetComponent<PointerFacade>().SelectionAction = button1;

        UnityObjectObservableList obj = cameras.Objects;
        temp = this.transform.Find("Locomotors.Teleporter.Instant").gameObject;
        temp.GetComponent<TeleporterFacade>().Target = playArea;
        temp.GetComponent<TeleporterFacade>().Offset = headset;
        //temp.GetComponent<TeleporterFacade>().CameraValidity = cameras.Objects.;

        temp = this.transform.Find("Indicators.ObjectPointers.Straight").gameObject;
        temp.GetComponent<PointerFacade>().FollowSource = left;
        temp.GetComponent<PointerFacade>().ActivationAction = button1;
        temp.GetComponent<PointerFacade>().SelectionAction = button2;
        temp.GetComponent<PointerFacade>().Entered.AddListener(spatialDispatcher.GetComponent<SpatialTargetDispatcher>().DoDispatchEnter);
        temp.GetComponent<PointerFacade>().Exited.AddListener(spatialDispatcher.GetComponent<SpatialTargetDispatcher>().DoDispatchExit);
        temp.GetComponent<PointerFacade>().Selected.AddListener(spatialDispatcher.GetComponent<SpatialTargetDispatcher>().DoDispatchSelect);*/
    }

    [PunRPC]
    void trueAccept()
    {
        accepted.SetActive(true);
        MyCard.GetComponent<MeshRenderer>().material = gMaterial;
        this.transform.Find("vr_glove_right_model").GetComponent<MeshRenderer>().material = gMaterial;
        this.transform.Find("vr_glove_left_model").GetComponent<MeshRenderer>().material = gMaterial;
    }

    [PunRPC]
    void guestTrue()
    {
        guest.SetActive(true);
        MyCard.GetComponent<MeshRenderer>().material = gMaterial;
        this.transform.Find("vr_glove_right_model").GetComponent<MeshRenderer>().material = gMaterial;
        this.transform.Find("vr_glove_left_model").GetComponent<MeshRenderer>().material = gMaterial;
    }

    [PunRPC]
    void guestFalse()
    {
        guest.SetActive(false);
        MyCard.GetComponent<MeshRenderer>().material = dMaterial;
        this.transform.Find("vr_glove_right_model").GetComponent<MeshRenderer>().material = gMaterial;
        this.transform.Find("vr_glove_left_model").GetComponent<MeshRenderer>().material = gMaterial;
    }

    [PunRPC]
    void trueVoted()
    {
        voted.SetActive(true);
    }

    [PunRPC]
    void hideRPC()
    {
        MyCard.GetComponent<MeshRenderer>().material = dMaterial;
        this.transform.Find("vr_glove_right_model").GetComponent<MeshRenderer>().material = dMaterial;
        this.transform.Find("vr_glove_left_model").GetComponent<MeshRenderer>().material = dMaterial;
        //MyCard.SetActive(false);
    }

    [PunRPC]
    void falseAccept()
    {
        accepted.SetActive(false);
    }
    
    [PunRPC]
    void falseVoted()
    {
        voted.SetActive(false);
    }

    [PunRPC]
    void trueST()
    {
        st.SetActive(true);
        MyCard.GetComponent<MeshRenderer>().material = gMaterial;
        this.transform.Find("vr_glove_right_model").GetComponent<MeshRenderer>().material = gMaterial;
        this.transform.Find("vr_glove_left_model").GetComponent<MeshRenderer>().material = gMaterial;

    }

    [PunRPC]
    void falseST()
    {
        st.SetActive(false);
    }

    [PunRPC]
    void setUname(string uname)
    {
        transform.Find("Head/Username").GetComponent<TextMeshPro>().SetText(uname);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
