using Photon.Pun;
using Photon.Voice.PUN;
using Photon.Voice.Unity;
using System.Collections;
using System.Collections.Generic;
using Tilia.Indicators.ObjectPointers;
using Tilia.Indicators.SpatialTargets;
using Tilia.Locomotors.Teleporter;
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

    public GameObject headphones;
    public GameObject hmd;

/*    public BooleanAction button1;
    public BooleanAction button2;

    public GameObject playArea;
    public GameObject headset;

    public ListContainsRule cameras;

    public GameObject spatialDispatcher;*/

    public void EnableDisableHMD(bool input)
    {
        hmd.SetActive(input);
    }
    
    public void EnableDisableHeadphones(bool input)
    {
        headphones.SetActive(input);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
            return;
        Debug.LogError("photon view is mine");
        left = GameObject.Find("LeftControllerAlias");
        right = GameObject.Find("RightControllerAlias");
        head = GameObject.Find("HeadsetAlias");
        GameObject voice = GameObject.Find("Voice");
        voice.GetComponent<Recorder>().Init(voice.GetComponent<PhotonVoiceNetwork>().VoiceClient);
        transform.GetComponent<PhotonVoiceView>().RecorderInUse = voice.GetComponent<Recorder>();
        /*button1 = GameObject.Find("ButtonOne").GetComponent<BooleanAction>();
        button2 = GameObject.Find("ButtonTwo").GetComponent<BooleanAction>();
        
        playArea = GameObject.Find("PlayAreaAlias").gameObject;
        headset = GameObject.Find("HeadsetAlias").gameObject;

        cameras = GameObject.Find("SceneCameras").GetComponent<ListContainsRule>();

        spatialDispatcher = GameObject.Find("Indicators.SpatialTargets.Dispatcher");*/

        this.transform.Find("FollowLeftHand").GetComponent<ObjectFollower>().Sources.InsertAt(left,0);
        this.transform.Find("FollowRightHand").GetComponent<ObjectFollower>().Sources.InsertAt(right,0);
        this.transform.Find("FollowHMD").GetComponent<ObjectFollower>().Sources.InsertAt(head, 0);

        ZoomFunctions zm = GameObject.Find("ZoomFunctions").GetComponent<ZoomFunctions>();
        zm.LZoom = lzoom;
        zm.RZoom = rzoom;
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
