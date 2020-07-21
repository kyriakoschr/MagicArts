// VR Head Blocking Script(Synaptic Response)
// For use with SteamVR Unity Plugin v2
// Attach to Player -> FollowHead -> HeadCollider and set Tag to "Player"
// Initial Implementation: Scott Lupton (04.18.2020)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColl : MonoBehaviour
{
    public GameObject player;

    private int layerMask;
    private Collider[] objs = new Collider[10];
    private Vector3 prevHeadPos;
    private int fadeState = 0;
    private float fadeDuration = .5f;
    private float internalFadeTimer = 0f;
    private float backupCap = .6f;

    private void Start()
    {
        layerMask = 1 << 8;
        layerMask = ~layerMask;

        prevHeadPos = transform.position;
    }

    private int DetectHit(Vector3 loc)
    {
        int hits = 0;
        int size = Physics.OverlapSphereNonAlloc(loc, backupCap, objs, layerMask, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < size; i++)
        {
            if (objs[i].tag != "Player")
            {
                hits++;
            }
        }
        return hits;
    }

    public void Update()
    {
        if (player != null)
        {
            int hits = DetectHit(transform.position);

            // No collision
            if (hits == 0)
                prevHeadPos = transform.position;
            // Collision
            else
            {
                // Player pushback
                bool notCapped = true;
                Vector3 headDiff = transform.position - prevHeadPos;
                Debug.Log(headDiff.x+" x");
                Debug.Log(headDiff.z+" z");
                if (Mathf.Abs(headDiff.x) > backupCap)
                {
                    Debug.Log("Collison detect x");
                    if (headDiff.x > 0) headDiff.x = backupCap;
                    else headDiff.x = backupCap * -1;
                    notCapped = false;
                }
                if (Mathf.Abs(headDiff.z) > backupCap)
                {
                    Debug.Log("Collison detect z");
                    if (headDiff.z > 0) headDiff.z = backupCap;
                    else headDiff.z = backupCap * -1;
                    notCapped = false;
                }
                /*if (Mathf.Abs(headDiff.z+headDiff.x) > backupCap)
                {
                    if (headDiff.z > 0) headDiff.z = backupCap;
                    else headDiff.z = backupCap * -1;
                    if (headDiff.x > 0) headDiff.x = backupCap;
                    else headDiff.x = backupCap * -1;

                    notCapped = false;
                }*/
                Vector3 adjHeadPos = new Vector3(player.transform.position.x - headDiff.x,
                                                 player.transform.position.y,
                                                 player.transform.position.z - headDiff.z);
                player.transform.SetPositionAndRotation(adjHeadPos, player.transform.rotation);
            }
        }
    }
}