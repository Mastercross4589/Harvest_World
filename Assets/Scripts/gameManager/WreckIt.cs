using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WreckIt : MonoBehaviour
{
    public Lever forwardBackwardLever, rightleftLever, upDownLever;
    public float speed, rotateSpeed;
    public WreckingResetButton resetButton;
    public GameObject wreckingBall;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startBallPosition;
    private Quaternion startBallRotation;
    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startBallPosition = wreckingBall.transform.position;
        startBallRotation = wreckingBall.transform.rotation;
        resetButton.OnButtonPressed += ResetWrecking;
    }
    void Update()
    {
        // forward and backward
        if (Mathf.Abs(forwardBackwardLever.NormalizedJointAngle()) > 0.05f)
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackwardLever.NormalizedJointAngle();
        }
        // left and right
        if (Mathf.Abs(rightleftLever.NormalizedJointAngle()) > 0.05f)
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed * rightleftLever.NormalizedJointAngle();
        }
        // up and down
        if (Mathf.Abs(upDownLever.NormalizedJointAngle()) > 0.05f)
        {
            transform.position = transform.position + transform.up * Time.deltaTime * speed * upDownLever.NormalizedJointAngle();
        }
    }
    public void ResetWrecking()
    {
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
        // stop and reset movenemt of the ball
        wreckingBall.transform.position = startBallPosition;
        wreckingBall.transform.rotation = startBallRotation;
        Rigidbody wreckingBallRB = wreckingBall.GetComponent<Rigidbody>();
        wreckingBallRB.velocity = Vector3.zero;
        wreckingBallRB.angularVelocity = Vector3.zero;
    }
}
