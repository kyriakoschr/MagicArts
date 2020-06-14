using UnityEngine;
using System.Collections;

public class MyViveController : MonoBehaviour
{
    public LayerMask handRayLayer;
    public UnityEngine.XR.XRNode handVrNode;
    public float rayLength;
    public LineRenderer lineRenderer;
    private bool isHovering;
    private GameObject currentGameObject;
    private int currentObjectID = 123456701;
    private MyVIVEscript currentInteractive;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength, handRayLayer))
        {
            Debug.Log("TRIGGERDS");
            int objectID = hit.transform.gameObject.GetInstanceID();
            if (currentObjectID != objectID)
            {
                if (currentGameObject != null)
                    currentInteractive.IsHovering = false;
                currentObjectID = objectID;
                currentGameObject = hit.transform.gameObject;
                isHovering = true;
                currentInteractive = currentGameObject.transform.GetComponent<MyVIVEscript>();
            }
            else
            {
                if (!currentInteractive.IsInUse)
                {
                    currentInteractive.IsHovering = true;
                    isHovering = true;
                    if (Input.GetAxis("MainTriggerRight") > 0.9f && handVrNode == UnityEngine.XR.XRNode.RightHand || Input.GetAxis("MainTriggerLeft") > 0.9f && handVrNode == UnityEngine.XR.XRNode.LeftHand)
                        currentInteractive.WasPressed = true;
                }
            }
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
            return;
        }
        else
        {
            if (isHovering)
            {
                currentObjectID = 123456701;
                lineRenderer.enabled = false;
                currentInteractive.IsHovering = false;
                isHovering = false;
            }
        }
    }

    public bool IsHovering
    {
        get
        {
            return isHovering;
        }
        set
        {
            isHovering = value;
        }
    }
}