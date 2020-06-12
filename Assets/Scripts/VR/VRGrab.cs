using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject heldObject;
    public Transform snapPosition;

    private Vector3 handVelocity;
    private Vector3 previousPosition;
    private Vector3 handAngularVelocity;
    private Vector3 previousAngularRotation;

    public bool gripHeld;
    public bool triggerHeld;

    private VRInput controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<VRInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.gripValue > 0.8f && gripHeld == false)
        {
            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;
                Grab();

            }
        }
        else if (controller.gripValue < 0.8f && gripHeld == true)
        {
            gripHeld = false;

            if (heldObject)
            {
                Release();
            }
        }

        if (controller.triggerValue > 0.8f && !triggerHeld)
        {
            heldObject.BroadcastMessage("Interaction");
            triggerHeld = true;
        }
        else if (controller.triggerValue < 0.8f && triggerHeld)
        {
            triggerHeld = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    public void Grab()
    {
        Debug.Log("Grabbed Object");

        heldObject.transform.SetParent(this.snapPosition);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        heldObject.transform.SetParent(this.transform);
        //heldObject.transform.localRotation = heldObject.GetComponent<GrabbableObjectSimHandR>().gripOffset;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        #region Using GetComponent
        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            //grabbable.simHandController = this;
        }
        #endregion
    }

    public void Release()
    {
        Debug.Log("You have Released");

        #region Using GetComponent
        var grabbableR = heldObject.GetComponent<GrabbableObjectSimHandR>();
        var grabbableL= heldObject.GetComponent<GrabbableObjectSimHandL>();
        if (grabbableL)
        {
            grabbableL.hand = null;
            grabbableL.isBeingHeld = false;
            grabbableL.simHandControllerL = null;
        }
        if (grabbableR)
        {
            grabbableR.hand = null;
            grabbableR.isBeingHeld = false;
            grabbableR.simHandControllerR = null;
        }
        #endregion
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        //heldObject.transform.localPosition = heldObject.GetComponent<GrabbableObjectSimHand>().grabOffset;
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity;
        heldObject.GetComponent<Rigidbody>().angularVelocity = controller.handAngularVelocity;
        heldObject = null;
    }

    // Using Fixed Joints
}