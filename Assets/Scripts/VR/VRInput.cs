using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Collect information on our controllers
/// </summary>
public class VRInput : MonoBehaviour
{
    public bool isLeftHand;
    public float gripValue;
    public float triggerValue;
    public bool isThumbstickPressed;
    private string gripAxis;
    private string triggerAxis;
    private string thumbstickButton;
    private string thumbstickX;
    private string thumbstickY;
    public Vector2 thumbstick;
    public Vector3 handVelocity;
    private Vector3 previousPosition;
    public Vector3 handAngularVelocity;
    private Vector3 previousAngularRotation;
    void Awake()
    {
        if (isLeftHand)
        {
            gripAxis = "LeftGrip";
            triggerAxis = "LeftTrigger";
            thumbstickButton = "LeftThumbstickButton";
            thumbstickX = "LeftThumbstickX";
            thumbstickY = "LeftThumbstickY";
        }
        else
        {
            gripAxis = "RightGrip";
            triggerAxis = "RightTrigger";
            thumbstickButton = "RightThumbstickButton";
            thumbstickX = "RightThumbstickX";
            thumbstickY = "RightThumbstickY";
        }
    }

    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
        triggerValue = Input.GetAxis(triggerAxis);
        thumbstick = new Vector2(Input.GetAxis(thumbstickX), Input.GetAxis(thumbstickY));
        if (Input.GetButtonDown(thumbstickButton))
        {
            isThumbstickPressed = true;
        }
        if (Input.GetButtonUp(thumbstickButton))
        {
            isThumbstickPressed = false;
        }
        handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;
        handAngularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;
    }
}
