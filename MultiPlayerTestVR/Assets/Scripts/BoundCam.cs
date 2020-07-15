using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundCam : MonoBehaviour
{
    public float MINrota = 0.0f;
    public float MAXrota = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /** Normalize angles to a range from -180 to 180 an then clamp the angle
          * with min and max.
          */
    protected float ClampAngle(float angle, float min, float max)
    {

        angle = NormalizeAngle(angle);
        if (angle > 180)
        {
            angle -= 360;
        }
        else if (angle < -180)
        {
            angle += 360;
        }

        min = NormalizeAngle(min);
        if (min > 180)
        {
            min -= 360;
        }
        else if (min < -180)
        {
            min += 360;
        }

        max = NormalizeAngle(max);
        if (max > 180)
        {
            max -= 360;
        }
        else if (max < -180)
        {
            max += 360;
        }

        // Aim is, convert angles to -180 until 180.
        return Mathf.Clamp(angle, min, max);
    }

    /** If angles over 360 or under 360 degree, then normalize them.
     */
    protected float NormalizeAngle(float angle)
    {
        while (angle > 360)
            angle -= 360;
        while (angle < 0)
            angle += 360;
        return angle;
    }

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(ClampAngle(transform.eulerAngles.x, MINrota, MAXrota), transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
