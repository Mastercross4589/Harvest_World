using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToHand : MonoBehaviour
{
    public Vector3 offSet = Vector3.zero;
    
    private bool isPressed = false;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

   
        Transform otherTransform = other.gameObject.transform;

        if (isPressed)
        {
            other.GetComponent<Renderer>().material.color = Color.red;
            otherTransform.SetParent(transform.parent);
            otherTransform.position = offSet;
        }

    }
}
