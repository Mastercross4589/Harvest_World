using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimHandGrabR : MonoBehaviour
{
    public GameObject collidingObject;  // what we're touching
    public GameObject heldObject;       // what we're holding
    public Transform snapPosition;
    public float throwForce;
    public bool isButtonPressed;        // switched on/off when we have a heldobject and we're triggering a behavior
    //private Vector3 handVelocity;
    //private Vector3 previousPosition;
    //private Vector3 handAngularVelocity;
    //private Vector3 previousAngularRotation;

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
    void Update()
    {
        // check for input
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // do the grabbing
            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;
                Grab();
                //AdvGrab();
                Debug.Log("Picked up " + heldObject.gameObject.name);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            // do the release
            if (heldObject)
            {
                Debug.Log("Dropped " + heldObject.gameObject.name);
                Release();
                //AdvRelease();
            }
        }
        if (heldObject && Input.GetKeyDown(KeyCode.Mouse1))
        {
            //heldObject.BroadcastMessage("Interaction");
            isButtonPressed = true;
        }
        if (heldObject && Input.GetKeyUp(KeyCode.Mouse1))
        {
            isButtonPressed = false;
        }

        //handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        //previousPosition = this.transform.position;

        //handAngularVelocity = (this.transform.eulerAngles = previousAngularRotation) / Time.deltaTime;
        //previousAngularRotation = this.transform.eulerAngles;
    }
    public void Grab()
    {
        heldObject.transform.SetParent(this.transform);
        //if (heldObject.GetComponent<GrabbableObjectSimHandR>())
        //{

        //}
        heldObject.transform.localPosition = heldObject.GetComponent<GrabbableObjectSimHandR>().grabOffset;
        //heldObject.transform.localRotation = heldObject.GetComponent<GrabbableObjectSimHandR>().gripOffset;
        heldObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        #region Using GetComponent
        var grabbable = heldObject.GetComponent<GrabbableObjectSimHandR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.simHandControllerR = this;
        }
        #endregion
    }
    public void Release()
    {
        #region Using GetComponent
        var grabbable = heldObject.GetComponent<GrabbableObjectSimHandR>();
        if (grabbable)
        {
            grabbable.hand = null;
            grabbable.isBeingHeld = false;
            grabbable.simHandControllerR = null;
        }
        #endregion
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.localPosition = heldObject.GetComponent<GrabbableObjectSimHandR>().grabOffset;
        heldObject.transform.SetParent(null);
        //heldObject.GetComponent<Rigidbody>().velocity = handVelocity * throwForce;
        //heldObject.GetComponent<Rigidbody>().angularVelocity = handAngularVelocity * throwForce;
        heldObject = null;

    }
    private void AdvGrab()
    {
        FixedJoint fixJoint = gameObject.AddComponent<FixedJoint>();
        fixJoint.breakForce = 2000;
        fixJoint.breakTorque = 2000;
        heldObject.transform.position = this.transform.position;
        heldObject.transform.rotation = this.transform.rotation;
        fixJoint.connectedBody = heldObject.GetComponent<Rigidbody>();
        #region Using GetComponent
        var grabbable = heldObject.GetComponent<GrabbableObjectSimHandR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.simHandControllerR = this;
        }
        #endregion
    }
    private void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            #region Using GetComponent
            var grabbable = heldObject.GetComponent<GrabbableObjectSimHandR>();
            if (grabbable)
            {
                grabbable.hand = null;
                grabbable.isBeingHeld = false;
                grabbable.simHandControllerR = null;
            }
            #endregion

            Destroy(GetComponent<FixedJoint>());

            //heldObject.GetComponent<Rigidbody>().velocity = handVelocity * throwForce;
            //heldObject.GetComponent<Rigidbody>().angularVelocity = handAngularVelocity * throwForce;
        }
        //heldObject = null;
    }
}
