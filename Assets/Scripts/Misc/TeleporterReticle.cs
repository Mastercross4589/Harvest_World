using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterReticle : MonoBehaviour
{
    public Color c1 = Color.blue;
    public Color c2 = Color.red;

    public LineRenderer reticle;
    public float maxReach = 30;
    public LayerMask layerMask;

    void LateUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxReach, layerMask))
        {
            //reticle.SetPosition(transform, hit);
        }
        else
        {
            //reticle.SetPosition(transform, ray.direction);
        }
    }


    bool CheckTrigger()
    {
    #if !OCULUS_VR && !UNITY_EDITOR
        return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
    #else
        return Input.GetMouseButton(0);
    #endif
    }
}