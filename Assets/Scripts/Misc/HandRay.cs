using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class HandRay : MonoBehaviour
{
    public Transform reticle;
    
    public float maxDistance = 50f;
    private LineRenderer line;
    private Vector3 initialReticlePosition;
    
    void Awake()
    {
        line = GetComponent<LineRenderer>();
        initialReticlePosition = reticle.transform.position;
    }

    void DrawRay()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, reticle.transform.position);
    }
    
    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.red);
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            reticle.transform.position = hit.point;
        }
        else
        {
            reticle.transform.position = initialReticlePosition;
        }
        
        
        DrawRay();
    }
}
